# Deyiş Uygulaması Phrase Application
**Summerskip Yaz Ekibi Projesi**

Deyiş Uygulaması; atasözlerini, deyimleri, dolaylamaları, ikilemeleri, özdeyişleri ve yansımaları barındıran 
deyiş kitaplığı uygulamasıdır.

Bu uygulamada:

  - Deyişlere Bakabilirsiniz
  - Deyiş Bilgilerini Düzenleyebilirsiniz.(Ekleme/Silme/Güncelleme)

### Teknik Bilgiler

* Platform : Visual Studio
* Yazılım Dili : C#
* Veritabanı : MSSQL
* Kullanılan Paketler : Entity Framework, Metro Framework


### Yükleme

* Platform uygulamasını yüklemek için:
```sh
https://docs.microsoft.com/tr-tr/visualstudio/install/install-visual-studio?view=vs-2019
```

* Veritabanı uygulamasını yüklemek için

```sh
https://www.microsoft.com/tr-tr/sql-server/sql-server-editions-express
```

Deyiş Uygulaması çalıştırılması için Entity Framework, Metro Framework içerir.
Bu paketleri indirmek için Visual Studio'daki **Paket Yöneticisi Konsolu**na aşağıdaki kodları yazmanız gerekli.

* Entity Framework için:

```sh
Install-Package EntityFramework
```

* Metro Framework için:

```sh
Install-Package MetroModernUI
```
