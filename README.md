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
  - User: can be registered or used `Facebook`/`Google` profile
  
### 4. External Login/Register Setup - optionally
#### Running without it:
You won't get an error for missing Credentials - it is handled by using predefined (already uploaded) image, when configuration is missing. So when you are creating content in admin panel, it will be added but not with the image you have chosen.
#### If you want to actually upload images, you should:
1. Add Credentials in `appsettings.json` in the format:
```json
  "Facebook": {
    "AppId": "",
    "AppSecret": "",
  "Google": {
    "ClientId": "",
    "ClientSecret": "",
  }
```
2. Update the Program part of `Program.cs`'s `ConfigureServices` method as follows:
```csharp
            builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Facebook:AppId"];
        options.AppSecret = builder.Configuration["Facebook:AppSecret"];
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Google:ClientId"];
        options.ClientSecret = builder.Configuration["Google:ClientSecret"];
    });
```

## :framed_picture: Screenshot - Home Page

![MedicalCenter-HomePage](https://i.imgur.com/jNsQ4Yz.png)

![User-Login](https://i.imgur.com/brRZIcY.png)

![User-Registration](https://i.imgur.com/2AULsG0.png)

![User-Exteral-Registration](https://i.imgur.com/yB3yGIy.png)

## :framed_picture: Screenshot - Admin Page

![Admin-HomePage](https://i.imgur.com/FJMbHBd.png)

![Admin-Panel](https://i.imgur.com/4zJ0xfA.png)

## :framed_picture: Screenshot - Doctor Page

![Doctor-HomePage](https://i.imgur.com/mp63TY3.png)

![Doctor-Board](https://i.imgur.com/HH1zdFI.png)

![Doctor-ReceiveComents](https://i.imgur.com/dTvD6Dt.png)

![Doctor-ShowExamination](https://i.imgur.com/SI2EORg.png)

## :framed_picture: Screenshot - User Page

![User-HomePage](https://i.imgur.com/yq252ei.png)

![User-Book](https://i.imgur.com/a8pYudg.png)

![User-Feedback](https://i.imgur.com/vja3eoX.png)

![User-Future-Examination](https://i.imgur.com/P23RJv3.png)

## License

This project is licensed under the [MIT License](LICENSE).

___
**This project is made only for educational purposes!**
___