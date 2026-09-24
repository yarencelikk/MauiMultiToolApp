using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GorselProgramlama_Yeni.Pages
{
    public partial class LoginPage : ContentPage
    {
        private const string ApiKey = ApiKeys.FirebaseApiKey;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text?.Trim();
            var password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ErrorLabel.Text = "Lütfen e-posta ve şifre alanlarını doldurun.";
                ErrorLabel.IsVisible = true;
                return;
            }

            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}";

            var data = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Giriş Başarılı", "Hoş geldiniz!", "Tamam");
                ErrorLabel.IsVisible = false;
                await Shell.Current.GoToAsync("MainPage");
            }
            else
            {
                if (result.Contains("EMAIL_NOT_FOUND"))
                    ErrorLabel.Text = "Bu e-posta adresine ait bir hesap bulunamadı.";
                else if (result.Contains("INVALID_PASSWORD"))
                    ErrorLabel.Text = "Şifre yanlış. Lütfen tekrar deneyin.";
                else if (result.Contains("INVALID_LOGIN_CREDENTIALS"))
                    ErrorLabel.Text = "Geçersiz giriş bilgileri. E-posta veya şifre hatalı olabilir.";
                else
                    ErrorLabel.Text = "Giriş yapılamadı. Lütfen bilgilerinizi kontrol edin.";

                ErrorLabel.IsVisible = true;
            }
        }



        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var fullName = FullNameEntry.Text?.Trim();
            var email = RegisterEmailEntry.Text?.Trim();
            var password = RegisterPasswordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ErrorLabel.Text = "Lütfen tüm alanları doldurun.";
                ErrorLabel.IsVisible = true;
                return;
            }

            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}";

            var data = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Başarılı", $"Kayıt tamamlandı, Hoş geldin {fullName}", "Tamam");
                RegisterSection.IsVisible = false;
                LoginSection.IsVisible = true;
                ErrorLabel.IsVisible = false;
            }
            else
            {
                if (result.Contains("WEAK_PASSWORD"))
                    ErrorLabel.Text = "Şifreniz en az 6 karakter olmalıdır.";
                else if (result.Contains("EMAIL_EXISTS"))
                    ErrorLabel.Text = "Bu e-posta zaten kayıtlı.";
                else
                    ErrorLabel.Text = "Kayıt başarısız. Lütfen tekrar deneyin.";

                ErrorLabel.IsVisible = true;
            }
        }



        private void OnShowRegisterTapped(object sender, EventArgs e)
        {
            LoginSection.IsVisible = false;
            RegisterSection.IsVisible = true;
            // Hataları temizle
            ErrorLabel.IsVisible = false;
            ErrorLabel.Text = string.Empty;
        }

        private void OnHideRegisterTapped(object sender, EventArgs e)
        {
            RegisterSection.IsVisible = false;
            LoginSection.IsVisible = true;
            // Hataları temizle
            ErrorLabel.IsVisible = false;
            ErrorLabel.Text = string.Empty;
        }

    }
}
