# Evcil Hayvan Yönetimi API - Onion Architecture README

## Proje Açıklaması

Bu proje, evcil hayvanların etkili bir şekilde yönetilebilmesi için geliştirilmiş bir API'yi sunar. Onion Architecture kullanılarak tasarlanan bu API, .NET7 ve Entity Framework gibi güçlü teknolojileri içerir, böylece kullanıcılarımıza en iyi deneyimi sunabiliriz.

## Onion Architecture Nedir?

Onion Architecture, yazılım projelerini modüler ve bakımı kolay hale getiren bir mimari desendir. Projeyi iç içe geçmiş katmanlara ayırarak, iş mantığı, uygulama servisleri, arayüzler ve altyapıyı temiz bir şekilde ayırır. Bu, kodun sürdürülebilirliğini artırır ve geliştirme süreçlerini optimize eder.

## Teknolojik Altyapı

### .NET7

Proje, .NET7'nin güçlü özelliklerini kullanır. Bu, geliştirici üretkenliğini artırırken performansı en üst düzeye çıkarır.

### Entity Framework

Entity Framework, veritabanı etkileşimlerini basitleştiren ve nesne ilişkisel haritalama (ORM) sağlayan bir araçtır. Bu API'de, veri yönetimi Entity Framework kullanılarak gerçekleştirilmiştir.

## Proje Yapısı

Projemiz, Onion Architecture prensiplerine göre tasarlanmıştır. 

Common/\n
├── Common.Persistence/ \n
│   └── Repositories\n
└── Common.Utilities/\n
    ├── Hashing\n
    ├── Paging\n
    └── Results\n
Core/\n
├── Week3.Application/\n
│   ├── DTOs\n
│   └── Services/\n
│       ├── ActivityService\n
│       ├── FoodService\n
│       ├── HealthService\n
│       ├── PetService\n
│       ├── Repositories\n
│       ├── UserService\n
│       └── ApplicationServiceRegistration.cs\n
├── Week3.Domain/\n
│   └── Entities\n
├── Infrastructure\n
├── Week3.Infrastructure\n
├── Week3.Persistence/\n
│   ├── Context\n
│   ├── Migrations\n
│   ├── Repositories\n
│   └── PersistenceServiceRegistration.cs\n
├── Presentation\n
└── Week3.API/\n
    ├── Controllers\n
    └── Program.cs\n

## Kurulum

Projeyi çalıştırmak için aşağıdaki adımları izleyin:

1. Repoyu bilgisayarınıza kopyalayın.
2. Visual Studio veya tercih ettiğiniz bir IDE'yi açın.
3. Projeyi yükleyin ve bağımlılıkları geri yükleyin.
4. Veritabanını oluşturmak için Entity Framework migration'ları çalıştırın.

## Kullanım

API'yi kullanmak için aşağıdaki adımları izleyin:

1. API'yi başlatın.
2. Swagger belgelendirmesini kullanarak API endpoint'lerini keşfedin.
3. İsteklerinizi uygun endpoint'lere gönderin.

## Ekran Görüntüleri

![APIs](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/APIs.png)
![DTOs](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/DTOs.png)
![activities_get](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/activities_get.png)
![activities_getById](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/activities_getById.png)
![activities_post](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/activities_post.png)
![foods_get](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/foods_get.png)
![foods_getById](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/foods_getById.png)
![foods_post](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/foods_post.png)
![healthStatuses_get](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/healthStatuses_get.png)
![healthStatuses_patch](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/healthStatuses_patch.png)
![pets_get](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/pets_get.png)
![pets_getById](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/pets_getById.png)
![pets_post](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/pets_post.png)
![pets_put](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/pets_put.png)
![users_get](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/users_get.png)
![users_getByEmail](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/users_getByEmail.png)
![users_getById](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/users_getById.png)
![users_post](https://github.com/Fimple-Net-Bootcamp/week3-ilhan48/blob/main/Assets/users_post.png)
