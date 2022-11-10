namespace MedicalCenter.Infrastructure.Data.Global
{
    public class DataConstants
    {
        public static class RoleConstants
        {
            public const string DoctorRole = "Doctor";
            public const string AdministratorRole = "Administrator";
            public const string UserRole = "User";
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

            public const string RequiredLogin = "Потребителско име/Email е задължително.";
            public const string RequiredUsername = "Полето име е задължително.";
            public const string RequiredEmail = "Email е задължителен.";
            public const string RequiredPassword = "Парола е задължителна.";
            public const string RequiredConfirmPassword = "Повтори парола е задължителна.";
            public const string RequiredFirstName = "Име е задължително.";
            public const string RequiredLastName = "Фамилия е задължителна.";
            public const string RequiredPhoneNumber = "Телефон е задължителен.";
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
            public const string DoctorsData = "Маргарита Монастирска https://superdoc.bg/photos/doctors/large/rwirLXB6bNPuWQCeOWgM9c96rUFbsxnxIonXi6Gf.jpg m_monastirska 7512150230 1 Станислав Славчев https://superdoc.bg/photos/doctors/large/rG5hcfjVRagmEoVVwN8afiTTrHKpU2nTKnRbOWr6.jpg s_slavchev 7512150522 1 Бисерка Петкова https://superdoc.bg/photos/doctors/large/l45aQMv1pMhcTfABGdxWEgnlCmTPFTfE94sPPuDs.jpeg b_petkova 7512150311 8 Мими Великова https://superdoc.bg/photos/doctors/large/U0ppKpWfMPGebFNhwhDjFLoKZ2UL3hg26IDn1GPo.jpg m_velikova 7512153671 8 Тодор Стоев https://superdoc.bg/photos/doctors/large/gTvSgfoBMzCm1rEIuxP7zPUVaWXrz92u6zlaESPk.jpg t_stoev 7512151004 11 Мая Благоева https://superdoc.bg/photos/doctors/large/Enm6h1TL88KLFBQzRqGsUkpASF81JIEAajqqoCwn.jpg m_blagoeva 7512153898 11 Мария Калинкова https://superdoc.bg/photos/doctors/large/9oLkWDJZ3MlW0dzaOmCsjB3XXFecvaWhOW51E14f.jpg m_kalinkova 7512154153 24 Димитър Георгиев https://superdoc.bg/photos/doctors/large/zCDqlTJtNK9oicEpDEjON6JQozN57PchSvqOUoqL.jpg d_georgiev 7512155925 24 Ралица Русева https://superdoc.bg/photos/doctors/large/V1gasguBhI3ii3C1ryit4TuCSercdF5ynvBsxNpd.jpg r_ruseva 7512154338 31 Сотир Точев https://superdoc.bg/photos/doctors/large/tm0Q6jEA4Zf85mR2cCEoYjNckLlekPrw5bL0GHH1.jpg s_tochev 7512156161 31 Стела Атанасова https://superdoc.bg/photos/doctors/large/6iM4XryT7EmD57gFNzB0lcqp4pfEMlOXwYsDcuv5.jpg s_atanasova 7512154338 44 Росен Икономов https://superdoc.bg/photos/doctors/large/eco5fuHqM1fIXYMzN9X9nvQH8f39RNdTbsOoFk40.jpeg r_ikonomov 7512156747 44 Михаил Вулджев https://superdoc.bg/photos/doctors/large/cbaXljvO1Z6PTLSLRyIobdw2rtISqC9d7WeelHO3.jpg m_vuldjev 7512152504 55 Христо Христов https://superdoc.bg/photos/doctors/large/2dmSQ4sBxuWwMAOGotyikgUYHTD3VB7u4r8t17Ys.jpg h_hristov 7512155144 55 Антония Томова https://superdoc.bg/photos/doctors/large/2iIY3v12meJbiYoNQhB4yDBmr6Ff2NYtxIFYiIvK.jpg a_tomova 7512154657 60 Катерина Москова https://superdoc.bg/photos/doctors/large/TZc5jzdK6wotBMXwSYmKe5aPTV2FSiIOC9BEas4n.jpg k_moskova 7512154739 60 Кристина Атанасова https://superdoc.bg/photos/doctors/large/pStJIXh9QsqC47STGxxsZ9bh3pcS1oddaBF6HR6q.jpg k_atanasova 7512154750 75 Георги Кичуков https://superdoc.bg/photos/doctors/large/gNyJ8eWCA6kTBdW0bXVw4nboWDXzFeIYQ1TFwPo7.jpg g_kuchukov 7512152802 75 Катина Стойчева https://superdoc.bg/photos/doctors/large/DkyVrk4ptD2UAPgywGJp9Sk4ab2mowCTJnWgC7uP.jpg k_stoicheva 7512157954 76 Николай Пасков https://superdoc.bg/photos/doctors/large/KHFCpB4AiRP1yZBJm5tSUeukKgA1PBmFVZs2CfgF.jpg n_paskov 7512155041 76 Росица Узунова https://superdoc.bg/photos/doctors/large/AdMojtPGEnem4J2MjHZlE5aH5Ykvm007PjfvAgwe.jpg r_uzunova 7512158631 77 Ирина Белчева https://superdoc.bg/photos/doctors/large/LcJF7zG1uWkPqYfBDOAGFqlpA6AVoJOahfaFaRoe.jpeg i_belcheva 7512158992 77";
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
    }
}