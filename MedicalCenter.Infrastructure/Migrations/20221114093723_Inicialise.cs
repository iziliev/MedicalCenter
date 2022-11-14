using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCenter.Infrastructure.Migrations
{
    public partial class Inicialise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyId = table.Column<int>(type: "int", nullable: true),
                    Representation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    IsOutOfCompany = table.Column<bool>(type: "bit", nullable: true),
                    OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SheduleId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ReviewId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SheduleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsUserReviewedExamination = table.Column<bool>(type: "bit", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Examinations_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "b5b2d150-37b6-49ef-9ec7-d4a70fb5f0bf", "Doctor", "DOCTOR" },
                    { "87b48815-72fb-45c2-b85a-40a709cf3889", "4e7746ec-b4a8-4ce4-ad96-9373187c7281", "User", "USER" },
                    { "a099b528-2a4c-41ba-b388-5897d415158d", "faeb44cb-a5fb-41cd-9510-7b5d28518745", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8312eaa0-fbff-4545-86fe-5b531b821299", 0, "5fd958ec-296b-43b7-9f9e-944e365cdf4a", "User", "admin@mc-bg.com", false, "Ивайло", 1, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEEehQQaUlCjpt1BknJ7Y+8Kra1BqyM3QW86vL3InufYNJYn9dniOkWwPYDcdHuxTFw==", "+359888888888", false, "Administrator", "b6d27684-b885-4963-bcb6-b228930db92d", false, "admin" });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a099b528-2a4c-41ba-b388-5897d415158d", "8312eaa0-fbff-4545-86fe-5b531b821299" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Discriminator", "Education", "Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Representation", "Role", "SecurityStamp", "SheduleId", "SpecialtyId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1f616074-4936-4cb4-a910-fb7d73bb6c41", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "20f80cdb-3584-4e35-9417-af2919da542f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512151004", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "14.11.2022", "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", null, "AQAAAAEAACcQAAAAEKFBVxERAiipgjmaUXx8Sjro6IiRvzIOgbM8cceZaGX/rbE739yxFwHTiepjNbmpPg==", "+359888888104", false, "https://superdoc.bg/photos/doctors/large/gTvSgfoBMzCm1rEIuxP7zPUVaWXrz92u6zlaESPk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "494db656-cbcb-4e39-b74b-754d16dc4c74", 1, 11, false, "t_stoev" },
                    { "25102305-973f-4d8e-96aa-8b01385fe976", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "460b97c9-1073-4be1-9579-6a67c2bf9a78", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "14.11.2022", "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", null, "AQAAAAEAACcQAAAAENWqh6R9p+9LaWfNDzQNjGk3KkLYa3zIvKzTJCf+AnYqhcEwkjSkuAdSdt9cvl1qRQ==", "+359888888112", false, "https://superdoc.bg/photos/doctors/large/cbaXljvO1Z6PTLSLRyIobdw2rtISqC9d7WeelHO3.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b8fffe70-5515-451b-9041-a7837b857000", 1, 55, false, "m_vuldjev" },
                    { "3f397c5d-bfca-4571-bb54-e92f00ed8d1a", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "f87e10d3-cb1b-4468-b84c-1515a1e50c4e", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153898", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "14.11.2022", "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", null, "AQAAAAEAACcQAAAAEAgiZz9oyUxEBMPxTqjhvRDAh7Lsf2hgDkNvCek/mp6NGEHxHpPVhrvBmRP0Z5YLmg==", "+359888888105", false, "https://superdoc.bg/photos/doctors/large/Enm6h1TL88KLFBQzRqGsUkpASF81JIEAajqqoCwn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9dbd4809-f24d-4ff4-be3b-694598371c12", 2, 11, false, "m_blagoeva" },
                    { "64d7e693-f160-427d-a146-6490b7bcc802", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e1a1d911-9b32-4c08-852e-e583999ed704", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "14.11.2022", "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", null, "AQAAAAEAACcQAAAAECtBF6CTvkjRPgKGXu9rOL4iZ/je6npg5txY8G5fgCCfM0LEBZv620BPBXSKtpTK/g==", "+359888888120", false, "https://superdoc.bg/photos/doctors/large/AdMojtPGEnem4J2MjHZlE5aH5Ykvm007PjfvAgwe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "4bfaba50-5386-481f-b7bc-c140dcefe181", 1, 77, false, "r_uzunova" },
                    { "6905e207-eaad-40ca-91fc-b4c62e1852ec", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "04e60144-0af3-428d-b969-df7a48120ab5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156161", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "14.11.2022", "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", null, "AQAAAAEAACcQAAAAEGZrr1xZRbaWEWkNwsp6AdXKh01bhxMSEp5AfqwozCFnYENyn+czv1Zg0Gqozvrmlg==", "+359888888109", false, "https://superdoc.bg/photos/doctors/large/tm0Q6jEA4Zf85mR2cCEoYjNckLlekPrw5bL0GHH1.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "4a23e8fa-14c5-43d8-a4ee-0164ca90ed63", 2, 31, false, "s_tochev" },
                    { "7363c14b-1c76-44a0-873f-e184bf9b2d06", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "aee79bd3-07a9-4f9d-a223-41a083e333df", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "14.11.2022", "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", null, "AQAAAAEAACcQAAAAECn9pOVpmB0zfZheb8fz1+LzMxz0AhGYMmMHyZuodZjH61QeIVEbae+Kvy9B0EsA9w==", "+359888888121", false, "https://superdoc.bg/photos/doctors/large/LcJF7zG1uWkPqYfBDOAGFqlpA6AVoJOahfaFaRoe.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8912049f-8f40-4ffd-b875-063d16670917", 2, 77, false, "i_belcheva" },
                    { "789f9d0e-c95c-470e-a387-05af8ee96afa", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1d51be98-0807-4dae-9e03-6703ce13e65f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154739", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "14.11.2022", "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", null, "AQAAAAEAACcQAAAAEBivsv0RrFTB8B78beoh2D5LiCaBwPeaUVVvCjwQh9jcKjLhaBD/TM2DGVssDn/91Q==", "+359888888115", false, "https://superdoc.bg/photos/doctors/large/TZc5jzdK6wotBMXwSYmKe5aPTV2FSiIOC9BEas4n.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "6b43e55f-277d-49c9-b6ef-aeb4a3197883", 2, 60, false, "k_moskova" },
                    { "7acb8ea9-8560-4e3a-9b00-c690d71dbe1c", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "322bafd3-1af1-44ca-a1fe-a6828948884d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152802", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "14.11.2022", "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", null, "AQAAAAEAACcQAAAAEOPB8bV8VokTwWbhWjSIVp+Tfvad6jhy3HNUU9LkHD804OA2visqJVZWU3dFiXDDKQ==", "+359888888117", false, "https://superdoc.bg/photos/doctors/large/gNyJ8eWCA6kTBdW0bXVw4nboWDXzFeIYQ1TFwPo7.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "85d7d89c-4006-487a-b2d7-9d8e37021592", 2, 75, false, "g_kuchukov" },
                    { "7f045d0f-6236-481d-9b27-80f29c98fc61", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "0a89ba8b-08fb-4dae-a67b-20ac3927ab78", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", "h_hristov@mc-bg.com", false, "Христо", 1, false, "14.11.2022", "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", null, "AQAAAAEAACcQAAAAEErHL/59PQzIk+f1MA0ihpdLCRR/rcfdZYX8BUFAiQ3DxW7nNwcUqmSGdqz1nYeOOA==", "+359888888113", false, "https://superdoc.bg/photos/doctors/large/2dmSQ4sBxuWwMAOGotyikgUYHTD3VB7u4r8t17Ys.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "f1b54dde-994d-4d22-b729-83674c3a2fe9", 2, 55, false, "h_hristov" },
                    { "9ea3ade9-16c4-43ac-9f04-bc91e5743c1c", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e3d65815-ac73-4c7a-afb1-e818d114fd05", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155925", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "14.11.2022", "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", null, "AQAAAAEAACcQAAAAEEYNRFQo2p+VgqhiVttcNL8UWxI9NWqiWZ26JcmfHrugicS+oWYXCSGS3sWfso2Z7g==", "+359888888107", false, "https://superdoc.bg/photos/doctors/large/zCDqlTJtNK9oicEpDEjON6JQozN57PchSvqOUoqL.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "80c25546-b12a-4acd-a71a-1c7d80a65184", 2, 24, false, "d_georgiev" },
                    { "b48d58c7-30ce-4cff-9604-46a4e26a697e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "d78d831b-d1a4-495e-a34e-1449fc7e65d6", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "14.11.2022", "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", null, "AQAAAAEAACcQAAAAED/fI4eMPpWsJV89YuaQdvStH3KNaAV9c+/YYvW6mI0rfzsGQJqs9vN6DdIoh0dTLA==", "+359888888101", false, "https://superdoc.bg/photos/doctors/large/rG5hcfjVRagmEoVVwN8afiTTrHKpU2nTKnRbOWr6.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "94f7a09b-b514-4618-a32f-a4edca43f40e", 2, 1, false, "s_slavchev" },
                    { "b95298cb-4eff-4d65-8d7d-6b2653dad5ff", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "9f570b3b-b978-43b2-a4b2-e3a33bf23c18", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154750", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "14.11.2022", "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", null, "AQAAAAEAACcQAAAAELh8zwNEfX/ntd36ykqCSEF1xqV1B/0Z00gB+lA2gaF/OQ1EpZRl1EquXHDfOo9zzw==", "+359888888116", false, "https://superdoc.bg/photos/doctors/large/pStJIXh9QsqC47STGxxsZ9bh3pcS1oddaBF6HR6q.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "36a9dfb4-8f2b-4522-b34e-93e8712567e4", 1, 75, false, "k_atanasova" },
                    { "b9ce6413-5e7f-49c3-a767-29f70a6bc93d", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "f3901a52-ff6d-4891-bc23-451eb12ce812", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "14.11.2022", "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", null, "AQAAAAEAACcQAAAAEI4OZYM/5VyousYSBIfM3DJFpHwZXJ4SXirNLnhHzz34emrJg+7sM4reiqBghIb42A==", "+359888888110", false, "https://superdoc.bg/photos/doctors/large/6iM4XryT7EmD57gFNzB0lcqp4pfEMlOXwYsDcuv5.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "dbc19941-c944-4000-8852-ee0a39544fa1", 1, 44, false, "s_atanasova" },
                    { "b9d2a5da-d6b8-4d23-8c34-bea0e69301fc", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "ab502a11-9619-49f1-8488-4aab4fb141d2", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153671", "m_velikova@mc-bg.com", false, "Мими", 2, false, "14.11.2022", "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", null, "AQAAAAEAACcQAAAAEEqQnibaAeGyx7fAGK3j8KXirt1n21rV/j9L/3B0DjZIXoFSI2vgR5/ATqeNpo0BwA==", "+359888888103", false, "https://superdoc.bg/photos/doctors/large/U0ppKpWfMPGebFNhwhDjFLoKZ2UL3hg26IDn1GPo.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8a2fdf3c-086d-4649-aafe-a21480739c92", 2, 8, false, "m_velikova" },
                    { "ba9bac9f-2d06-40d8-b03f-18aecbd45f13", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e67d916e-f05a-41c5-b4f8-29e40121358e", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "14.11.2022", "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", null, "AQAAAAEAACcQAAAAEEzLkHlKS4DrdQObFwrDnMq9D5dlRqOAj0PXkBTn2RlvibA945NjAAyqEiCTNC6xbQ==", "+359888888108", false, "https://superdoc.bg/photos/doctors/large/V1gasguBhI3ii3C1ryit4TuCSercdF5ynvBsxNpd.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "26cea5d7-3bb6-44ed-8ddf-0ea1e920dbaf", 1, 31, false, "r_ruseva" },
                    { "bf2a6d4e-d947-4319-987d-6a60ad38dfb3", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "52d696b1-714c-4a19-80a5-717dd98bf130", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150230", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "14.11.2022", "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", null, "AQAAAAEAACcQAAAAEPhKDzMsMiMENOLcRdDK10hlr0K0nsutmzDoOn4DkPYLzP1PWt5BEqrGnYR4X8Yvyg==", "+359888888100", false, "https://superdoc.bg/photos/doctors/large/rwirLXB6bNPuWQCeOWgM9c96rUFbsxnxIonXi6Gf.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "88b817ff-f98d-4e6b-95b0-69118da125a2", 1, 1, false, "m_monastirska" },
                    { "c9f8a712-fa3b-4f1c-862c-e3a07fee8668", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "7e52ed9a-a543-4829-9160-49f21b8c9cbe", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150311", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "14.11.2022", "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", null, "AQAAAAEAACcQAAAAELJ/uQJMNOIgOArA0NGyuWpblPKYchyO1hcGot1gihYktMbufVDIjIGRet8jfCSYzQ==", "+359888888102", false, "https://superdoc.bg/photos/doctors/large/l45aQMv1pMhcTfABGdxWEgnlCmTPFTfE94sPPuDs.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "f67a6f22-d3ff-4979-bec4-c468a785075b", 1, 8, false, "b_petkova" },
                    { "cc84234a-fa21-4db7-b36d-e6de13d4d33b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "f7eaa05c-2fe0-46e5-8725-7d710ebaa8fe", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155041", "n_paskov@mc-bg.com", false, "Николай", 1, false, "14.11.2022", "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", null, "AQAAAAEAACcQAAAAEKEByGuucl41F5Ht5mIWUKvhscE7M+WaNXHOOiGsFVtYC8nOOxQyDeMb5yBPjj56rw==", "+359888888119", false, "https://superdoc.bg/photos/doctors/large/KHFCpB4AiRP1yZBJm5tSUeukKgA1PBmFVZs2CfgF.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "c796c623-5eb7-4ecf-8077-6f608818779c", 2, 76, false, "n_paskov" },
                    { "cfe1f878-a27f-4aef-b8e9-1dca114878e0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "5ad0d4af-7d1d-4903-959c-08ca6ee0b985", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154153", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "14.11.2022", "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", null, "AQAAAAEAACcQAAAAEMbCamPLRUQQjDLfAQyLzVEKDy27Z17sAocpZXSHr3ihIl1Kl2ED4ar5R7A67Ls/8Q==", "+359888888106", false, "https://superdoc.bg/photos/doctors/large/9oLkWDJZ3MlW0dzaOmCsjB3XXFecvaWhOW51E14f.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "198c319d-6ba4-4556-80ba-8ff37c2657e0", 1, 24, false, "m_kalinkova" },
                    { "d34a494a-8fbe-4405-ae19-7490ffbb58f1", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4bfc53dc-db2b-4ae1-9e3f-c33c98db6315", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512157954", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "14.11.2022", "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", null, "AQAAAAEAACcQAAAAEKPEokwomBmEIcd6G7b/ppd9IZoOSeulhf3Crh5cwsW8IT2Tx2+76u7pIdW7pBsx6A==", "+359888888118", false, "https://superdoc.bg/photos/doctors/large/DkyVrk4ptD2UAPgywGJp9Sk4ab2mowCTJnWgC7uP.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "c75376cd-0a4b-455a-81ee-98a281fa0619", 1, 76, false, "k_stoicheva" },
                    { "f246c681-502f-4e54-9dc6-565cdf52131e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c9d050d4-d7d9-427f-a28b-bf6bed2f4328", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154657", "a_tomova@mc-bg.com", false, "Антония", 2, false, "14.11.2022", "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", null, "AQAAAAEAACcQAAAAEJ/LjilzN/ahvCAlFFIYgeUlqYLxyQSHT/SrrM9pMmNIMCG/QHvfsOXoqs1YF4vddA==", "+359888888114", false, "https://superdoc.bg/photos/doctors/large/2iIY3v12meJbiYoNQhB4yDBmr6Ff2NYtxIFYiIvK.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "43495277-7a0e-4b95-bee7-2417776a25a7", 1, 60, false, "a_tomova" },
                    { "f956c56c-bccb-406c-af6f-d83b2cedab8f", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "ecf4d412-25fa-4f9b-9de5-adcbc118164b", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156747", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "14.11.2022", "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", null, "AQAAAAEAACcQAAAAEOm1tmEwGMZNaDo8bcUCGLpMe4ktuqgr9VhN9kKUofufSdb9pWMegJa3uVHbN7RlDg==", "+359888888111", false, "https://superdoc.bg/photos/doctors/large/eco5fuHqM1fIXYMzN9X9nvQH8f39RNdTbsOoFk40.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "1e403c17-2099-4619-8033-023cfafc0d5c", 2, 44, false, "r_ikonomov" }
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "1f616074-4936-4cb4-a910-fb7d73bb6c41" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "25102305-973f-4d8e-96aa-8b01385fe976" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "3f397c5d-bfca-4571-bb54-e92f00ed8d1a" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "64d7e693-f160-427d-a146-6490b7bcc802" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "6905e207-eaad-40ca-91fc-b4c62e1852ec" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "7363c14b-1c76-44a0-873f-e184bf9b2d06" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "789f9d0e-c95c-470e-a387-05af8ee96afa" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "7acb8ea9-8560-4e3a-9b00-c690d71dbe1c" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "7f045d0f-6236-481d-9b27-80f29c98fc61" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "9ea3ade9-16c4-43ac-9f04-bc91e5743c1c" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "b48d58c7-30ce-4cff-9604-46a4e26a697e" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "b95298cb-4eff-4d65-8d7d-6b2653dad5ff" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "b9ce6413-5e7f-49c3-a767-29f70a6bc93d" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "b9d2a5da-d6b8-4d23-8c34-bea0e69301fc" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "ba9bac9f-2d06-40d8-b03f-18aecbd45f13" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "bf2a6d4e-d947-4319-987d-6a60ad38dfb3" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "c9f8a712-fa3b-4f1c-862c-e3a07fee8668" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "cc84234a-fa21-4db7-b36d-e6de13d4d33b" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "cfe1f878-a27f-4aef-b8e9-1dca114878e0" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "d34a494a-8fbe-4405-ae19-7490ffbb58f1" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "f246c681-502f-4e54-9dc6-565cdf52131e" },
                    { "2a2cfda6-f247-43d0-a388-76eb46ac1b86", "f956c56c-bccb-406c-af6f-d83b2cedab8f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SheduleId",
                table: "AspNetUsers",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ReviewId",
                table: "Examinations",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_SheduleId",
                table: "Examinations",
                column: "SheduleId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
