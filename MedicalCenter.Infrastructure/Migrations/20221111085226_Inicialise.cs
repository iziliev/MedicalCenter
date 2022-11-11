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
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "031f2b7c-28ff-4f10-91b8-861cc0fce34c", "18dd608b-af0e-4daf-8073-dbacca6005b1", "Administrator", "ADMINISTRATOR" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "165a286b-8290-4de0-a778-630bde1d9c2a", "Doctor", "DOCTOR" },
                    { "5d40c045-d35d-43b6-8877-e341af5e8e6d", "85ee392a-1492-4f13-b786-e4a5f4c8143d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0501047-4625-408a-a515-90e5a956e9ea", 0, "5cab40f8-c91e-4831-8cb7-a608ecafcb68", "User", "admin@mc-bg.com", false, "Ивайло", 1, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEMmGM/XYwbPSFTVQ8Z2px9MzhbVDIPxeOR1+TG7xR4Q3vT0P7YASVPQSS6SxpKv8Qw==", "+359888888888", false, "Administrator", "5660faea-1a8c-47d5-9600-954cc7309b5d", false, "admin" });

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
                values: new object[] { "031f2b7c-28ff-4f10-91b8-861cc0fce34c", "b0501047-4625-408a-a515-90e5a956e9ea" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Discriminator", "Education", "Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Representation", "Role", "SecurityStamp", "SheduleId", "SpecialtyId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00fc54e2-ac2b-4876-a05f-941f1a5af1c1", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1dc885bd-5fc7-41c8-94c3-8984a02d6455", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152802", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "11.11.2022", "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", null, "AQAAAAEAACcQAAAAEMDcuEve1RpZbxWzTcIWOis7oswRVCGvrN+dCfRtbzbsHRn2w/9TC9dwd5VopDaHvQ==", "+359888888117", false, "https://superdoc.bg/photos/doctors/large/gNyJ8eWCA6kTBdW0bXVw4nboWDXzFeIYQ1TFwPo7.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "87bd9669-8d61-4fce-aada-1855f113a948", 2, 75, false, "g_kuchukov" },
                    { "3b7136ee-ef2d-4b33-9d8a-f1f6e6257d67", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4322a6be-428c-4cdc-8c65-5a0d87634c68", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153671", "m_velikova@mc-bg.com", false, "Мими", 2, false, "11.11.2022", "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", null, "AQAAAAEAACcQAAAAEI+0Ew6uEYoMewKvea0uusxET1Tn8kX7NezwDN54FP36TW+h+bvkAM9/3eyc5Bab2Q==", "+359888888103", false, "https://superdoc.bg/photos/doctors/large/U0ppKpWfMPGebFNhwhDjFLoKZ2UL3hg26IDn1GPo.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8c4d2375-738c-497d-a0f6-0ff338ed816a", 2, 8, false, "m_velikova" },
                    { "4344864a-ad93-4109-bcfa-becc1033bf13", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "45a99f19-da2d-47be-b8d7-283f52f975d0", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154657", "a_tomova@mc-bg.com", false, "Антония", 2, false, "11.11.2022", "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", null, "AQAAAAEAACcQAAAAEDtSuvnqKVDRwaO8d0wo1NgVUzXJ1BQB19YH8/RaXfVwC0xtMINSFZbe6OP1nxP3cQ==", "+359888888114", false, "https://superdoc.bg/photos/doctors/large/2iIY3v12meJbiYoNQhB4yDBmr6Ff2NYtxIFYiIvK.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "eafa5caf-74fb-44c0-bca0-b560aeda53f5", 1, 60, false, "a_tomova" },
                    { "6b44e85c-e066-4489-841e-4ce5633e04a7", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "6a5668f2-87ee-4ed3-aef8-3e965031edd2", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155041", "n_paskov@mc-bg.com", false, "Николай", 1, false, "11.11.2022", "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", null, "AQAAAAEAACcQAAAAENXdPD0dnAjeiskXDwSDRkv/PkK/4efODA6Ja8PvmJXZ8yN7oESUUTs5A4wL4Prb3A==", "+359888888119", false, "https://superdoc.bg/photos/doctors/large/KHFCpB4AiRP1yZBJm5tSUeukKgA1PBmFVZs2CfgF.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "13872ddc-4377-42c0-8b84-0719c8dacd0b", 2, 76, false, "n_paskov" },
                    { "6e5f8c85-b4ed-46fc-abf9-fc1a853f0973", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "0f1e6caa-5413-4529-9a23-c426d2244a95", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155925", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "11.11.2022", "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", null, "AQAAAAEAACcQAAAAEBrlaUe/iD/dOFQJYpszHQYfP1Rbr+RU0U/M7FVe28MRVjLUDBHAShEIQwRESEnTIw==", "+359888888107", false, "https://superdoc.bg/photos/doctors/large/zCDqlTJtNK9oicEpDEjON6JQozN57PchSvqOUoqL.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "6c890bdc-af9d-406f-a296-4d3722232911", 2, 24, false, "d_georgiev" },
                    { "90db1886-75c4-4887-80e5-079d403e3858", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4b02579c-eecc-4413-aa9a-24b38d82b68e", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156161", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "11.11.2022", "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", null, "AQAAAAEAACcQAAAAEG4zoxg/Jr/wQu9rAHFM3Zhpl9muekTH0rTmBMUGIHJeR4fsJKGjd18HdctAkLafAw==", "+359888888109", false, "https://superdoc.bg/photos/doctors/large/tm0Q6jEA4Zf85mR2cCEoYjNckLlekPrw5bL0GHH1.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "a7d2ada5-0bf6-425b-b7f2-10b19df24c76", 2, 31, false, "s_tochev" },
                    { "98e15e67-e7fd-4944-8fa5-90eed080f595", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "8cfa6d6a-9d12-43e0-ad07-c4309a47e88a", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153898", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "11.11.2022", "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", null, "AQAAAAEAACcQAAAAEN7hWRKdw7F2OjthG0+xzhdbT7vWHRzkgyY5pS5HU0cA+yRewQMb7xAadCU11534wg==", "+359888888105", false, "https://superdoc.bg/photos/doctors/large/Enm6h1TL88KLFBQzRqGsUkpASF81JIEAajqqoCwn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "c4cd0204-7a40-4cb1-9b23-3acdee960400", 2, 11, false, "m_blagoeva" },
                    { "9bdc8a84-a52d-49d1-b27f-94bdf6b0363a", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "7f48f8ef-3ff0-4254-91c3-2bfef6853159", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154153", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "11.11.2022", "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", null, "AQAAAAEAACcQAAAAEEEKAAp16at3AfhXFNZr1b9Q8L8HNEFAVsP3VO9u67aTpOUhG1sV9MNYBQZLdcrFIg==", "+359888888106", false, "https://superdoc.bg/photos/doctors/large/9oLkWDJZ3MlW0dzaOmCsjB3XXFecvaWhOW51E14f.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "346e33d3-a092-456c-8fab-edbcb1b1da31", 1, 24, false, "m_kalinkova" },
                    { "9f68547a-5389-4e06-a41a-bcb60303b720", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "a51fdfad-7412-4558-b418-cd03b55f5486", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154750", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "11.11.2022", "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", null, "AQAAAAEAACcQAAAAENHQQ2l9BsFAw621Q/fs4aHNnN4rVKcTSABI2SdyVSTrNfcchavHJCimJUh5RUzcuA==", "+359888888116", false, "https://superdoc.bg/photos/doctors/large/pStJIXh9QsqC47STGxxsZ9bh3pcS1oddaBF6HR6q.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "7bcf4ef9-7884-494b-8acd-f78751a4981b", 1, 75, false, "k_atanasova" },
                    { "a2b5720b-8cf7-41a9-a968-979687620f0b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "6e4aabec-b2f0-426d-a5a5-4d9e65cf978f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "11.11.2022", "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", null, "AQAAAAEAACcQAAAAEOQmsScnqIUmERewtaSWierns/2nVH+5njabvRCcVlMHwnJcdWjLmcYZo2jqswb/Vw==", "+359888888112", false, "https://superdoc.bg/photos/doctors/large/cbaXljvO1Z6PTLSLRyIobdw2rtISqC9d7WeelHO3.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "a1d6701e-048e-4ab0-a663-4e3a5757a748", 1, 55, false, "m_vuldjev" },
                    { "a8a3016a-0861-465b-a5ae-1528ef896ed6", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "b745a969-37a0-4378-acd7-a565d6067f1d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512157954", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "11.11.2022", "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", null, "AQAAAAEAACcQAAAAED9RTNzD6Xg0uPjrErP84XHb1vNd7X2ydHhvJed1Kq6gfYb4GAIBBgYuzUMVMYC57g==", "+359888888118", false, "https://superdoc.bg/photos/doctors/large/DkyVrk4ptD2UAPgywGJp9Sk4ab2mowCTJnWgC7uP.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "3cd48254-30ee-4256-83e0-f85c42b54a69", 1, 76, false, "k_stoicheva" },
                    { "b754f806-22cf-4e3d-ae1b-e5aaf500f1b0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "8bf19031-e234-412d-8bec-5b841253e55b", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "11.11.2022", "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", null, "AQAAAAEAACcQAAAAEJhVLoKXMCe+pJTYk9FqsvKmqo8Bp+L5xdfRoSPL6kgFZMJK+n3kKOx0O8vTs8gOHg==", "+359888888121", false, "https://superdoc.bg/photos/doctors/large/LcJF7zG1uWkPqYfBDOAGFqlpA6AVoJOahfaFaRoe.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "a6c19e40-a104-47ef-80ba-6a61336b035b", 2, 77, false, "i_belcheva" },
                    { "bd1951c9-d199-40c9-a89c-960beea29954", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "e0ee7067-b2bb-499a-b5c6-f8035d75732d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156747", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "11.11.2022", "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", null, "AQAAAAEAACcQAAAAEDB0d2oQvntF5dYGRXvJx5Yr88sMC5tGLDsdk51tOsQynuNZYdYz5cn1j1yx9Z+ayA==", "+359888888111", false, "https://superdoc.bg/photos/doctors/large/eco5fuHqM1fIXYMzN9X9nvQH8f39RNdTbsOoFk40.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "4b180be7-d93a-4369-8c04-602ed34afeda", 2, 44, false, "r_ikonomov" },
                    { "bded34c9-921f-4a0a-964a-432dc7eb962a", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "58a0c1b3-ae6c-47ac-af87-d30d91c10528", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150230", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "11.11.2022", "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", null, "AQAAAAEAACcQAAAAEPBOeKRnN4wIyCHk/xg4rm7MFvXC5nARFFdRYHPeYEIsrMmkt0ZANz/KNMhPmh/y7Q==", "+359888888100", false, "https://superdoc.bg/photos/doctors/large/rwirLXB6bNPuWQCeOWgM9c96rUFbsxnxIonXi6Gf.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "ecaa979e-042a-430a-a0a7-513ece6782a4", 1, 1, false, "m_monastirska" },
                    { "c5500b98-909a-49da-a298-392e18ae3503", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "f7f577f1-fc46-4e5b-9fd4-3891a872a5a5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154739", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "11.11.2022", "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", null, "AQAAAAEAACcQAAAAEJ3EsC2I53cpT5LZm0XTimoOy/+YT0Yh4i0N+ykzIVomESZzOivh38i9J9FPkq2R2w==", "+359888888115", false, "https://superdoc.bg/photos/doctors/large/TZc5jzdK6wotBMXwSYmKe5aPTV2FSiIOC9BEas4n.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "048028e6-b838-4233-adb8-b541f161e1f2", 2, 60, false, "k_moskova" },
                    { "c9896137-0636-47ac-b914-e31781d74ddd", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c88e9837-0271-4eae-96fd-ca435aea8ff8", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "11.11.2022", "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", null, "AQAAAAEAACcQAAAAEKao6fOfDLgcmJgfUKVjHE5UK0prfNpTuTevslIj/aiRaX+siE3/HvtP4EiOoBn5ig==", "+359888888110", false, "https://superdoc.bg/photos/doctors/large/6iM4XryT7EmD57gFNzB0lcqp4pfEMlOXwYsDcuv5.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "1cd0addd-6985-4cd0-bcde-c7fc23470eb6", 1, 44, false, "s_atanasova" },
                    { "d166c5bf-d2e3-488a-94a2-0d1eebc42128", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "370a168b-c0bc-4c43-8e71-15aabf072bfa", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150311", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "11.11.2022", "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", null, "AQAAAAEAACcQAAAAEJQKUT0MG4SgeDphDXdtfA6HPIEtxyyUZ+BXTOqRZIunrxIUXmtmfWqNSGP2p2YIJQ==", "+359888888102", false, "https://superdoc.bg/photos/doctors/large/l45aQMv1pMhcTfABGdxWEgnlCmTPFTfE94sPPuDs.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9fde43fc-417e-419f-acc5-f2c14c7f4208", 1, 8, false, "b_petkova" },
                    { "dfb73100-301a-4696-9edc-848b938ca952", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "ba45c58f-032e-4a72-b198-d785d37f677f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", "h_hristov@mc-bg.com", false, "Христо", 1, false, "11.11.2022", "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", null, "AQAAAAEAACcQAAAAED+w4z6Eiyo30SdL8EL8KPTFjiRpUWAXxuxkDtKpgm0Y4asQ7s4t4sK8UdjXjneftA==", "+359888888113", false, "https://superdoc.bg/photos/doctors/large/2dmSQ4sBxuWwMAOGotyikgUYHTD3VB7u4r8t17Ys.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "dd5d985b-a0c6-4261-8618-519621b4304f", 2, 55, false, "h_hristov" },
                    { "e4ac6218-87c6-4832-bad6-7017e70da1ad", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "a24d57d4-256e-4662-9b41-884d554f91d3", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "11.11.2022", "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", null, "AQAAAAEAACcQAAAAECHEQTaEvkARkn/uSex83p4GOgqI7QUvGsmG5eEytsaMOveStGj/bagxnkbD1sKnKg==", "+359888888108", false, "https://superdoc.bg/photos/doctors/large/V1gasguBhI3ii3C1ryit4TuCSercdF5ynvBsxNpd.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9f07eb12-b97e-4aba-9b83-9a23664eabc5", 1, 31, false, "r_ruseva" },
                    { "e6a82ade-3d49-44a1-99a1-39a0178f1bb7", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "180b3b56-3bc0-4c84-a156-c006269e4af5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "11.11.2022", "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", null, "AQAAAAEAACcQAAAAEPVjq10L95eVisHmFSuhO/6W4i2JuWSOno1Xs9WiVg6Cvt0Lsk5B9n8MOhY90RX36g==", "+359888888101", false, "https://superdoc.bg/photos/doctors/large/rG5hcfjVRagmEoVVwN8afiTTrHKpU2nTKnRbOWr6.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "e7e94e3b-0f8b-4df8-85ac-e806a2d36890", 2, 1, false, "s_slavchev" },
                    { "e75a3110-b2d8-4382-9c5e-e03f18b8bd47", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "9a52291d-93a2-448b-a0a2-39089ded2589", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512151004", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "11.11.2022", "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", null, "AQAAAAEAACcQAAAAEIbu+2VOioa1RXCkgLdNts5HusoBTPTUoud575OIXIGqgAG+rdhe9xJGS+Aa+3C4bQ==", "+359888888104", false, "https://superdoc.bg/photos/doctors/large/gTvSgfoBMzCm1rEIuxP7zPUVaWXrz92u6zlaESPk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "1e7d2e8a-39a4-427a-952c-1b8109f53fb9", 1, 11, false, "t_stoev" },
                    { "ea51eca9-c0d5-46b5-a082-278d468a0ce0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "b799a0c7-4772-4b42-b996-df45251fe873", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "11.11.2022", "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", null, "AQAAAAEAACcQAAAAEOMAtrcQMb2TWPefdXxFU/XXKJgPCZscPm+ndtXjacqKSHw9kZySBAum8XahrZJ21w==", "+359888888120", false, "https://superdoc.bg/photos/doctors/large/AdMojtPGEnem4J2MjHZlE5aH5Ykvm007PjfvAgwe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9c44985f-8a14-45cd-ab0f-20d3c831e391", 1, 77, false, "r_uzunova" }
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
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "00fc54e2-ac2b-4876-a05f-941f1a5af1c1" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "3b7136ee-ef2d-4b33-9d8a-f1f6e6257d67" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "4344864a-ad93-4109-bcfa-becc1033bf13" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "6b44e85c-e066-4489-841e-4ce5633e04a7" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "6e5f8c85-b4ed-46fc-abf9-fc1a853f0973" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "90db1886-75c4-4887-80e5-079d403e3858" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "98e15e67-e7fd-4944-8fa5-90eed080f595" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "9bdc8a84-a52d-49d1-b27f-94bdf6b0363a" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "9f68547a-5389-4e06-a41a-bcb60303b720" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "a2b5720b-8cf7-41a9-a968-979687620f0b" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "a8a3016a-0861-465b-a5ae-1528ef896ed6" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "b754f806-22cf-4e3d-ae1b-e5aaf500f1b0" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "bd1951c9-d199-40c9-a89c-960beea29954" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "bded34c9-921f-4a0a-964a-432dc7eb962a" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "c5500b98-909a-49da-a298-392e18ae3503" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "c9896137-0636-47ac-b914-e31781d74ddd" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "d166c5bf-d2e3-488a-94a2-0d1eebc42128" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "dfb73100-301a-4696-9edc-848b938ca952" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "e4ac6218-87c6-4832-bad6-7017e70da1ad" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "e6a82ade-3d49-44a1-99a1-39a0178f1bb7" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "e75a3110-b2d8-4382-9c5e-e03f18b8bd47" },
                    { "5268ce00-c630-4c7e-8fde-9d23f6629dae", "ea51eca9-c0d5-46b5-a082-278d468a0ce0" }
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
