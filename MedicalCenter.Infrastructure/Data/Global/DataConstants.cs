namespace MedicalCenter.Infrastructure.Data.Global
{
    public class DataConstants
    {
        public static class RoleConstants
        {
            public const string DoctorRole = "Doctor";
            public const string AdministratorRole = "Administrator";
            public const string UserRole = "User";
            public const string LaborantRole = "Laborant";
            public const string LaboratoryUserRole = "LaboratoryUser";
        }

        public class ClaimTypeConstants
        {
            public const string FirsName = "urn:medicalCenter:firstName";
        }

        public class ModelErrorConstants
        {
            public const string ViewModelError = "Нещо се обърка. Моля опитайте отново!";
            public const string UsernameIsTaken = "Потребителското име е заето!";
            public const string WrongLogin = "Потребителското име и паролата са грешни!";
            public const string WrongHourExaminationError = "Може да запазите час, който е повече от 1 час от текущото време.";
            public const string WeekendExaminationError = "Събота и неделя са почивани дни. Може да запазете час само в работни дни!";
            public const string DoctorExistError = "Докторът вече същетвува!";
            public const string DoctorOutExistError = "Докторът вече същетвува в изтрити!";
            public const string WoркHourPast = "Часът вече е минал.";
            public const string OutWorkingTime = "Работното време на медицинския център е до 16:30";

            public const string RequiredLogin = "Потребителско име/Email е задължително.";
            public const string RequiredUsername = "Полето име е задължително.";
            public const string RequiredEmail = "Email е задължителен.";
            public const string RequiredPassword = "Парола е задължителна.";
            public const string RequiredConfirmPassword = "Повтори парола е задължителна.";
            public const string RequiredFirstName = "Име е задължително.";
            public const string RequiredLastName = "Фамилия е задължителна.";
            public const string RequiredPhoneNumber = "Телефон е задължителен.";

            public const string LaborantExistError = "Лаборантът вече същетвува!";
            public const string LaborantOutExistError = "Лаборантът вече същетвува в изтрити!";
            public const string LaboratoryPatientExistError = "Пациентът вече съществува!";
        }

        public class UserConstants
        {
            public const int UsernameMinLenght = 5;
            public const int UsernameMaxLenght = 15;
            public const int FirstNameMinLenght = 2;
            public const int FirstNameMaxLenght = 15;
            public const int EmailMinLenght = 3;
            public const int EmailMaxLenght = 256;
            public const int PasswordMinLenght = 6;
            public const int PasswordMaxLenght = 25;
            public const int LastNameMinLenght = 2;
            public const int LastNameMaxLenght = 15;
            public const string PhoneMatch = @"(\+)?(359|0)8[789]\d{1}\d{3}\d{3}";

            public const string UsernameError = "{0} трябва да е между {2} и {1} символа!";
            public const string EmailError = "{0} - ът трябва да е между {2} и {1} символа!";
            public const string FirstNameError = "{0} трябва да е между {2} и {1} символа!";
            public const string LastNameError = "{0} трябва да е между {2} и {1} символа!";
            public const string PasswordError = "{0} трябва да е между {2} и {1} символа!";
            public const string ConfirmPasswordError = "Паролата не съвпада!";
            public const string PhoneError = "Невалиден телефонен номер!";

        }

        public class DoctorConstants
        {
            public const int RepresentationMinLenght = 10;
            public const int RepresentationMaxLenght = 1000;
            public const int EducationMinLenght = 10;
            public const int EducationMaxLenght = 1000;
            public const int BiographyMinLenght = 10;
            public const int BiographyMaxLenght = 5000;
            public const int EgnMinMaxLenght = 10;
            public const string EgnError = "ЕГН-то трябва да е 10 цифри!";
            public const string RepresentationError = "{0} трябва да е между {2} и {1} символа!";
            public const string EducationError = "{0} трябва да е между {2} и {1} символа!";
            public const string BiographyError = "{0} трябва да е между {2} и {1} символа!";

            public const string Biography = @"Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.";
            public const string Representation = @"Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.";
            public const string Education = @"Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.";
            public const string DoctorsData = "Маргарита Монастирска https://i.imgur.com/9gZeKsk.jpg m_monastirska 7903129851 1 Станислав Славчев https://i.imgur.com/73peyhD.jpg s_slavchev 7512150522 1 Бисерка Петкова https://i.imgur.com/66UFmBy.jpg b_petkova 7412135099 8 Мими Великова https://i.imgur.com/7VzO2Pm.jpg m_velikova 8707015574 8 Тодор Стоев https://i.imgur.com/oSv4hEn.jpg t_stoev 6902251307 11 Мая Благоева https://i.imgur.com/2xoQC2H.jpg m_blagoeva 7904245096 11 Мария Калинкова https://i.imgur.com/yQmifbA.jpg m_kalinkova 9107227892 24 Димитър Георгиев https://i.imgur.com/62LMUUe.jpg d_georgiev 7504196361 24 Ралица Русева https://i.imgur.com/LKNbRcV.jpg r_ruseva 9401161818 31 Сотир Точев https://i.imgur.com/YK3Y8Ya.jpg s_tochev 8112144846 31 Стела Атанасова https://i.imgur.com/oFAixEu.jpg s_atanasova 7702262899 44 Росен Икономов https://i.imgur.com/E5Yga61.jpg r_ikonomov 8707192482 44 Михаил Вулджев https://i.imgur.com/YO1cWgu.jpg m_vuldjev 7512152504 55 Христо Христов https://i.imgur.com/42rKRT2.jpg h_hristov 7512155144 55 Антония Томова https://i.imgur.com/WkPS5Ds.jpg a_tomova 7411033533 60 Катерина Москова https://i.imgur.com/2HO3b8v.jpg k_moskova 7609186138 60 Кристина Атанасова https://i.imgur.com/GhnW3gD.jpg k_atanasova 8606163716 75 Георги Кичуков https://i.imgur.com/fkXWOZT.jpg g_kuchukov 9002041303 75 Катина Стойчева https://i.imgur.com/6NU5RvT.jpg k_stoicheva 7801138974 76 Николай Пасков https://i.imgur.com/f5yYnPN.jpg n_paskov 9103145306 76 Росица Узунова https://i.imgur.com/hx5EEMp.jpg r_uzunova 7512158631 77 Ирина Белчева https://i.imgur.com/dj7NvUl.jpg i_belcheva 7512158992 77";
        }

        public class SpecialtyConstants
        {
            public const string SpecialtiesInMC = "Акушер - гинеколог,Вътрешни болести,Дерматолог,Ендокринолог,Кардиолог,Невролог,Ортопед,Педиатър,УНГ,Уролог,Физиотерапевт";

            public const string AllSpecialties = "Акушер-гинеколог,Алерголог,Алтернативна медицина,Ангиолог,Анестезиолог,Боуен терапевт,Вирусолог,Вътрешни болести,Гастроентеролог,Гръден хирург,Дерматолог,Детски гастроентеролог,Детски ендокринолог,Детски кардиолог,Детски невролог,Детски нефролог,Детски психиатър,Детски пулмолог,Детски ревматолог,Детски хематолог,Детски хирург,Диетолог,Ендодонт,Ендокринолог,Естетичен дерматолог,Зъболекар (Стоматолог),Изследване,Имплантолог,Имунолог,Инфекциозни болести,Кардиолог,Кардиохирург,Кинезитерапевт,Клинична лаборатория,Коуч,Лицево-челюстен хирург,Логопед,Лъчетерапевт,Мамолог,Манипулация,Медицинска генетика,Медицинска сестра,Микробиолог,Невролог,Неврохирург,Неонатолог,Нефролог (Бъбречни болести),Образна диагностика,бщопрактикуващ лекар,Озонотерапевт,Онколог,Оптометрист (Очен оптик),Орален хирург,Ортодонт,Ортопед,Отоневролог,Офталмолог (Очен лекар),Паразитолог,Пародонтолог,Педиатър,Пластичен хирург,Подиатър (Болести на ходилото),Протетик,Профилактични прегледи,Психиатър,Психолог,Психотерапевт,Пулмолог (Белодробни болести),Ревматолог,Репродуктивна медицина,Рехабилитатор,Спортна медицина,Съдов хирург,Токсиколог,УНГ,Уролог,Физиотерапевт,Хематолог (Клинична хематология),Хематолог (Трансфузионна хематология),Хирург,Хомеопат";
        }

        public class WorkHourConstants
        {
            public const string AllWorkingHours = "08:00,08:30,09:00,09:30,10:00,10:30,11:00,11:30,13:00,13:30,14:00,14:30,15:00,15:30,16:00,16:30";
        }

        public class ReviewConstants
        {
            public const int MinContent = 10;
            public const int MaxContent = 2500;
            public const int MinRating = 1;
            public const int MaxRating = 5;
        }

        public static class MessageConstant
        {
            public const string ErrorMessage = "ErrorMessage";
            public const string WarningMessage = "WarningMessage";
            public const string SuccessMessage = "SuccessMessage";
        }

        public static class ExeptionConstant
        {
            public const string DoctorNotExistExeptionMessage = "Doctor doesn't exist!";
            public const string UserNotExistExeptionMessage = "User doesn't exist!";
            public const string ExaminationNotExistExeptionMessage = "Examination doesn't exist!";
        }

        public static class PagingConstants
        {
            public const int CurrentPageConstant = 1;
            public const int ShowPerPageConstant = 6;
            public const int ShowDoctorPerPageConstant = 4;
        }

        public static class GuidIdsConstants
        {
            public const string DoctorGuidConstants = "4b95c2a0-314d-414d-a80a-db46ef2f810a,22081bf0-1049-45ba-a9b3-3171271f1341,4775e4ac-4930-4113-bb19-6ed94e12fa24,499be402-5520-453d-a17d-3a52ac6ad798,f5628f68-e883-4b6a-8c6c-2511314af5a1,c96d7a14-8865-43bc-b756-8a6ad16b3cf4,473d0775-d1d3-4439-940b-fe949652859f,97fde454-7892-40ab-acff-c641b14d1eab,221de519-48d4-41cd-befd-1b414b2fea57,f40725ef-50bd-4b7b-b2ab-df41d875781e,182466cf-4d18-4ba4-940c-71e8f445335c,17dcc03b-321f-4484-a96a-61f3b8fe6dc8,d5adc893-6e93-4b1f-9ce5-7105069e7a6c,734a6dcd-060c-4108-a184-84997a5da2d1,61f0536e-26ec-46cc-9386-1c7cb348f1e7,9c85bdfe-768b-43bc-bc3d-91d3565edd7a,5b0923f7-da08-4af1-a391-d0561a534a42,9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040,992d83f0-1439-40dc-95f4-5a708fd3c086,cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e,be158f8c-bc22-4469-b01c-b9e928499a05,4be5615e-0d14-4756-a090-bd157133f463";

            public const string DoctorUserGuidConstants = "9da9587f-e28e-4289-a559-7407d3ea34a5,79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e,f1221132-3b9f-4f33-9e4d-1514bc0221e8,da3da29d-5411-4750-a5c4-e4ae4e22965c,b922fbb1-e1e8-41c6-a903-931e1cd4b845,3f9592ad-6af3-4021-808f-39d7aa9246e9,0bbf2307-d024-44b4-917f-a52ab9ddc013,cf6e7092-584c-460d-9538-feee4a5b53d9,f142f846-dbe7-420e-bbce-4a9f83e36980,d3ba8e2c-1f0f-4879-86b0-372d1b0bc760,8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca,095da4be-9891-4cd9-a2ad-05dbbb0e2085,b67a1365-3902-4728-8c9f-05369b1556b7,f092f500-00e2-4544-952a-4cb91320558d,c8517d67-c0f3-4cb8-ac8c-96602aaad8bb,041639c2-fcd2-4899-a5c6-2025cbb3c1c7,c83d8295-ff6a-4644-a44a-c2bc294b220e,8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe,a8d60b9c-6bef-4eff-af47-bcce7daf311b,7c513995-bed0-4be3-b768-304cd697c3f9,cd25b1ea-70c5-47d2-9617-3b7d0e6bc788,734267e9-a59b-44c3-baee-7e52a2bd1c29";

            public const string AdministratorGuidConstants = "e0b65a18-1271-4146-a730-8e80a24cea78";
            public const string AdministratorUserGuidConstants = "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b";

            public const string LaborantGuidConstants = "fb454478-8b7c-48bd-86b4-a0b36bf261a2";
            public const string LaborantUserGuidConstants = "fb454478-8b7c-48bd-86b4-a0b36bf261a2";
        }
    }
}