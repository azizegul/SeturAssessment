# PhoneBook

Proje Code First mantığıyla oluşturulmuştur. 
Veritabanı olarak PostgreSql ve MongoDb kullanılmıştır. 

### Structure

* Api Gateway -> Ocelot
* Message Broker -> Rabbitmq
* Service Bus -> Mass Transit
* Databases -> PostgreSql and MongoDb
* Open Doc -> Swagger and SwaggerForOcelot
* Applied Pattern -> Mediator, CQRS, Clean Architecture

# Microservices

### Contact Service
  - Host: `https://localhost:7078`
  - Person ve Contact bilgileriyle ilgili CRUD işlemleri yapılabilmektedir.
  - Endpoinler de açıklamaları eklenmiştir.

### Report Service
 - Host: `https://localhost:7119`
 - Contact api ile iletişim bağlantısı ile rapor oluşturmaktadır.

### Ocelot - Gateway
 - Host: `https://localhost:7286`
 - Report ile Contact microservisler arasındaki iletişimi sağlar.

