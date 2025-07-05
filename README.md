# 🧩 NTier Restful Web API Projesi (.NET 8 - Katmanlı Mimari)

Bu proje, **ASP.NET Core 8 Web API** kullanılarak geliştirilmiş, çok katmanlı mimariyi temel alan bir RESTful servis uygulamasıdır. Amaç; sürdürülebilir, test edilebilir, modüler ve genişletilebilir bir backend mimarisi sunmak, aynı zamanda gerçek hayat senaryolarına uygun temel yapıların oluşturulmasını sağlamaktır.

---

## 🚀 Proje Özeti

Proje, Entity Framework Core ile veritabanı işlemlerinin yönetildiği, servis katmanında iş kurallarının tanımlandığı ve sunum katmanında RESTful API uçlarının tanımlandığı çok katmanlı bir yapıdadır. CORS, sayfalama, filtreleme, sıralama, JWT ile rol bazlı yetkilendirme, Swagger genişletmeleri ve Postman entegrasyonu gibi birçok ileri düzey özellik projeye entegre edilmiştir.

---

## 🧱 Katman Yapısı

Proje aşağıdaki 5 ana katmandan oluşmaktadır:

- **Entities**: Veritabanı tablolarını temsil eden modeller (ör: `Department`, `Employee`, `Job`) ve ilgili veri açıklamaları bu katmanda tanımlanmıştır.
- **Repositories**: Veri erişim işlemleri, `IQueryable` üzerinden sorgulama, `trackChanges` ile nesne takibi ve veritabanı bağlantı altyapısı burada oluşturulmuştur.
- **Services**: İş mantıkları, doğrulama kontrolleri ve CRUD operasyonlarının yönetildiği katmandır.
- **Presentation**: Controller yapıları bu katmanda bulunur. İstemciden gelen istekler burada işlenir ve ilgili servisler çağrılır.
- **WebApi**: Uygulamanın çekirdek başlatma katmanıdır. `Program.cs` ve `ServiceExtensions` ile yapılandırmalar burada gerçekleştirilmiştir (Swagger, CORS, Authentication, vb.).

---

## ⚙️ Temel Özellikler

✅ Katmanlı Mimari (N-Tier)  
✅ Repository & Service Pattern  
✅ `IQueryable` ile performanslı sorgular  
✅ `trackChanges` ile nesne takipli işlemler  
✅ Veri Doğrulama (Validation)  
✅ Exception Handling ve merkezi hata yönetimi  
✅ 🔐 **JWT ile Rol Bazlı Yetkilendirme** (Admin, Manager, User)  
✅ 🔍 **Sayfalama, Filtreleme, Arama, Sıralama**  
✅ 🧾 **Content Negotiation** (JSON & CSV desteği)  
✅ 🌐 **CORS** yapılandırması ile uç noktalara bağlantı  
✅ 📊 **Swagger UI** entegrasyonu ve token ile test imkanı  
✅ 📬 **Postman koleksiyonu** ile test senaryoları  

---

## 🛠 Kurulum ve Çalıştırma

### 1️⃣ Depoyu Klonlayın
Projeyi bilgisayarınıza klonlamak için terminalde şu komutu çalıştırın:

```bash
git clone https://github.com/bahadirverir/Ntier-RestApi.git
```
### 2️⃣ Veritabanı Oluşturma
Terminali açın ve proje klasöründe WebApi katmanına geçin.

Aşağıdaki komutu girerek veritabanını oluşturun.
```bash
dotnet ef database update
```
❗️ Kurulum aşamasında sorun yaşamamak için `Kurulum-Bilgilendirme.rtf` dosyasına göz atın. 

