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
                    { "14677733-8cb8-4d02-81d6-4eaa4006cf68", "6c525da2-4847-407e-853f-85b523ab8727", "Administrator", "ADMINISTRATOR" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "9eb0d47a-5b42-4316-9c20-fecc4e3e2e74", "Doctor", "DOCTOR" },
                    { "7b671392-60d9-4142-b974-89d745e82e69", "9bc21ba4-600b-4920-9dd1-604758868ec9", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f63a089d-9cc4-49ca-9ea9-db50f25d9430", 0, "0dfbe8fe-fef9-4dc9-bd01-9f404ce06199", "User", "admin@mc-bg.com", false, "Ивайло", 1, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEEjCQBDIAk1bRhz5YTeGRqcT5n5XkQvslTX055T95R08cOHufTitg0Z3kp/IJaSJVA==", "+359888888888", false, "Administrator", "3871056a-3f55-49a9-834e-48a634f406b1", false, "admin" });

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
                values: new object[] { "14677733-8cb8-4d02-81d6-4eaa4006cf68", "f63a089d-9cc4-49ca-9ea9-db50f25d9430" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Discriminator", "Education", "Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Representation", "Role", "SecurityStamp", "SheduleId", "SpecialtyId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "16c35d1a-2a16-4180-8d2a-6de486eabd3e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4d450078-37cc-49f6-b770-e0e9781e2dfd", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150230", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "11.11.2022", "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", null, "AQAAAAEAACcQAAAAEMYcGP2U1znoPagbX4bTYW6LfLLDq0CIulmtx6bn5Rly3HRVrp4SBnUgZZj6hPwa4Q==", "+359888888100", false, "https://superdoc.bg/photos/doctors/large/rwirLXB6bNPuWQCeOWgM9c96rUFbsxnxIonXi6Gf.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "c621d5c6-50ed-45f9-9df3-97d662de9447", 1, 1, false, "m_monastirska" },
                    { "1ef87d4b-b631-4250-a082-36a32dc3beb7", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "96a59090-cadc-48a3-8433-5b26fbeee034", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "11.11.2022", "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", null, "AQAAAAEAACcQAAAAEMPg6vhyEEPpQBQNN9AE/TDxORyLMWke+JBeFjB8PamQ8i7sCEvPHQYf/GcSVMfJnw==", "+359888888101", false, "https://superdoc.bg/photos/doctors/large/rG5hcfjVRagmEoVVwN8afiTTrHKpU2nTKnRbOWr6.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "91e0ff05-d5b1-4301-b99f-5e24fa484e02", 2, 1, false, "s_slavchev" },
                    { "300588e0-9789-4af8-af83-d3e6db9a7fc2", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "93ffcbcd-7b41-4092-b19d-4a31b458e4c4", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "11.11.2022", "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", null, "AQAAAAEAACcQAAAAEMXwdFncKtgWHi6xwep0m90szzLH10nw05xkKlZhKnd8/FK5QJuU2hJkvwHb4pzhjA==", "+359888888120", false, "https://superdoc.bg/photos/doctors/large/AdMojtPGEnem4J2MjHZlE5aH5Ykvm007PjfvAgwe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "618b67b0-bb0d-4ad3-92d0-9ad45ee4db2d", 1, 77, false, "r_uzunova" },
                    { "31bea010-e271-425b-8b08-8686f424dadc", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "85cae3a3-9e57-43a2-a6e6-0bacdd77421c", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154657", "a_tomova@mc-bg.com", false, "Антония", 2, false, "11.11.2022", "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", null, "AQAAAAEAACcQAAAAEDjRpYeQcOR9x9GJlLHM9DTDGFaHJtKt76AlORLyvEdkRFwp9hhRE5kaXiipmg35CA==", "+359888888114", false, "https://superdoc.bg/photos/doctors/large/2iIY3v12meJbiYoNQhB4yDBmr6Ff2NYtxIFYiIvK.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "80c866c9-4ae4-41d4-b45f-1c1cbdd4b73e", 1, 60, false, "a_tomova" },
                    { "323a289d-5575-4d92-955e-ab7e75bb94e1", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "92e96345-a5fb-4fdf-87a9-1a7374fbaa53", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153671", "m_velikova@mc-bg.com", false, "Мими", 2, false, "11.11.2022", "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", null, "AQAAAAEAACcQAAAAEN9+VIECs/4NfhZjAagnb9gRjLmmc1StDnC0x01LuvV8kr0PwBH8NibKJbcwnmAs0w==", "+359888888103", false, "https://superdoc.bg/photos/doctors/large/U0ppKpWfMPGebFNhwhDjFLoKZ2UL3hg26IDn1GPo.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "7652318d-aef1-4bf5-8ed4-15744f840d65", 2, 8, false, "m_velikova" },
                    { "33765375-d28b-4221-bd82-991b63e97e6c", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4b1f6ef9-b01f-4bc0-ac0f-1cedfc3ecb2f", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156747", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "11.11.2022", "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", null, "AQAAAAEAACcQAAAAEF2taOIbnJmUoqOOxwszE66C1jU2tHZg8za501t7lbJEPka8h9hTqNbSWM3+TH/PXQ==", "+359888888111", false, "https://superdoc.bg/photos/doctors/large/eco5fuHqM1fIXYMzN9X9nvQH8f39RNdTbsOoFk40.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "3291610d-6545-452d-bd72-d68b26c5922e", 2, 44, false, "r_ikonomov" },
                    { "494da0ca-23e9-4ece-a7af-4e341a3634da", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c30a806f-0d93-4de8-9235-640621930558", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512151004", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "11.11.2022", "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", null, "AQAAAAEAACcQAAAAEAopgYOcgRahFtPB6k6QKq4tbujOPO5BDGlb4F7N2+bzemPMyMBvyhW/7FmmdyNtnQ==", "+359888888104", false, "https://superdoc.bg/photos/doctors/large/gTvSgfoBMzCm1rEIuxP7zPUVaWXrz92u6zlaESPk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "76a905c4-bb50-45ea-87a2-46c746f166bb", 1, 11, false, "t_stoev" },
                    { "5a2cd453-fdc2-4ab1-88a9-02f5c8550d15", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "2fc85eba-6857-4290-aea3-1920db0e3363", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "11.11.2022", "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", null, "AQAAAAEAACcQAAAAENrX7EeY9CvHuXe68IH0q76FC1HWpBDYdBc5z9AWGo1INvxQxILLUecIn9W6fZ0IBw==", "+359888888112", false, "https://superdoc.bg/photos/doctors/large/cbaXljvO1Z6PTLSLRyIobdw2rtISqC9d7WeelHO3.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "27b36972-7217-428a-ab73-a7d8e8cd7b1e", 1, 55, false, "m_vuldjev" },
                    { "658aa8b5-7c1d-4869-b710-8ec8ba70d525", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "4f7a049c-d144-4017-a3be-51797845787e", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152802", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "11.11.2022", "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", null, "AQAAAAEAACcQAAAAEFSByNNn8SQvY18WSpt0HEJP8kUaK0Iaz4MdinZ1OAmyxiJj6BOhmir3XSBbUwaX5A==", "+359888888117", false, "https://superdoc.bg/photos/doctors/large/gNyJ8eWCA6kTBdW0bXVw4nboWDXzFeIYQ1TFwPo7.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "3478d7d6-a3c8-4757-bbb5-46c3ea3c9f75", 2, 75, false, "g_kuchukov" },
                    { "6a8798b4-6a1f-4828-8f2a-17535cd1f2db", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "b24a9db7-bd5e-42b0-a7be-97a1b943d72c", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155925", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "11.11.2022", "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", null, "AQAAAAEAACcQAAAAEO7BBoLgbSIL9Eq5aKuoytnSiv73J3jM418wHl9pOVkaSnM1uK65+7BEbKfuCdjjcA==", "+359888888107", false, "https://superdoc.bg/photos/doctors/large/zCDqlTJtNK9oicEpDEjON6JQozN57PchSvqOUoqL.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "7cafe54b-46f4-4215-ad6d-1a5e897e772b", 2, 24, false, "d_georgiev" },
                    { "7415d582-abdf-4a37-9372-a92c678ece29", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "ffeaf9fb-dc40-4f75-ba88-e62444961875", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150311", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "11.11.2022", "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", null, "AQAAAAEAACcQAAAAEOAwgbAj8B6d0U7CxkrgbiyR41NcT2LKMeoI/SZGCkN5RtqImiREgJqcsMYE1SiRwA==", "+359888888102", false, "https://superdoc.bg/photos/doctors/large/l45aQMv1pMhcTfABGdxWEgnlCmTPFTfE94sPPuDs.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "16ea8112-757c-4135-8222-cb9eb7a710a0", 1, 8, false, "b_petkova" },
                    { "814c9c6e-0678-4c44-871e-381ed2033170", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "aca3f386-5c7e-449e-a930-62a4a767f132", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154153", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "11.11.2022", "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", null, "AQAAAAEAACcQAAAAEDLv/ZgvfLEs6nil6xMab598H56GS5QXq6gWGuq9gCcprFmd3rz01Yz3bGTEFo4rKQ==", "+359888888106", false, "https://superdoc.bg/photos/doctors/large/9oLkWDJZ3MlW0dzaOmCsjB3XXFecvaWhOW51E14f.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9ec809e8-d6e7-4765-9262-efa39a1e09c5", 1, 24, false, "m_kalinkova" },
                    { "82c8948c-0945-48f7-9f18-3daa08cee073", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "921f358e-2f8f-4977-b12f-2674f42cc6eb", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "11.11.2022", "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", null, "AQAAAAEAACcQAAAAEDBgv1/sDEcxEWraqX9Quap0vpcf2t+Y+UAiQmzVg/kbjCEYFPTQevB0h+vuAWcG7g==", "+359888888110", false, "https://superdoc.bg/photos/doctors/large/6iM4XryT7EmD57gFNzB0lcqp4pfEMlOXwYsDcuv5.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "d46e4b1c-2272-4bc9-8a08-aa1289eb5296", 1, 44, false, "s_atanasova" },
                    { "961e0979-c47e-4abc-855d-01aa7e852a7f", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "da160399-ebc1-444b-8422-79a2b9d10993", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512153898", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "11.11.2022", "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", null, "AQAAAAEAACcQAAAAEHOwyN1HLptgGa9G6oYC+ugQB8CcmRIpt/yigwB7wcAKKx2y4VxmzFDtysJz0jes0w==", "+359888888105", false, "https://superdoc.bg/photos/doctors/large/Enm6h1TL88KLFBQzRqGsUkpASF81JIEAajqqoCwn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "772fb854-b0f4-41d4-a3a4-33222646ecfc", 2, 11, false, "m_blagoeva" },
                    { "9e33bf9e-e7a3-45ff-8a5a-dd587ac55ed7", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "ba95c684-ee92-4ad2-82b2-c51f39b8582d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512157954", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "11.11.2022", "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", null, "AQAAAAEAACcQAAAAEGKQa/DCKyQrLijG09Bg+K6f/yragvG6+Q5sYZnIjxi8T6tr0qD9C2uvE+z2DvvGpQ==", "+359888888118", false, "https://superdoc.bg/photos/doctors/large/DkyVrk4ptD2UAPgywGJp9Sk4ab2mowCTJnWgC7uP.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "cbce4bdc-99d0-473c-b950-7b041468f796", 1, 76, false, "k_stoicheva" },
                    { "9e9bb412-3ca5-4669-bc4a-9714272d6ebf", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "fff145d0-5905-4682-83e2-e9af9d2716f2", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154750", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "11.11.2022", "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", null, "AQAAAAEAACcQAAAAEKV/fdst/ec8qKn3yrh0DQQQGOvc3tILrsTw4cXFDzLEX4in1q0nC+7kd32z/LNuBQ==", "+359888888116", false, "https://superdoc.bg/photos/doctors/large/pStJIXh9QsqC47STGxxsZ9bh3pcS1oddaBF6HR6q.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "18dcddeb-8897-4b89-b992-d8b42323d64b", 1, 75, false, "k_atanasova" },
                    { "aab5c243-5881-4959-bf82-67dc7b47633f", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "8d8ceb0a-fb0c-41af-beca-8e8dae9212f6", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154739", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "11.11.2022", "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", null, "AQAAAAEAACcQAAAAELrHJ5Y7v3mXhADEnHMwum93lSgiQiTZuw4Xg+ZX1/C6hZAOAq3DyNcoI5YBmSpbwA==", "+359888888115", false, "https://superdoc.bg/photos/doctors/large/TZc5jzdK6wotBMXwSYmKe5aPTV2FSiIOC9BEas4n.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "e0b9de08-0bd3-4993-b60b-912e02831b4e", 2, 60, false, "k_moskova" },
                    { "b92d4792-d894-4901-ad24-ef0f6759895f", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1a09ecab-5596-4404-a07e-7bfce955cc49", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155041", "n_paskov@mc-bg.com", false, "Николай", 1, false, "11.11.2022", "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", null, "AQAAAAEAACcQAAAAEASIQqZDpDt0qJTh5LU0dOYEHDU1JbQe6w6yrppxZphHsj2u19+fZKVTY/ByOFSn5Q==", "+359888888119", false, "https://superdoc.bg/photos/doctors/large/KHFCpB4AiRP1yZBJm5tSUeukKgA1PBmFVZs2CfgF.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "74514749-06af-4d8b-89f2-889b223c9fee", 2, 76, false, "n_paskov" },
                    { "c675b800-2994-4c4f-94f9-6ab686ab3692", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "9ae7419d-46d1-4b19-bdc1-d43f48b0d413", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512156161", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "11.11.2022", "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", null, "AQAAAAEAACcQAAAAEGYl0u03pfi/LnDUDp9pl3ugQ3aV4hehZKn7z/jG6o87Y8TYG0qId40D8sJMGUMOqQ==", "+359888888109", false, "https://superdoc.bg/photos/doctors/large/tm0Q6jEA4Zf85mR2cCEoYjNckLlekPrw5bL0GHH1.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "63c4b1fb-ff29-406b-8b85-baa67e8d0cf3", 2, 31, false, "s_tochev" },
                    { "e4de6dbe-486e-4fcb-a6aa-a28b6cedce14", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "95485a03-f5fe-4bc8-9edb-908057c1a271", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", "h_hristov@mc-bg.com", false, "Христо", 1, false, "11.11.2022", "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", null, "AQAAAAEAACcQAAAAEB1w3RNg+xgHbKGpqBOzOLQSQSOudJU7vhmaj1vi376YINDTh2fmQA0xVkvk9+PISA==", "+359888888113", false, "https://superdoc.bg/photos/doctors/large/2dmSQ4sBxuWwMAOGotyikgUYHTD3VB7u4r8t17Ys.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "fc48748d-8392-47e9-97fc-e5d3b4b5033e", 2, 55, false, "h_hristov" },
                    { "f462d650-ab5e-46db-9b22-7566762c64f0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "84602950-1707-4945-b804-048661377972", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "11.11.2022", "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", null, "AQAAAAEAACcQAAAAEMLKwz+H6EYF4pUpGfTNG2qIv/dVp0RWDyn+8gQislc6Vitca/i+q30lDPzB8gUC6Q==", "+359888888121", false, "https://superdoc.bg/photos/doctors/large/LcJF7zG1uWkPqYfBDOAGFqlpA6AVoJOahfaFaRoe.jpeg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "703de51a-e965-4b44-bf13-957fd52a3c7f", 2, 77, false, "i_belcheva" },
                    { "f8681908-bd3c-4db4-9db9-f9168342a50e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "25f7949f-db38-48b7-9bf8-d0c5c9622fe0", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512154338", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "11.11.2022", "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", null, "AQAAAAEAACcQAAAAEHJb2ja7eld2hWfUQVEckdV0+c0sGDqpfvxeR7aBuxkYOEEMZJ7+GCN1yDjQ20pXeA==", "+359888888108", false, "https://superdoc.bg/photos/doctors/large/V1gasguBhI3ii3C1ryit4TuCSercdF5ynvBsxNpd.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "a67c7d5b-5bfc-4a7b-879e-ef6e8983dbbb", 1, 31, false, "r_ruseva" }
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
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "16c35d1a-2a16-4180-8d2a-6de486eabd3e" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "1ef87d4b-b631-4250-a082-36a32dc3beb7" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "300588e0-9789-4af8-af83-d3e6db9a7fc2" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "31bea010-e271-425b-8b08-8686f424dadc" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "323a289d-5575-4d92-955e-ab7e75bb94e1" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "33765375-d28b-4221-bd82-991b63e97e6c" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "494da0ca-23e9-4ece-a7af-4e341a3634da" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "5a2cd453-fdc2-4ab1-88a9-02f5c8550d15" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "658aa8b5-7c1d-4869-b710-8ec8ba70d525" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "6a8798b4-6a1f-4828-8f2a-17535cd1f2db" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "7415d582-abdf-4a37-9372-a92c678ece29" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "814c9c6e-0678-4c44-871e-381ed2033170" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "82c8948c-0945-48f7-9f18-3daa08cee073" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "961e0979-c47e-4abc-855d-01aa7e852a7f" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "9e33bf9e-e7a3-45ff-8a5a-dd587ac55ed7" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "9e9bb412-3ca5-4669-bc4a-9714272d6ebf" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "aab5c243-5881-4959-bf82-67dc7b47633f" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "b92d4792-d894-4901-ad24-ef0f6759895f" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "c675b800-2994-4c4f-94f9-6ab686ab3692" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "e4de6dbe-486e-4fcb-a6aa-a28b6cedce14" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "f462d650-ab5e-46db-9b22-7566762c64f0" },
                    { "5d6e03dd-a6fc-4e51-b308-0c53075e3eac", "f8681908-bd3c-4db4-9db9-f9168342a50e" }
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
