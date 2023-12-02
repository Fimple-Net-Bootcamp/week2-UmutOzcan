### Proje Tanımı: Uzay Hava Durumu API'si
Bu API, çeşitli gezegenler ve uydular için hayali hava durumu bilgileri sunar. Örnek olarak Mars, Jüpiter'in uydusu Europa veya Saturn'ün uydusu Titan gibi gök cisimleri için hava durumu verileri sağlayabiliriz. API, REST prensiplerine uygun olarak tasarlanacak ve HTTP metodları ile durum kodları etkili bir şekilde kullanılacak.

### Ödevin Amaçları
1. RESTful API tasarım prensiplerini uygulamak.
2. HTTP metodlarını ve durum kodlarını doğru şekilde kullanmak.
3. Okunabilir ve anlaşılır bir API yapısı oluşturmak.

---

REST API tasarımında "best practice" (en iyi uygulama) prensipleri, kullanıcı dostu, verimli ve sürdürülebilir bir API oluşturmanıza yardımcı olur. İyi bir REST API tasarımı, kullanıcıların API'nizi kolayca anlamasını ve kullanmasını sağlar. İşte REST API tasarımının bazı temel prensipleri:

### 1. Açık ve Anlaşılır URL'ler Kullanın

- **Kaynak Odaklı Yapı**: API'nizin kaynaklarına (veritabanı tabloları, nesneler vb.) odaklanın ve URL'lerinizde bu kaynakları ifade edin. 
- **Basit ve Tahmin Edilebilir**: URL'lerinizin anlaşılması ve hatırlanması kolay olmalıdır.

### 2. HTTP Metotlarını Doğru Kullanın

- **GET**: Veri okuma işlemleri için kullanın. Yan etkisi olmamalıdır.
- **POST**: Yeni bir kaynak oluşturmak için kullanın.
- **PUT**: Mevcut bir kaynağı güncellemek için kullanın. Genellikle tam kaynağı güncellemek için kullanılır.
- **PATCH**: Mevcut bir kaynağı kısmen güncellemek için kullanın.
- **DELETE**: Bir kaynağı silmek için kullanın.

### 3. Uygun Durum Kodları Kullanın

- **200 OK**: Başarılı GET, PUT, PATCH veya DELETE işlemi için.
- **201 Created**: Başarılı POST işlemi için.
- **204 No Content**: Başarılı ama yanıt gövdesiz işlem için (örneğin, DELETE).
- **400 Bad Request**: Müşteri hatası.
- **401 Unauthorized**: Kimlik doğrulama gerektiren işlemler için.
- **403 Forbidden**: Yetkilendirme hatası.
- **404 Not Found**: Kaynak bulunamadı.
- **500 Internal Server Error**: Sunucu hatası.

### 4. Kaynakları Doğru Şekilde İfade Edin

- **Çoğul İsimler Kullanın**: Örneğin, `/users` veya `/orders` gibi.
- **İlişkilendirmeleri Yansıtın**: Örneğin, bir kullanıcının siparişlerini getirmek için `/users/{id}/orders`.

### 5. Sayfalama, Filtreleme ve Sıralama Özellikleri Ekleyin

- **Sayfalama**: Büyük veri setlerini yönetmek için sayfalama yapın. Örneğin, `?page=2&size=10`.
- **Filtreleme**: Kaynakları filtrelemek için parametreler kullanın. Örneğin, `?status=active`.
- **Sıralama**: Sonuçların sıralama düzenini belirlemek için parametreler kullanın. Örneğin, `?sort=created_date,asc`.

### 6. Sürüm Yönetimi

- API'nizin sürümünü yönetin. URL'de veya HTTP başlıklarında sürüm bilgisini belirtin. Örneğin, `/api/v1/users`.
