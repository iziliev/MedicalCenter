# MedicalCenter

MedicalCenter is a web application for healthy examination. :calendar:

:dart:  My project for the ASP.NET Advanced course at SoftUni. (October 2022)

## :information_source: How It Works

- Guest visitors: 
  - browse doctors in medical center;
- Logged Users (user role):
  - book examination using interactive datepicker; 
  - can cancel examination; 
  - can rate doctor for which they had confirmed past examination.  
- Doctor (doctor role):
  - can see all self booked examination; 
  - can see all self receive rating and comment for past examination.
- Admin (administrator role):
  - create/delete doctors;
  - see all registered users;
  - see all examination in past/future;
  - see all ratings and comments for all examination;
  - see Top 5 statistic.
  
## :gear: Application Configurations

### 1. The Connection string 
is in `appsettings.json`. If you don't use SQLEXPRESS, you should replace `Server=.\\SQLEXPRESS;` with `Server=.;`

### 2. Database Migrations 
would be applied when you run the application, since the `ASPNETCORE-ENVIRONMENT` is set to `Development`. If you change it, you should apply the migrations yourself.

users(can use `Facebook` or `Google` profile), doctors and administrator can Login by username or email and their password.

### 3. Seeding sample data
would happen once you run the application, including Test Accounts:
  - Administrator: 
	|username|email|password|
	|--------|-----|--------|
	|admin|admin@mc-bg.com|Admin|
  - Doctor: 
	|username|email|password|
	|--------|-----|--------|
	|m_monastirska|m_monastirska@mc-bg.com|Doctor|
	|s_slavchev|s_slavchev@mc-bg.com|Doctor|
	|b_petkova|b_petkova@mc-bg.com|Doctor|
	|m_velikova|m_velikova@mc-bg.com|Doctor|
	|t_stoev|t_stoev@mc-bg.com|Doctor|
	|m_blagoeva|m_blagoeva@mc-bg.com|Doctor|
	|m_kalinkova|m_kalinkova@mc-bg.com|Doctor|
	|d_georgiev|d_georgiev@mc-bg.com|Doctor|
	|r_ruseva|r_ruseva@mc-bg.com|Doctor|
	|s_tochev|s_tochev@mc-bg.com|Doctor|
	|s_atanasova|s_atanasova@mc-bg.com|Doctor|
	|r_ikonomov|r_ikonomov@mc-bg.com|Doctor|
	|m_vuldjev|m_vuldjev@mc-bg.com|Doctor|
	|h_hristov|h_hristov@mc-bg.com|Doctor|
	|a_tomova|a_tomova@mc-bg.com|Doctor|
	|k_moskova|k_moskova@mc-bg.com|Doctor|
	|k_atanasova|k_atanasova@mc-bg.com|Doctor|
	|g_kuchukov|g_kuchukov@mc-bg.com|Doctor|
	|k_stoicheva|k_stoicheva@mc-bg.com|Doctor|
	|n_paskov|n_paskov@mc-bg.com|Doctor|
	|r_uzunova|r_uzunova@mc-bg.com|Doctor|
	|i_belcheva|i_belcheva@mc-bg.com|Doctor|
  - Laborant: can register `Laboratory patient` and Upload Test result on `Laboratory patient`
	|username|password|
	|--------|--------|
	|lab_vivanova|Laborant|
  - LaboratoryPatient: can be registered only by `Laborant` and can see only yours Test results
  - User: can be registered or used `Facebook`/`Google` profile
  
### 4. Cloudinary Setup - optionally
#### Running without it:
You won't get an error for missing Cloudinary Credentials - it is handled by using predefined (already uploaded) image, when Cloudinary configuration is missing. So when you are creating content in admin panel, it will be added but not with the image you have chosen.
#### If you want to actually upload images, you should:
1. Add Facebook and Google Credentials in `appsettings.json` in the format:
```json
  "Facebook": {
    "AppId": "",
    "AppSecret": "",
  },
  "Google": {
    "ClientId": "",
    "ClientSecret": "",
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

![MedicalCenter-HomePage](https://imgur.com/jNsQ4Yz.png)

![User-Login](https://imgur.com/brRZIcY.png)

![User-Registration](https://imgur.com/2AULsG0.png)

![User-Exteral-Registration](https://imgur.com/yB3yGIy.png)

## :framed_picture: Screenshot - Admin Page

![Admin-HomePage](https://imgur.com/FJMbHBd.png)

![Admin-PanelMedical](https://imgur.com/4zJ0xfA.png)

## :framed_picture: Screenshot - Doctor Page

![Doctor-HomePage](https://imgur.com/mp63TY3.png)

![Doctor-Board](https://imgur.com/HH1zdFI.png)

(https://imgur.com/dTvD6Dt.png)

![Doctor-ReceiveComents](https://imgur.com/332bHPq.png)

![Doctor-ShowExamination](https://imgur.com/SI2EORg.png)

## :framed_picture: Screenshot - User Page

![User-HomePage](https://imgur.com/yq252ei.png)

![User-AllDoctorToBook](https://imgur.com/a8pYudg.png)

![User-Feedback](https://imgur.com/vja3eoX.png)

![User-Future-Examination](https://imgur.com/P23RJv3.png)

## License

This project is licensed under the [MIT License](LICENSE).

