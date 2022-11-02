using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenter.Infrastructure.Migrations
{
    public partial class CreateEntityAndSeedBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Egn",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOutOfCompany",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoinOnDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OutOnDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Representation",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SheduleId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsUserReviewedExamination = table.Column<bool>(type: "bit", nullable: false),
                    ReviewId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examinations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examinations_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHours_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07818aec-acbc-46be-a4ce-fa488f21ef58", "29ae2c36-aa9a-4fd6-90fc-ccd3d6812e25", "Doctor", "DOCTOR" },
                    { "0fda452a-966f-4a10-b7e1-da1034abd7c1", "e6bec775-f6cc-406f-b178-2f906e7d57e9", "Administrator", "ADMINISTRATOR" },
                    { "db294aa3-baad-44d7-aa51-239d0d10b82f", "6e892427-9681-4714-b379-0fba03d34202", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8de2e280-e984-46c0-be16-06762d94c477", 0, "fab3dccb-aa51-4df6-b9b0-d14ce54373c8", "User", "admin@mc-bg.com", false, "Ивайло", 1, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEHNstL52lUi/bI+/uc69ktkKHzqbWejNm+JusxTNkvFZxa74qG82Jmqv+zftm9iaGg==", "+359888888888", false, "Administrator", "c74aa4fc-5ad6-40e9-8432-f54437b2febb", false, "admin" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мъж" },
                    { 2, "Жена" },
                    { 3, "Не посочвам" }
                });

            migrationBuilder.InsertData(
                table: "Shedules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Първа смяна" },
                    { 2, "Втора смена" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Акушер-гинеколог" },
                    { 2, "Алерголог" },
                    { 3, "Алтернативна медицина" },
                    { 4, "Ангиолог" },
                    { 5, "Анестезиолог" },
                    { 6, "Боуен терапевт" },
                    { 7, "Вирусолог" },
                    { 8, "Вътрешни болести" },
                    { 9, "Гастроентеролог" },
                    { 10, "Гръден хирург" },
                    { 11, "Дерматолог" },
                    { 12, "Детски гастроентеролог" },
                    { 13, "Детски ендокринолог" },
                    { 14, "Детски кардиолог" },
                    { 15, "Детски невролог" },
                    { 16, "Детски нефролог" },
                    { 17, "Детски психиатър" },
                    { 18, "Детски пулмолог" },
                    { 19, "Детски ревматолог" },
                    { 20, "Детски хематолог" },
                    { 21, "Детски хирург" },
                    { 22, "Диетолог" },
                    { 23, "Ендодонт" },
                    { 24, "Ендокринолог" },
                    { 25, "Естетичен дерматолог" },
                    { 26, "Зъболекар (Стоматолог)" },
                    { 27, "Изследване" },
                    { 28, "Имплантолог" },
                    { 29, "Имунолог" },
                    { 30, "Инфекциозни болести" },
                    { 31, "Кардиолог" },
                    { 32, "Кардиохирург" },
                    { 33, "Кинезитерапевт" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 34, "Клинична лаборатория" },
                    { 35, "Коуч" },
                    { 36, "Лицево-челюстен хирург" },
                    { 37, "Логопед" },
                    { 38, "Лъчетерапевт" },
                    { 39, "Мамолог" },
                    { 40, "Манипулация" },
                    { 41, "Медицинска генетика" },
                    { 42, "Медицинска сестра" },
                    { 43, "Микробиолог" },
                    { 44, "Невролог" },
                    { 45, "Неврохирург" },
                    { 46, "Неонатолог" },
                    { 47, "Нефролог (Бъбречни болести)" },
                    { 48, "Образна диагностика" },
                    { 49, "бщопрактикуващ лекар" },
                    { 50, "Озонотерапевт" },
                    { 51, "Онколог" },
                    { 52, "Оптометрист (Очен оптик)" },
                    { 53, "Орален хирург" },
                    { 54, "Ортодонт" },
                    { 55, "Ортопед" },
                    { 56, "Отоневролог" },
                    { 57, "Офталмолог (Очен лекар)" },
                    { 58, "Паразитолог" },
                    { 59, "Пародонтолог" },
                    { 60, "Педиатър" },
                    { 61, "Пластичен хирург" },
                    { 62, "Подиатър (Болести на ходилото)" },
                    { 63, "Протетик" },
                    { 64, "Профилактични прегледи" },
                    { 65, "Психиатър" },
                    { 66, "Психолог" },
                    { 67, "Психотерапевт" },
                    { 68, "Пулмолог (Белодробни болести)" },
                    { 69, "Ревматолог" },
                    { 70, "Репродуктивна медицина" },
                    { 71, "Рехабилитатор" },
                    { 72, "Спортна медицина" },
                    { 73, "Съдов хирург" },
                    { 74, "Токсиколог" },
                    { 75, "УНГ" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 76, "Уролог" },
                    { 77, "Физиотерапевт" },
                    { 78, "Хематолог (Клинична хематология)" },
                    { 79, "Хематолог (Трансфузионна хематология)" },
                    { 80, "Хирург" },
                    { 81, "Хомеопат" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Discriminator", "Education", "Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Representation", "Role", "SecurityStamp", "SheduleId", "SpecialtyId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1246c4c6-0f47-45d3-b362-9304e56a7513", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "82fa9305-40f1-45cc-9a64-0824e42dc897", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153898", "m_blagoeva@mc-bg.com", false, "Мая", 1, false, "02.11.2022", "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", null, "AQAAAAEAACcQAAAAEMHq9jN6v0qt4lC17vcfWW/jjBL/qduhQCZotjPYWDRCmPstkhTFU+2J2FBHYSBqhw==", "+359888888105", false, "https://superdoc.bg/photos/doctors/large/Enm6h1TL88KLFBQzRqGsUkpASF81JIEAajqqoCwn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b1cf5242-2924-4551-b9c1-e2c2de10fee1", 2, 11, false, "m_blagoeva" },
                    { "22545bf3-672c-4087-aabc-005afedbc5f5", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "337ce5d3-d19e-46e3-83d2-b91a88a8a8a7", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150311", "b_petkova@mc-bg.com", false, "Бисерка", 1, false, "02.11.2022", "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", null, "AQAAAAEAACcQAAAAEMVrxy2dLxtvxjlC7w4t5UAqcP8Gj3phHNAyjzfAY5vitfV/GVBEdEDfyvezfwNbPw==", "+359888888102", false, "https://superdoc.bg/photos/doctors/large/l45aQMv1pMhcTfABGdxWEgnlCmTPFTfE94sPPuDs.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "6d990f92-5aeb-4e5c-8bf9-8b9afcb2f762", 1, 8, false, "b_petkova" },
                    { "2a544fd4-9774-46a8-ae0c-1aa047d68f56", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "6d50c8ba-3128-48d8-91f2-510c1bf2a185", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154153", "m_kalinkova@mc-bg.com", false, "Мария", 1, false, "02.11.2022", "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", null, "AQAAAAEAACcQAAAAEOviFwy+TFmGTpn+4iSvHZV5UGfrJuykWQP3uVP2aAk7zU5VQdhrotNNzAYSjSkVXQ==", "+359888888106", false, "https://superdoc.bg/photos/doctors/large/9oLkWDJZ3MlW0dzaOmCsjB3XXFecvaWhOW51E14f.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "91a7fb54-66dc-416c-a84e-b83fa668ee90", 1, 24, false, "m_kalinkova" },
                    { "382009d0-e59e-4f79-a192-b7190feecddf", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1199cdf1-cd8b-40cc-9d54-7ef55f2e96f5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "s_atanasova@mc-bg.com", false, "Стела", 1, false, "02.11.2022", "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", null, "AQAAAAEAACcQAAAAENyci4nT71TRKp0a78Kb/TaU2DWmrOQnRF1FTcAvEgCiRyjZrGgYdevBCLsofXjs1g==", "+359888888110", false, "https://superdoc.bg/photos/doctors/large/6iM4XryT7EmD57gFNzB0lcqp4pfEMlOXwYsDcuv5.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "1b64593b-4782-4064-96f3-d5382173bb03", 1, 44, false, "s_atanasova" },
                    { "3bac4325-7498-403e-846a-65cec92462e4", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "060c344b-fe2f-42ce-9f83-3fb2a8e59f8b", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156161", "s_tochev@mc-bg.com", false, "Сотир", 2, false, "02.11.2022", "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", null, "AQAAAAEAACcQAAAAEOT/BJYPuf6MRQ4Y5QLncsP3RoxFccn9YkGt6HDbuY+kGfiI5i9DqsvN5AxYeCdybA==", "+359888888109", false, "https://superdoc.bg/photos/doctors/large/tm0Q6jEA4Zf85mR2cCEoYjNckLlekPrw5bL0GHH1.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8a554756-2760-4ad0-8937-325a2febedc5", 2, 31, false, "s_tochev" },
                    { "41c5c322-a733-44d2-a715-6db4efde0c9b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1c026c69-a34a-4451-bfff-b958f02503ff", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155925", "d_georgiev@mc-bg.com", false, "Димитър", 2, false, "02.11.2022", "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", null, "AQAAAAEAACcQAAAAEABusmWkT9ZK4JwjCL7tFvDuyz/qY8ah64dtyhvOHQATZOMq6Fo8k+CrLOUpujlYNg==", "+359888888107", false, "https://superdoc.bg/photos/doctors/large/zCDqlTJtNK9oicEpDEjON6JQozN57PchSvqOUoqL.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "a353e131-636b-4247-9ea8-49e30c9505d9", 2, 24, false, "d_georgiev" },
                    { "875d2539-83f9-4b33-89d9-ef65f5a58ae3", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1cb37b0f-0d86-49f9-b2c1-4ca7693d770f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", "m_vuldjev@mc-bg.com", false, "Михаил", 2, false, "02.11.2022", "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", null, "AQAAAAEAACcQAAAAEKfj89aCa/kp4+70PZxCNhTirV/i3LackJJP0pwSC+xBDN56t+Ut9XMkUhAbdpE4+w==", "+359888888112", false, "https://superdoc.bg/photos/doctors/large/cbaXljvO1Z6PTLSLRyIobdw2rtISqC9d7WeelHO3.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "7f59af37-5fa3-4b80-b407-33e08d16bad7", 1, 55, false, "m_vuldjev" },
                    { "88576625-1c28-4966-90b4-85463efa91d0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "253b6b0d-e22f-421e-b6f1-5b6620dd4edb", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", "r_uzunova@mc-bg.com", false, "Росица", 1, false, "02.11.2022", "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", null, "AQAAAAEAACcQAAAAEPLE4QDU5dvbwB1zma1Zi5CEPzEPpk6VxrR9UNNkw0+kCwBqHGQ6dNWRCyeWzkKqeg==", "+359888888120", false, "https://superdoc.bg/photos/doctors/large/AdMojtPGEnem4J2MjHZlE5aH5Ykvm007PjfvAgwe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "65f7298b-f455-4fc5-8437-ef65c2bf257e", 1, 77, false, "r_uzunova" },
                    { "92822635-fd4c-4d23-92dc-18fab4b93eb2", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e2b41fc2-6d37-4576-952e-6d6ec986e2be", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512157954", "k_stoicheva@mc-bg.com", false, "Катина", 1, false, "02.11.2022", "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", null, "AQAAAAEAACcQAAAAEBNLouRy9QiS7q6UTBRlQ6iSIp8B9F80WMmApVjZ3fhPGZm2xpjsthbyTTKoQBu03A==", "+359888888118", false, "https://superdoc.bg/photos/doctors/large/DkyVrk4ptD2UAPgywGJp9Sk4ab2mowCTJnWgC7uP.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "85f6338b-298b-49dd-911e-661caf2df2d9", 1, 76, false, "k_stoicheva" },
                    { "98a8d015-20bc-4387-8df6-d6686c644092", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1ab253f8-32fa-4ab0-9ecb-223b27b15e0f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", "h_hristov@mc-bg.com", false, "Христо", 2, false, "02.11.2022", "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", null, "AQAAAAEAACcQAAAAEIIdUkuutXWKC576j5Pke40MkNzPkqcob3t7Kllz2PIbs+mxn6ABGh8nGXri9vUMBA==", "+359888888113", false, "https://superdoc.bg/photos/doctors/large/2dmSQ4sBxuWwMAOGotyikgUYHTD3VB7u4r8t17Ys.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "d2ac539d-4cb7-42a6-8330-6a498aac749c", 2, 55, false, "h_hristov" },
                    { "a27ba3c1-0c52-4cd1-83a1-9b24c47ca947", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "d8274a78-aafe-4a04-a25c-48114e0a6232", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150230", "m_monastirska@mc-bg.com", false, "Маргарита", 1, false, "02.11.2022", "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", null, "AQAAAAEAACcQAAAAEE4BRQWTBOC5htBunpACGemHG5YxKMy2YjmXwgMKGF/1l0bseAq6j2z4TntSMi2jpQ==", "+359888888100", false, "https://superdoc.bg/photos/doctors/large/rwirLXB6bNPuWQCeOWgM9c96rUFbsxnxIonXi6Gf.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b5cc726e-721d-465c-bfd1-4d1b18f702f9", 1, 1, false, "m_monastirska" },
                    { "b0a30c66-da2e-427a-9767-0800bea6e37b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "afb8a88f-ec49-4ca4-ac8f-f3057fc6a9c3", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154657", "a_tomova@mc-bg.com", false, "Антония", 1, false, "02.11.2022", "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", null, "AQAAAAEAACcQAAAAEPj7jXJwCjR29gmvVPFME6ZUISrnLWNYfxF/UtGeshal0M7GN5qAkKM95MRKchYHIw==", "+359888888114", false, "https://superdoc.bg/photos/doctors/large/2iIY3v12meJbiYoNQhB4yDBmr6Ff2NYtxIFYiIvK.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "330f7255-e493-436a-9951-cedf82ba0915", 1, 60, false, "a_tomova" },
                    { "b404710e-8ce0-42d7-a4cf-abb3d1ca0b38", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "840bf73e-c1cd-4834-9883-765c1f7309c7", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", "i_belcheva@mc-bg.com", false, "Ирина", 1, false, "02.11.2022", "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", null, "AQAAAAEAACcQAAAAEFfdV1MrgqHWKa5pMVbl+PhHDjGCbIVrb/CV7hrYZMG6c8Yl5qBb0lB4Wb83rsgaMA==", "+359888888121", false, "https://superdoc.bg/photos/doctors/large/LcJF7zG1uWkPqYfBDOAGFqlpA6AVoJOahfaFaRoe.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "d08806d9-2282-4a9d-85e5-53bb638fa712", 2, 77, false, "i_belcheva" },
                    { "b4e75680-3c02-42d8-a8d9-92f8080096ed", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "04c7bb89-456f-487e-af99-1843b55197e4", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", "s_slavchev@mc-bg.com", false, "Станислав", 2, false, "02.11.2022", "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", null, "AQAAAAEAACcQAAAAEIIh3dWoDZMnDc+ctup0NbrOUlmEpqAyOHGQYUSjA1tQabvVvsrKwxYMR2z1HFuhWg==", "+359888888101", false, "https://superdoc.bg/photos/doctors/large/rG5hcfjVRagmEoVVwN8afiTTrHKpU2nTKnRbOWr6.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "be71bfc9-b538-4dea-939f-041841cdfe29", 2, 1, false, "s_slavchev" },
                    { "bbbdd041-8e65-4d9d-aec1-a288597a7067", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e678f02d-3b95-4162-b129-0eaf4973c758", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152802", "g_kuchukov@mc-bg.com", false, "Георги", 2, false, "02.11.2022", "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", null, "AQAAAAEAACcQAAAAEJtzWEaMh3Uff7NjkNyBgWpf2PGeVPS+2I7yfeZsrJPzxHV2M/L3fH/MLHD64zVcNw==", "+359888888117", false, "https://superdoc.bg/photos/doctors/large/gNyJ8eWCA6kTBdW0bXVw4nboWDXzFeIYQ1TFwPo7.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9eaa4929-98e7-4fa3-a9f2-f3bb26e28bd4", 2, 75, false, "g_kuchukov" },
                    { "be39d73e-6b03-4214-9d33-fb0e1fd16f24", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1111b196-40b3-41ff-920a-1829815dda4b", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512151004", "t_stoev@mc-bg.com", false, "Тодор", 2, false, "02.11.2022", "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", null, "AQAAAAEAACcQAAAAEJzSn5mqBghpvL4gjps7fG7MZW5WEbiZKSYoO6yZbbG7NXbo2UDDIy6Fhns0ZQSPBA==", "+359888888104", false, "https://superdoc.bg/photos/doctors/large/gTvSgfoBMzCm1rEIuxP7zPUVaWXrz92u6zlaESPk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "29a2f8bc-33e8-4b69-9509-b2e68f4c5787", 1, 11, false, "t_stoev" },
                    { "cc73c2be-631a-4085-94e5-9982595d2eb9", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "d4bfda6a-3050-4ab3-b482-f9ce481ca476", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153671", "m_velikova@mc-bg.com", false, "Мими", 1, false, "02.11.2022", "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", null, "AQAAAAEAACcQAAAAENhNjgiOGLYQ8E0LhesgHBOo1BfzgLwxCnQc7P01DK9mkH4ImW6o68IbkzBOyAErJQ==", "+359888888103", false, "https://superdoc.bg/photos/doctors/large/U0ppKpWfMPGebFNhwhDjFLoKZ2UL3hg26IDn1GPo.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "e2668188-3b6e-442b-9e8d-36b873f47a55", 2, 8, false, "m_velikova" },
                    { "d71fac1d-e0bf-49ef-a4f6-e692b3fe8a62", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "8c4aff92-3eea-48b2-9b38-7499c2d3d0a5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156747", "r_ikonomov@mc-bg.com", false, "Росен", 2, false, "02.11.2022", "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", null, "AQAAAAEAACcQAAAAEFd0t2d3hHhdxRM7V7Ns2sBVozWQBGunWy+auj7mXJwYNthqiOurvWN8gzCDGfesWg==", "+359888888111", false, "https://superdoc.bg/photos/doctors/large/eco5fuHqM1fIXYMzN9X9nvQH8f39RNdTbsOoFk40.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "2a5e4b54-9c9d-4b36-a890-3433b438e6d3", 2, 44, false, "r_ikonomov" },
                    { "f07cc89a-0f96-4f18-ac96-24523d4e45ae", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c2d1e6c2-f849-476c-8f89-651000a71efc", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154750", "k_atanasova@mc-bg.com", false, "Кристина", 1, false, "02.11.2022", "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", null, "AQAAAAEAACcQAAAAEI3C9AZ4ZVsH1pcCAv+wIBG6Njrl8qWpaEX5PhP94XT+WYWLXiATvrW4+bbxz23qkg==", "+359888888116", false, "https://superdoc.bg/photos/doctors/large/pStJIXh9QsqC47STGxxsZ9bh3pcS1oddaBF6HR6q.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "df0f99e3-b819-4380-bfaf-25e11c2a4b71", 1, 75, false, "k_atanasova" },
                    { "f77e9316-e34e-4c9c-83cd-9c32b77a4179", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "35c46d8d-47e8-458a-8554-4874eaf8b21d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155041", "n_paskov@mc-bg.com", false, "Николай", 2, false, "02.11.2022", "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", null, "AQAAAAEAACcQAAAAEEebUFR9d+Yy9CPTSs/wNR2MVvfEVS6GhWTS8ZhFeETRuRl7egHr+RrD4phPetwgNA==", "+359888888119", false, "https://superdoc.bg/photos/doctors/large/KHFCpB4AiRP1yZBJm5tSUeukKgA1PBmFVZs2CfgF.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b44207c8-4182-478c-9a9b-0eef705c36c3", 2, 76, false, "n_paskov" },
                    { "fa943fbf-9d3b-4107-b831-883312eb3bbb", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "a3f282b6-1e38-4e9b-a23c-977f4492f634", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "r_ruseva@mc-bg.com", false, "Ралица", 1, false, "02.11.2022", "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", null, "AQAAAAEAACcQAAAAEBqnGgHbInHI1rJPQc3iL4mipQFH/JXJRD0hqXdu6Y0uG2eEv+aMrslEswzPFoUC+Q==", "+359888888108", false, "https://superdoc.bg/photos/doctors/large/V1gasguBhI3ii3C1ryit4TuCSercdF5ynvBsxNpd.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "91dfac45-5057-47da-9942-07cacdfb0dee", 1, 31, false, "r_ruseva" },
                    { "fe24ef55-e90e-4355-aa9f-e673b32ee2e1", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "56169bfc-b0cd-427d-bfee-a6e36442a585", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154739", "k_moskova@mc-bg.com", false, "Катерина", 1, false, "02.11.2022", "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", null, "AQAAAAEAACcQAAAAEOWQek6+99n8NoivypxbOwHmlwk3Q4X0frWeVf6sV7XoPhvQc02iBhmq+sbnQ6RUbg==", "+359888888115", false, "https://superdoc.bg/photos/doctors/large/TZc5jzdK6wotBMXwSYmKe5aPTV2FSiIOC9BEas4n.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "976a77e7-5431-4f76-93de-f2f59ebde72e", 2, 60, false, "k_moskova" }
                });

            migrationBuilder.InsertData(
                table: "WorkHours",
                columns: new[] { "Id", "Hour", "SheduleId" },
                values: new object[,]
                {
                    { 1, "08:00", 1 },
                    { 2, "08:30", 1 },
                    { 3, "09:00", 1 },
                    { 4, "09:30", 1 },
                    { 5, "10:00", 1 },
                    { 6, "10:30", 1 },
                    { 7, "11:00", 1 },
                    { 8, "11:30", 1 },
                    { 9, "13:00", 2 },
                    { 10, "13:30", 2 },
                    { 11, "14:00", 2 },
                    { 12, "14:30", 2 },
                    { 13, "15:00", 2 },
                    { 14, "15:30", 2 },
                    { 15, "16:00", 2 },
                    { 16, "16:30", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SheduleId",
                table: "AspNetUsers",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ReviewId",
                table: "Examinations",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_UserId",
                table: "Examinations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_SheduleId",
                table: "WorkHours",
                column: "SheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shedules_SheduleId",
                table: "AspNetUsers",
                column: "SheduleId",
                principalTable: "Shedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shedules_SheduleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SheduleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07818aec-acbc-46be-a4ce-fa488f21ef58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fda452a-966f-4a10-b7e1-da1034abd7c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db294aa3-baad-44d7-aa51-239d0d10b82f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1246c4c6-0f47-45d3-b362-9304e56a7513");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22545bf3-672c-4087-aabc-005afedbc5f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a544fd4-9774-46a8-ae0c-1aa047d68f56");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "382009d0-e59e-4f79-a192-b7190feecddf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bac4325-7498-403e-846a-65cec92462e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41c5c322-a733-44d2-a715-6db4efde0c9b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "875d2539-83f9-4b33-89d9-ef65f5a58ae3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88576625-1c28-4966-90b4-85463efa91d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92822635-fd4c-4d23-92dc-18fab4b93eb2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98a8d015-20bc-4387-8df6-d6686c644092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a27ba3c1-0c52-4cd1-83a1-9b24c47ca947");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0a30c66-da2e-427a-9767-0800bea6e37b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b404710e-8ce0-42d7-a4cf-abb3d1ca0b38");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4e75680-3c02-42d8-a8d9-92f8080096ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbbdd041-8e65-4d9d-aec1-a288597a7067");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be39d73e-6b03-4214-9d33-fb0e1fd16f24");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc73c2be-631a-4085-94e5-9982595d2eb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d71fac1d-e0bf-49ef-a4f6-e692b3fe8a62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f07cc89a-0f96-4f18-ac96-24523d4e45ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f77e9316-e34e-4c9c-83cd-9c32b77a4179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa943fbf-9d3b-4107-b831-883312eb3bbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe24ef55-e90e-4355-aa9f-e673b32ee2e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8de2e280-e984-46c0-be16-06762d94c477");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Egn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsOutOfCompany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JoinOnDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OutOnDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Representation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SheduleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "AspNetUsers");
        }
    }
}
