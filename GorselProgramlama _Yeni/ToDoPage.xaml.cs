using GorselProgramlama_Yeni.Models;
using GorselProgramlama_Yeni.Services;
using System.Collections.ObjectModel;

namespace GorselProgramlama_Yeni.Pages;

public partial class ToDoPage : ContentPage
{
    private readonly FirebaseService _firebaseService = new();
    private ObservableCollection<ToDoItem> _items = new();

    public ToDoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async Task LoadData()
    {
        try
        {
            var items = await _firebaseService.GetToDoItemsAsync();
            _items = new ObservableCollection<ToDoItem>(items ?? new List<ToDoItem>());
            toDoCollection.ItemsSource = _items;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "Görevler yüklenemedi: " + ex.Message, "Tamam");
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var item = button?.CommandParameter as ToDoItem;

        if (item == null)
            return;

        var confirm = await DisplayAlert("Sil", "Görevi silmek istiyor musunuz?", "Evet", "Hayır");
        if (!confirm)
            return;

        try
        {
            await _firebaseService.DeleteToDoAsync(item.Id);
            _items.Remove(item);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "Görev silinemedi: " + ex.Message, "Tamam");
        }
    }

    private async void OnCheckboxChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is not CheckBox checkbox || checkbox.BindingContext is not ToDoItem item)
            return;

        item.IsDone = e.Value;

        try
        {
            await _firebaseService.UpdateToDoAsync(item); // Firebase'e güncelle
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "Görev güncellenemedi: " + ex.Message, "Tamam");
        }
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(ToDoDetailPage));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", "Sayfa açılamadı: " + ex.Message, "Tamam");
        }
    }
}
