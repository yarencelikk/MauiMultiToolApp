# Çok Platformlu Yardımcı Uygulama (.NET MAUI)

Güncel döviz kurları, haberler, hava durumu ve bulut tabanlı yapılacaklar listesini tek bir uygulamada toplayan, **.NET MAUI** ve **C#** ile geliştirilmiş çok platformlu bir mobil/masaüstü uygulama.

> Bartın Üniversitesi Bilgisayar Mühendisliği – Görsel Programlama dersi kapsamında geliştirilmiştir.

---

## ✨ Özellikler

| Modül | Açıklama |
|---|---|
| 💱 **Kurlar** | Güncel döviz ve altın kurlarının Truncgil Finans API'sinden `HttpClient` ile çekilip listelenmesi, yenileme desteği |
| 📰 **Haberler** | Güncel haber başlıklarının listelenmesi ve haber detay sayfası |
| 🌤️ **Hava Durumu** | Şehir bazlı hava durumu bilgisi |
| ✅ **Yapılacaklar** | Firebase Realtime Database ile görev ekleme, listeleme, güncelleme ve silme (CRUD) |
| ⚙️ **Ayarlar** | Uygulama ayarları sayfası |

## 🛠️ Kullanılan Teknolojiler

- **.NET MAUI** – Tek kod tabanından Android, iOS, Windows ve macOS desteği
- **C# / XAML** – Uygulama mantığı ve kullanıcı arayüzü
- **Shell navigasyonu** – Flyout menü ile sayfalar arası geçiş
- **REST API + System.Text.Json** – Harici servislerden JSON veri alma ve işleme
- **Firebase Realtime Database** – Yapılacaklar listesi için bulut veri saklama

## 📂 Proje Yapısı

```
GorselProgramlama _Yeni/
├── AppShell.xaml          # Flyout menü ve sayfa yönlendirmeleri
├── FirebaseService.cs     # Firebase CRUD işlemleri
├── KurlarPage.xaml(.cs)   # Döviz kurları
├── HaberlerPage.xaml(.cs) # Haber listesi
├── HavaDurumuPage.xaml(.cs)
├── ToDoPage.xaml(.cs)     # Yapılacaklar listesi
└── AyarlarPage.xaml(.cs)
```

## 📸 Ekran Görüntüleri

<!-- Ekran görüntülerini "screenshots" klasörüne ekleyip dosya adlarını güncelle -->

| Kurlar | Haberler | Yapılacaklar |
|---|---|---|
| ![Kurlar](screenshots/kurlar.png) | ![Haberler](screenshots/haberler.png) | ![Yapılacaklar](screenshots/todo.png) |

## 🚀 Kurulum ve Çalıştırma

**Gereksinimler:** Visual Studio 2022 ve ".NET Multi-platform App UI development" iş yükü

1. Repoyu klonlayın ve `GorselProgramlama _Yeni.sln` dosyasını Visual Studio ile açın.
2. Hedef platformu seçin (Windows Machine veya Android Emulator).
3. **F5** ile uygulamayı başlatın.

## 👩‍💻 Geliştirici

**Emine Yaren Çelik**
[LinkedIn](https://www.linkedin.com/in/emine-yaren-celik-815802296/) · [GitHub](https://github.com/yarencelikk)
