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
    }
}