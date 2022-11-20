# MedicalCenter

MedicalCenter is a web application for healthy examination. :calendar:

:dart:  My project for the ASP.NET Advanced course at SoftUni. (October 2022)

## :information_source: How It Works

- Guest visitors: 
  - browse categories of beauty services;
  - view salons with their services;
  - read blog posts.
- Logged Users:
  - book appointments using interactive datepicker; 
  - can cancel appointments; 
  - can rate salons for which they had confirmed past appointments.  
- Salon Manager (user role):
  - confirms/declines users' appointments for particular salon; 
  - controls what services are available for booking in the salon.
- Admin:
  - creates/deletes blog posts, categories, salons and services; 
  - can review the appointments history.
  
## :gear: Application Configurations

### 1. The Connection string 
is in `appsettings.json`. If you don't use SQLEXPRESS, you should replace `Server=.\\SQLEXPRESS;` with `Server=.;`

### 2. Database Migrations 
would be applied when you run the application, since the `ASPNETCORE-ENVIRONMENT` is set to `Development`. If you change it, you should apply the migrations yourself.

### 3. Seeding sample data
would happen once you run the application, including Test Accounts:
  - User: user@user.com / password: 123456
  - Salon Manager: manager@manager.com / password: 123456
  - Admin: admin@admin.com / password: 123456
 
### 4. Cloudinary Setup - optionally
#### Running without it:
You won't get an error for missing Cloudinary Credentials - it is handled by using predefined (already uploaded) image, when Cloudinary configuration is missing. So when you are creating content in admin panel, it will be added but not with the image you have chosen.
#### If you want to actually upload images, you should:
1. Add Cloudinary Credentials in `appsettings.json` in the format:
```json
  "Cloudinary": {
    "CloudName": "",
    "ApiKey": "",
    "ApiSecret": "",
    "EnvironmentVariable": ""
  }
```
2. Update the Cloudinary Setup part of `Startup.cs`'s `ConfigureServices` method as follows:
```csharp
            // Cloudinary Setup
            Cloudinary cloudinary = new Cloudinary(new Account(
                this.configuration["Cloudinary:CloudName"],
                this.configuration["Cloudinary:ApiKey"],
                this.configuration["Cloudinary:ApiSecret"]));
            services.AddSingleton(cloudinary);
```

## :framed_picture: Screenshot - Home Page

![BeautyBooking-HomePage](https://res.cloudinary.com/beauty-booking/image/upload/v1588865868/SCREENSHOTS/1-home_orn9ng.png)

## :framed_picture: Screenshot - Make An Appointment Page

![BeautyBooking-MakeAnAppointment](https://res.cloudinary.com/beauty-booking/image/upload/v1588865868/SCREENSHOTS/4-make-an-appointment_zclidt.png)

## License

This project is licensed under the [MIT License](LICENSE).

