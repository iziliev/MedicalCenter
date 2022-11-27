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
                    Doctor_IsOutOfCompany = table.Column<bool>(type: "bit", nullable: true),
                    Doctor_OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor_Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SheduleId = table.Column<int>(type: "int", nullable: true),
                    Laborant_Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsOutOfCompany = table.Column<bool>(type: "bit", nullable: true),
                    OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LaboratoryPatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WBC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RBC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCHC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrinepH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrineGravity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_LaboratoryPatientId",
                        column: x => x.LaboratoryPatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "125979d4-285a-4dfd-9491-296800a62407", "3027f21f-cf59-47d4-a7aa-119db7a02136", "LaboratoryUser", "LABORATORYUSER" },
                    { "4ec445ec-71c0-4102-a65f-d76b5c2eea1d", "3f924dd0-a7c1-410d-b80a-196f4855c03c", "Administrator", "ADMINISTRATOR" },
                    { "89a85122-28b7-411c-ab32-bf0f67829b66", "ffd20b28-7b5d-4813-af4b-24a7807e43ce", "User", "USER" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "e6246a64-0ac8-4bba-9741-2ba818f83f20", "Doctor", "DOCTOR" },
                    { "e2695c3b-312a-4810-bcc7-d0f7e0bb2056", "1cf5e042-13cf-4dda-b4b5-a9ddb4f25c60", "Laborant", "LABORANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Laborant_Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d8d50b4-449f-41e3-aea4-81b4b67a8880", 0, "a9b0fd11-815e-4a87-a04c-ae38f072257d", "Laborant", "8412194792", "lab_vivanova@mc-bg.com", false, "Ваня", 2, false, "26.11.2022", "Иванова", false, null, "LAB_VIVANOVA@MC-BG.COM", "LAB_VIVANOVA", null, "AQAAAAEAACcQAAAAEETzFFIKon16p4J8hronG2sYgPe0VWJLunddA37TVPsLQdiUZLyei2WLfLHQagjP5Q==", "+359888888881", false, "Laborant", "2450a86a-ed48-4dea-87d9-9c63f8b2df30", false, "lab_vivanova" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89e45214-693d-489a-a301-765fffa3eee3", 0, "7190bc73-d3d2-45ca-8fd2-f538787c9ab9", "User", "admin@mc-bg.com", false, "Ивайло", 1, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEHHO4TCtdBg9lqshl4mgcq4UNdl+xbY35bcAcGd6NhXbjAT8DeLtasRvJ1R40ZNmWQ==", "+359888888888", false, "Administrator", "3c7eb121-9415-4f12-9fe8-10b523ede8f8", false, "admin" });

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
                    { 2, "Втора смяна" }
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
                    { 30, "Инфекциозни болести" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 31, "Кардиолог" },
                    { 32, "Кардиохирург" },
                    { 33, "Кинезитерапевт" },
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
                    { 72, "Спортна медицина" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 73, "Съдов хирург" },
                    { 74, "Токсиколог" },
                    { 75, "УНГ" },
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
                values: new object[,]
                {
                    { "e2695c3b-312a-4810-bcc7-d0f7e0bb2056", "2d8d50b4-449f-41e3-aea4-81b4b67a8880" },
                    { "4ec445ec-71c0-4102-a65f-d76b5c2eea1d", "89e45214-693d-489a-a301-765fffa3eee3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Biography", "ConcurrencyStamp", "Discriminator", "Education", "Doctor_Egn", "Email", "EmailConfirmed", "FirstName", "GenderId", "Doctor_IsOutOfCompany", "JoinOnDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Doctor_OutOnDate", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "Representation", "Role", "SecurityStamp", "SheduleId", "SpecialtyId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0314e169-7bcb-451c-9300-23250e8e7411", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "70bfc440-f759-4109-b353-84b1f7a30cc5", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "26.11.2022", "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", null, "AQAAAAEAACcQAAAAEDXcLZhlj/XAct/XL26NBHWP2N9cjGmgO1jquPtlEdSGeeZr0iSK3+lLTvCY70F5Ig==", "+359888888121", false, "https://i.imgur.com/dj7NvUl.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "205afd00-4dd9-48fc-8019-418c3245c58f", 2, 77, false, "i_belcheva" },
                    { "175669b4-d817-4ffa-be49-bc9d3b1ba989", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1e30e955-41b7-4c1e-9713-251a5fa769fe", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9401161818", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "26.11.2022", "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", null, "AQAAAAEAACcQAAAAEKRteX3F9rCv9z/mpGx4/L/NRv4MgLc9BLjT1VfTiITMLGb6MeMfKGpicbuVAwjPNA==", "+359888888108", false, "https://i.imgur.com/LKNbRcV.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "00954db5-aaad-4b15-b8e9-a8277f979e5a", 1, 31, false, "r_ruseva" },
                    { "210a129b-db07-4226-9cf4-11ee66f092e9", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "cf964723-bfcc-48f9-85b2-20ff1ac40b46", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9103145306", "n_paskov@mc-bg.com", false, "Николай", 1, false, "26.11.2022", "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", null, "AQAAAAEAACcQAAAAEBd0jsFyNUTHDXESBU9X1UEqTHMmAdAzV5CaugsV9S6hE0kjf5d+iWv5v4pvle7wnw==", "+359888888119", false, "https://i.imgur.com/f5yYnPN.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "0dbdf86f-ab60-4f0d-bb93-ceb65226a3f6", 2, 76, false, "n_paskov" },
                    { "376dff86-4ac3-42ae-8ecd-09179501375a", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "d412b64c-375c-4274-b06c-e36b541f324a", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7702262899", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "26.11.2022", "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", null, "AQAAAAEAACcQAAAAEMl7/zjiV8qnIUU35xGu6xUe5/S2te8tjcVJtAUUjLSmy5lLYPvxpbKdp+mKvKwXFQ==", "+359888888110", false, "https://i.imgur.com/oFAixEu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "43a547ff-b9be-4feb-b687-85bf3f66d0ba", 1, 44, false, "s_atanasova" },
                    { "3db948c1-c8db-44e2-86e7-22dbb07ebdc9", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "5b8dfafc-e85c-4e51-8258-3b21858052e4", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9002041303", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "26.11.2022", "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", null, "AQAAAAEAACcQAAAAECPNPhIbQj5geS7efQ1efLB/+CHJOrL+YZJd1BAj24C+B6CvzFnHWri2YUffPM8aiw==", "+359888888117", false, "https://i.imgur.com/fkXWOZT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "cadacf72-b856-4941-a94a-26a6fe114eb6", 2, 75, false, "g_kuchukov" },
                    { "50fec4aa-3d81-4ace-976a-92a69270665e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "01d154fa-c46a-408a-ba72-9efbbda2dc64", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7801138974", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "26.11.2022", "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", null, "AQAAAAEAACcQAAAAEPt9tY12kPuBAsSx70ppgMitabxfixzXG1ev5YmJJl0Cgj9/+vSZs8cAp80lU/A0Zg==", "+359888888118", false, "https://i.imgur.com/6NU5RvT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "55ecfe9e-b2e6-4caa-a655-d87cdc1f8ee5", 1, 76, false, "k_stoicheva" },
                    { "54cc8370-4f7e-426e-b87e-638babf251cf", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c96342ae-9137-47f1-a1e5-134ddddb8cb8", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7412135099", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "26.11.2022", "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", null, "AQAAAAEAACcQAAAAEJisyKWwiLa5u7SRc+hPke6B5jmbh9w/5Z66tfAfkvFuojcSvniTIJuz/XsBK50pYw==", "+359888888102", false, "https://i.imgur.com/66UFmBy.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "9be0f607-39c0-4207-8ed6-f1fb34384e9d", 1, 8, false, "b_petkova" },
                    { "54ed1806-7b2e-4630-a093-3b648d23fc31", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "cc80c6b1-22a5-4f8b-816d-287308468678", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7903129851", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "26.11.2022", "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", null, "AQAAAAEAACcQAAAAELZ2+35g26K76sGG/lMq1PVaZZ4vyto9fXLHGhA+q4oDSTAgIUFq/5qgF0ADOUF5bQ==", "+359888888100", false, "https://i.imgur.com/9gZeKsk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "4149893a-74a9-4f4c-a047-cb509b978ab3", 1, 1, false, "m_monastirska" },
                    { "5759467e-c4b9-4401-9996-dea77ec90334", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "23a7e7a3-19bc-4924-bde3-41cf162fff0a", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "26.11.2022", "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", null, "AQAAAAEAACcQAAAAEKIETN/Cw7R/MKtPhksnIElP8V3MLXU4jij1bra3w9yIuQvmnCQJjzjgGy1ueStxLA==", "+359888888112", false, "https://i.imgur.com/YO1cWgu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "f38b6208-7300-4fe7-bebd-d713365bbbde", 1, 55, false, "m_vuldjev" },
                    { "5be51ba1-c561-4eab-8b62-62b6dc6ce63d", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "89856650-3ed4-4464-9c70-a63f34a1e2dd", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707015574", "m_velikova@mc-bg.com", false, "Мими", 2, false, "26.11.2022", "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", null, "AQAAAAEAACcQAAAAEIzz9/jXV6CyZGJe3/ifk00an5gujhNEwVUaJmLBoc/fDVRdZLdJ4qoeyiSZSMvOMQ==", "+359888888103", false, "https://i.imgur.com/7VzO2Pm.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "0084a6a2-cce1-4c91-b1fd-960049b1ae7c", 2, 8, false, "m_velikova" },
                    { "621f586d-b181-4988-9d71-9b01b9449d03", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "3c0797fb-e02c-4d3c-b540-c55af8f97c38", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7411033533", "a_tomova@mc-bg.com", false, "Антония", 2, false, "26.11.2022", "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", null, "AQAAAAEAACcQAAAAEAyrSJT1UMAmyVvlNualZPsb3hByYCb9Y7RtCLjTG9/efNySlyhj4LEjqB/dAPlLGA==", "+359888888114", false, "https://i.imgur.com/WkPS5Ds.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8c79fe81-fe16-478f-8e7c-64103412010a", 1, 60, false, "a_tomova" },
                    { "64983f38-eb20-4ed8-a123-733a1818cc1b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "752b3873-f970-4b9c-8781-dae36d46632d", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "26.11.2022", "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", null, "AQAAAAEAACcQAAAAEG1GzWXKkcw0pdAHi5x1yxtApNPb9908IDESpc9necn+9IR5XUG9W52kGfRJcW7R2Q==", "+359888888101", false, "https://i.imgur.com/73peyhD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "bc111541-003d-4836-be52-421b3fc2f11a", 2, 1, false, "s_slavchev" },
                    { "6af3c0a7-50cd-492f-b442-c3b9580d069b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "f6e47aa2-9018-471e-982c-9e2f89a8babd", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707192482", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "26.11.2022", "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", null, "AQAAAAEAACcQAAAAEFnYn/FLcr6IVs0icRqyE3zUE+Qg6M2Ykrtxj2tCMajjLQ1Xiowly5wk01AvAhKeGA==", "+359888888111", false, "https://i.imgur.com/E5Yga61.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "7a9ea548-d5df-4e54-8cdb-9168726a6515", 2, 44, false, "r_ikonomov" },
                    { "844bbc19-5543-4c93-8ebe-48bebbda2a3f", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "1139202f-06d0-4c5a-9e1c-580e156a8381", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7504196361", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "26.11.2022", "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", null, "AQAAAAEAACcQAAAAEJFDFVgGPUsb5jnLtRRK5X3codOHh97IhjQXfEB8m34H6m0mKVXsUWG/UGlbvHdQQA==", "+359888888107", false, "https://i.imgur.com/62LMUUe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "aebdfe5b-4fa1-44d3-a8c2-1d5bccfd473c", 2, 24, false, "d_georgiev" },
                    { "8805ea81-ea7a-4d40-9fc1-191d22340bfc", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "896f3093-e700-47e1-9677-36a3058a5249", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", "h_hristov@mc-bg.com", false, "Христо", 1, false, "26.11.2022", "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", null, "AQAAAAEAACcQAAAAEICM9QOc/3NEnIGL6OD0HiEg+SpptMxX1MrFe7oC+/eKG4dNsYqlTKC188lDP8NMBA==", "+359888888113", false, "https://i.imgur.com/42rKRT2.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "8c69a3a2-5bfd-4a20-9eab-e82d6155e36e", 2, 55, false, "h_hristov" },
                    { "8942bbd7-6192-4d01-b614-85611032b092", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "c63ef270-d20e-479c-8871-440926807735", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9107227892", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "26.11.2022", "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", null, "AQAAAAEAACcQAAAAELuz0eG6yxE5eN6aIglnO7OyXc83mw+EYK+gPrDP2JTrl1NgrvN117qvFJuYuwD7gQ==", "+359888888106", false, "https://i.imgur.com/yQmifbA.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b19418e8-d9eb-4f00-ae24-400da82480ec", 1, 24, false, "m_kalinkova" },
                    { "8cba7a06-5661-4493-9258-f06852fa600b", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "16da8ca1-2368-4b03-bda9-456dc8065466", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8606163716", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "26.11.2022", "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", null, "AQAAAAEAACcQAAAAEDFljT085pZo/5ctltQWc/5fPmy9TsIfV/0VpoKt9hzwsBC4x+juIbY6BYX9kIy+bw==", "+359888888116", false, "https://i.imgur.com/GhnW3gD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "2d6b72a7-cdd8-4a16-96ef-be36c5603b1a", 1, 75, false, "k_atanasova" },
                    { "a9b5296a-7e2b-41f7-9159-7834fb469ed0", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "bb54f569-e6bd-44c2-bf4c-25e36e34f5f9", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "26.11.2022", "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", null, "AQAAAAEAACcQAAAAEEBpgQGdB8QvYqqEAcKmQpVDE9nkPCVlIg2t9g8uYJQirBaQ6dLxiDUTUH1EvuGrhQ==", "+359888888120", false, "https://i.imgur.com/hx5EEMp.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "1b776699-f6cf-485f-9231-ddaddf9dd27f", 1, 77, false, "r_uzunova" },
                    { "bca07549-6ac1-4c56-9900-38a8e2ae187e", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "76d892cc-7838-41bf-9d92-2a5607f508d0", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7609186138", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "26.11.2022", "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", null, "AQAAAAEAACcQAAAAEM+NSST5DreC9iiRnv4Zbm2LLE2MF3EFv/jhxRL5/a6907LsFeCe8sk4nAYwfJ14dQ==", "+359888888115", false, "https://i.imgur.com/2HO3b8v.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "22434624-aa03-45f8-9cd6-de0b0d5abbb0", 2, 60, false, "k_moskova" },
                    { "cc887dfc-07e0-4f85-9698-58b083c9d203", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "bb790c51-f23c-4f4f-879b-70b6bb56621c", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7904245096", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "26.11.2022", "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", null, "AQAAAAEAACcQAAAAEE22kr12ilLZULaB2BkjT/q6TBvVhl/6InrnpnGCI4Cxm6Hl4A3r6pqj4BsOaoAx9w==", "+359888888105", false, "https://i.imgur.com/2xoQC2H.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "b975faab-fa9d-4b81-ac2e-425f9e99814f", 2, 11, false, "m_blagoeva" },
                    { "d918bc07-d778-4cce-a106-e1bcb1936834", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "45505dde-8153-4e8c-a3fa-79c6c7563724", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8112144846", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "26.11.2022", "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", null, "AQAAAAEAACcQAAAAEK1zRq2ZRDPMjbSNJBWB5BHsLutszgpV6n1QvPOChFvIUYOQy47WL3nCytizkxl2rA==", "+359888888109", false, "https://i.imgur.com/YK3Y8Ya.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "622e4cd8-b4f0-402b-a6f9-be64e4759ff2", 2, 31, false, "s_tochev" },
                    { "ecc1a5c4-e551-40b8-9a5a-5672b02dadce", 0, "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "fdce7c86-dab4-487a-b007-14bfc0a3a6cf", "Doctor", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "6902251307", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "26.11.2022", "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", null, "AQAAAAEAACcQAAAAEN20Ts6IAM1U2YNgd6XdgTaiXE429oZ/ZMdSGavcGn+pvU0JAPEUmNY4ZLQzKAQkrw==", "+359888888104", false, "https://i.imgur.com/oSv4hEn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", "Doctor", "647a9e47-856b-4833-a850-a0320c0cc566", 1, 11, false, "t_stoev" }
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
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "0314e169-7bcb-451c-9300-23250e8e7411" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "175669b4-d817-4ffa-be49-bc9d3b1ba989" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "210a129b-db07-4226-9cf4-11ee66f092e9" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "376dff86-4ac3-42ae-8ecd-09179501375a" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "3db948c1-c8db-44e2-86e7-22dbb07ebdc9" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "50fec4aa-3d81-4ace-976a-92a69270665e" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "54cc8370-4f7e-426e-b87e-638babf251cf" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "54ed1806-7b2e-4630-a093-3b648d23fc31" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "5759467e-c4b9-4401-9996-dea77ec90334" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "5be51ba1-c561-4eab-8b62-62b6dc6ce63d" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "621f586d-b181-4988-9d71-9b01b9449d03" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "64983f38-eb20-4ed8-a123-733a1818cc1b" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "6af3c0a7-50cd-492f-b442-c3b9580d069b" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "844bbc19-5543-4c93-8ebe-48bebbda2a3f" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "8805ea81-ea7a-4d40-9fc1-191d22340bfc" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "8942bbd7-6192-4d01-b614-85611032b092" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "8cba7a06-5661-4493-9258-f06852fa600b" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "a9b5296a-7e2b-41f7-9159-7834fb469ed0" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "bca07549-6ac1-4c56-9900-38a8e2ae187e" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "cc887dfc-07e0-4f85-9698-58b083c9d203" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "d918bc07-d778-4cce-a106-e1bcb1936834" },
                    { "d0258995-a3b5-4bb8-8828-cb103fc4fdc4", "ecc1a5c4-e551-40b8-9a5a-5672b02dadce" }
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
                name: "IX_Tests_LaboratoryPatientId",
                table: "Tests",
                column: "LaboratoryPatientId");

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
                name: "Tests");

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
