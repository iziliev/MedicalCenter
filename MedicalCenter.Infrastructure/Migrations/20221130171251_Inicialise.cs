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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaborantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryPatientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministratorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOutOfCompany = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "Laborants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laborants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laborants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryPatients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryPatients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    Representation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    OutOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Egn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Shedules_SheduleId",
                        column: x => x.SheduleId,
                        principalTable: "Shedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
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
                        name: "FK_Tests_LaboratoryPatients_LaboratoryPatientId",
                        column: x => x.LaboratoryPatientId,
                        principalTable: "LaboratoryPatients",
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
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
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
                        name: "FK_Examinations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examinations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
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
                    { "30d8b959-5d2a-4399-a252-5f0e36664bc3", "94f384ec-3288-44fb-8dcf-6f349e9ce6ee", "Laborant", "LABORANT" },
                    { "32d19b1e-b575-488e-860b-18eb1dbec58d", "ef9edcdd-168f-411d-aa66-e143b0b329c4", "Administrator", "ADMINISTRATOR" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "62aafbe3-5fbd-4a8c-a7f4-5dc14b9e3410", "Doctor", "DOCTOR" },
                    { "706c269e-4eda-425f-87c2-829eec6cb202", "0683211c-ebcc-46e0-b94f-db537a6ca059", "LaboratoryUser", "LABORATORYUSER" },
                    { "a0f47389-4c6b-4590-8480-6beb741d2c3e", "1ff4d815-1623-4044-8484-7b41a1fd8e97", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdministratorId", "ConcurrencyStamp", "DoctorId", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LaborantId", "LaboratoryPatientId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "041639c2-fcd2-4899-a5c6-2025cbb3c1c7", 0, null, "1ac919a6-4809-4fe0-b574-73494d76de37", "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "30.11.2022", null, null, "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", "AQAAAAEAACcQAAAAEC65J7oRo+HHpT7+eDWlxgJrbE7t74HCvxDnbcb01v79kvsWqeAvi9j82pOtsGPLfw==", "+359888888115", false, "Doctor", "47d4d6d6-bd56-40cd-be11-f1eb6dd5fa6a", false, "k_moskova" },
                    { "095da4be-9891-4cd9-a2ad-05dbbb0e2085", 0, null, "09dd4ae8-82d7-4799-9061-080c2ecc2af6", "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "30.11.2022", null, null, "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", "AQAAAAEAACcQAAAAEHRXJXp/HF0iIbcVq9+9Xez4ipDlCtxPxbIkuaLT67D7UgsCOOSurFOui1BxCVeeDg==", "+359888888111", false, "Doctor", "ee619d10-9228-476c-adb4-e64139eeb3e4", false, "r_ikonomov" },
                    { "0bbf2307-d024-44b4-917f-a52ab9ddc013", 0, null, "8ebdeee4-a6fb-4516-b1f5-de2d524f0fe4", "473d0775-d1d3-4439-940b-fe949652859f", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "30.11.2022", null, null, "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", "AQAAAAEAACcQAAAAEK72Uf4sIQTUZaGdKI/INlZ9gfbyQK0qnb/XVKjLiCK8hcCJ0C3S71zfGadVOY4uxA==", "+359888888106", false, "Doctor", "00d66d2c-7a3e-4a7c-907e-7c4aa1da95a2", false, "m_kalinkova" },
                    { "3f9592ad-6af3-4021-808f-39d7aa9246e9", 0, null, "4a2fac37-e758-448a-b7fa-41739964722a", "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "30.11.2022", null, null, "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", "AQAAAAEAACcQAAAAELKqvzceXQlZnkL5ar1vpe7iU35vNZXHrxYbJqjJRqVnn3lKqPuKY+tWd6vrWWZSfA==", "+359888888105", false, "Doctor", "ed85e1f9-021f-42a0-9ab2-3d4b39fec924", false, "m_blagoeva" },
                    { "734267e9-a59b-44c3-baee-7e52a2bd1c29", 0, null, "bff468b3-97d8-4331-b4ed-ab67b960d6cd", "4be5615e-0d14-4756-a090-bd157133f463", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "30.11.2022", null, null, "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", "AQAAAAEAACcQAAAAEGua8ovs1KJsWcdwcGgWF7uJYVxtgHAWowTTV+0aDwaElbj9fQsFdcUb3JoZCbOXKw==", "+359888888121", false, "Doctor", "ee924d66-0e88-477a-947e-11d50deb76e1", false, "i_belcheva" },
                    { "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e", 0, null, "dd015a40-7e2e-4cc6-8f6f-e74f7fcd2611", "22081bf0-1049-45ba-a9b3-3171271f1341", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "30.11.2022", null, null, "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", "AQAAAAEAACcQAAAAEAKIP72sAiiqkoBCdUudsdjWQAkqZx8fF1fY7UL6xRsKQLMaWjlmFGe2cL9ht2Dbsw==", "+359888888101", false, "Doctor", "78fc9de7-a9f4-495f-9faf-593cd8a2c394", false, "s_slavchev" },
                    { "7c513995-bed0-4be3-b768-304cd697c3f9", 0, null, "8c1a4c2b-f67f-4d02-8b2f-057ca50ffc28", "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "n_paskov@mc-bg.com", false, "Николай", 1, false, "30.11.2022", null, null, "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", "AQAAAAEAACcQAAAAEK12BZolB6WOhkqGurMDuIoBzAI/oENQGMEJwhyP9L8emyT72wprCrUHB0RFM3NRsg==", "+359888888119", false, "Doctor", "2169bcdd-f4e8-4720-a015-3a6b243698f5", false, "n_paskov" },
                    { "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca", 0, null, "35b7735e-0368-4bd5-89cb-3ccb98332789", "182466cf-4d18-4ba4-940c-71e8f445335c", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "30.11.2022", null, null, "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", "AQAAAAEAACcQAAAAEMJLA41dNvJHs5DbBPvLMA9BZ2coUHV+65O84MTb3yFUXHNr4jKy7n36p/SAFSFEoQ==", "+359888888110", false, "Doctor", "6cc1c56a-489a-4470-b1c7-b1e89a75fd5c", false, "s_atanasova" },
                    { "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe", 0, null, "312d5d4b-637a-43a7-b0a0-bc17fd454c01", "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "30.11.2022", null, null, "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", "AQAAAAEAACcQAAAAELUS8CC7LJCttkaafEUzjkLHg+OXldcZJc5NX1NJlKOhsRvZo0BlGHoeGxCIBh8RjQ==", "+359888888117", false, "Doctor", "bdb947e7-3972-49e4-a897-7d983b3e1556", false, "g_kuchukov" },
                    { "9da9587f-e28e-4289-a559-7407d3ea34a5", 0, null, "98c7f800-55cc-4e25-93a6-55e6e0de61b0", "4b95c2a0-314d-414d-a80a-db46ef2f810a", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "30.11.2022", null, null, "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", "AQAAAAEAACcQAAAAEFM6s8AliTGNbayx9ddFu/1It71GK2QIkPEu4huri28+ObWlRpsHhUEfhSRvzymlDQ==", "+359888888100", false, "Doctor", "b210546b-2ade-47a9-9710-8ca6f46d33ee", false, "m_monastirska" },
                    { "a8d60b9c-6bef-4eff-af47-bcce7daf311b", 0, null, "a8fca13f-5935-41a0-82b4-dadeb104c358", "992d83f0-1439-40dc-95f4-5a708fd3c086", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "30.11.2022", null, null, "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", "AQAAAAEAACcQAAAAEHtyOVT/bwKoTi8baj57raEJBA5249vQASOrbAa5jpOkRMe24qCOoVyldQ4lMzRKCQ==", "+359888888118", false, "Doctor", "53215ad4-e711-4bd8-ac7e-ac5cf8326483", false, "k_stoicheva" },
                    { "b67a1365-3902-4728-8c9f-05369b1556b7", 0, null, "fe1e321d-fc45-43ed-8747-b73d90c302ee", "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "30.11.2022", null, null, "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", "AQAAAAEAACcQAAAAEBv/Jg+SGdO65cnwxjD3pigRou7/lmg4+1p9w4yNDeGNw9tq1Xnxttu6vhKEb5KgnQ==", "+359888888112", false, "Doctor", "14f07876-9c2a-4026-803f-2901928ba937", false, "m_vuldjev" },
                    { "b922fbb1-e1e8-41c6-a903-931e1cd4b845", 0, null, "dac2099c-53ca-4d68-9e50-2c3e1bc3ede6", "f5628f68-e883-4b6a-8c6c-2511314af5a1", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "30.11.2022", null, null, "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", "AQAAAAEAACcQAAAAENyUjrzXpR3q1vfijXPXoonZ1Z9jHUm/HqZ7foBnUCmc8xnVzRxO1kU4VV9EsK6g1w==", "+359888888104", false, "Doctor", "300d0670-9eb1-4054-a9f4-40bbbbb1688c", false, "t_stoev" },
                    { "c83d8295-ff6a-4644-a44a-c2bc294b220e", 0, null, "0d932d71-1fcf-4edb-b35a-c82281badec9", "5b0923f7-da08-4af1-a391-d0561a534a42", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "30.11.2022", null, null, "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", "AQAAAAEAACcQAAAAEG+9hxTIJBTnREAeQ8yroILDGyfw7dlr/yjmZydNYi3AKmTYOS71oQ/BxqZ1NiKdlQ==", "+359888888116", false, "Doctor", "2dcbb35f-2fb4-466f-84e3-15d12512227b", false, "k_atanasova" },
                    { "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb", 0, null, "c76cd28c-393d-43a9-a13b-ec227e11fd4a", "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "a_tomova@mc-bg.com", false, "Антония", 2, false, "30.11.2022", null, null, "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", "AQAAAAEAACcQAAAAEFfOCWijwFAQYAmzwUK9I4TyGE79z+VpBBEJLzJ7SqeGns3OM7YPrp6TV6lO9DuUqg==", "+359888888114", false, "Doctor", "9a47c23b-b9e3-4197-a314-3c6268eeb34d", false, "a_tomova" },
                    { "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788", 0, null, "a769b82d-2127-4d5b-b881-282909e36304", "be158f8c-bc22-4469-b01c-b9e928499a05", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "30.11.2022", null, null, "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", "AQAAAAEAACcQAAAAEPB9aS6ih6UMJhwS7QGb8K77NzWGhfEaboM37AAwtwdQEjPGFjdM4OTeYAvTzpyR7w==", "+359888888120", false, "Doctor", "4b5b37a6-40b8-4123-b202-b0eb515deb5a", false, "r_uzunova" },
                    { "cf6e7092-584c-460d-9538-feee4a5b53d9", 0, null, "22f3f316-58ea-40ba-8917-0d473596fd8c", "97fde454-7892-40ab-acff-c641b14d1eab", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "30.11.2022", null, null, "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", "AQAAAAEAACcQAAAAEDBsbXtjxJP+SmT52U84+Vc/R3+qA1OeAkpWV7PCoAFMZp3li1i5TTSPUOi6cKbusw==", "+359888888107", false, "Doctor", "97b57e3f-0a8a-4b3f-ac4b-bc3f9459981e", false, "d_georgiev" },
                    { "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b", 0, "e0b65a18-1271-4146-a730-8e80a24cea78", "b46254a5-6df8-43ae-8219-a71bbdce1d31", null, "admin@mc-bg.com", false, "Ивайло", 1, false, "30.11.2022", null, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEFUfngUe8U/LEV+GFqdSN9A9ibr/9ZRhwBH9Lal5MxAKLEX6/Tt9Bgah7zgZm+Vqzw==", "+359888888888", false, "Administrator", "2bed4cba-b6b4-4b58-a95c-bb839c899c9c", false, "admin" },
                    { "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760", 0, null, "a860d8a1-5fc7-4639-b92b-761ff260ca18", "f40725ef-50bd-4b7b-b2ab-df41d875781e", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "30.11.2022", null, null, "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", "AQAAAAEAACcQAAAAEKNUr2mBr6Pku1IBhmbgKUy1ag8gso9CF+Hzbpoz1B/uN2WECun3lNrMN0LzzohkOg==", "+359888888109", false, "Doctor", "ec3b097f-00a5-479a-803a-66db51010086", false, "s_tochev" },
                    { "da3da29d-5411-4750-a5c4-e4ae4e22965c", 0, null, "0002213b-27df-4389-b4eb-60c9bb70cc89", "499be402-5520-453d-a17d-3a52ac6ad798", "m_velikova@mc-bg.com", false, "Мими", 2, false, "30.11.2022", null, null, "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", "AQAAAAEAACcQAAAAECSmsTTN+a17DZDvL5kjISJ/7qpI/HTqOX4WqAoiq2AuIoMKqS7f2vAxy2xvLlBL3g==", "+359888888103", false, "Doctor", "20e4ae1c-86ac-4ab6-8214-7f6056140c43", false, "m_velikova" },
                    { "f092f500-00e2-4544-952a-4cb91320558d", 0, null, "73e4ddb1-5d42-40f1-8790-4eafd2a470bf", "734a6dcd-060c-4108-a184-84997a5da2d1", "h_hristov@mc-bg.com", false, "Христо", 1, false, "30.11.2022", null, null, "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", "AQAAAAEAACcQAAAAEM1t0CDciPu7qNeHSXLz+leekmmzIEpfijAd9kuEnY5wwl+a3vSFaDIZ+gptVgx7dg==", "+359888888113", false, "Doctor", "9d8556a5-1583-44a2-89f1-d86a1062a06e", false, "h_hristov" },
                    { "f1221132-3b9f-4f33-9e4d-1514bc0221e8", 0, null, "6794c5a3-54f7-432c-8ce1-0f4980b16f87", "4775e4ac-4930-4113-bb19-6ed94e12fa24", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "30.11.2022", null, null, "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", "AQAAAAEAACcQAAAAECnzu59vCzNlfBbA2MPVUSzJ07JXDkY0y48XuVZPrXOmBuf47zXJsd0ZcGtz9Bearg==", "+359888888102", false, "Doctor", "db24aea3-d4be-453e-87b2-6b8cdbc96950", false, "b_petkova" },
                    { "f142f846-dbe7-420e-bbce-4a9f83e36980", 0, null, "bec9d1c7-ba1e-42fa-8dcd-2c36c1e8cd62", "221de519-48d4-41cd-befd-1b414b2fea57", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "30.11.2022", null, null, "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", "AQAAAAEAACcQAAAAEBB7v5bDZjYpkI9X03VZU5R85T6K9P0h2wnHOH6GtD2SkG/iJgQgZNBX5+7Aael9ug==", "+359888888108", false, "Doctor", "68c3a746-d684-4a36-9af8-f45328f1a5c7", false, "r_ruseva" },
                    { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", 0, null, "accd6d37-b9a9-4aa0-9136-95a5e0f6822c", null, "lab_vivanova@mc-bg.com", false, "Ваня", 2, false, "30.11.2022", "fb454478-8b7c-48bd-86b4-a0b36bf261a2", null, "Иванова", false, null, "LAB_VIVANOVA@MC-BG.COM", "LAB_VIVANOVA", "AQAAAAEAACcQAAAAELq7XrJ1TotHoFyi0Ilf1nQufj+EckvSHZgVd+xyXWHGDKFjzEkoibntCI0vsELSYQ==", "+359888888881", false, "Laborant", "263cae44-7417-4da5-bc12-3f5da6ab040b", false, "lab_vivanova" }
                });

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
                    { 8, "Вътрешни болести" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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
                    { 50, "Озонотерапевт" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
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
                    { 75, "УНГ" },
                    { 76, "Уролог" },
                    { 77, "Физиотерапевт" },
                    { 78, "Хематолог (Клинична хематология)" },
                    { 79, "Хематолог (Трансфузионна хематология)" },
                    { 80, "Хирург" },
                    { 81, "Хомеопат" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "Egn", "OutOnDate", "UserId" },
                values: new object[] { "e0b65a18-1271-4146-a730-8e80a24cea78", "9305264209", null, "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "b922fbb1-e1e8-41c6-a903-931e1cd4b845" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "32d19b1e-b575-488e-860b-18eb1dbec58d", "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "485b1cfe-2066-4b04-9de3-716683e92111", "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "30d8b959-5d2a-4399-a252-5f0e36664bc3", "fb454478-8b7c-48bd-86b4-a0b36bf261a2" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707192482", null, "https://i.imgur.com/E5Yga61.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 44, "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "182466cf-4d18-4ba4-940c-71e8f445335c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7702262899", null, "https://i.imgur.com/oFAixEu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 44, "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "22081bf0-1049-45ba-a9b3-3171271f1341", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", null, "https://i.imgur.com/73peyhD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 1, "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "221de519-48d4-41cd-befd-1b414b2fea57", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9401161818", null, "https://i.imgur.com/LKNbRcV.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 31, "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "473d0775-d1d3-4439-940b-fe949652859f", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9107227892", null, "https://i.imgur.com/yQmifbA.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 24, "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "4775e4ac-4930-4113-bb19-6ed94e12fa24", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7412135099", null, "https://i.imgur.com/66UFmBy.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 8, "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "499be402-5520-453d-a17d-3a52ac6ad798", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707015574", null, "https://i.imgur.com/7VzO2Pm.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 8, "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "4b95c2a0-314d-414d-a80a-db46ef2f810a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7903129851", null, "https://i.imgur.com/9gZeKsk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 1, "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "4be5615e-0d14-4756-a090-bd157133f463", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", null, "https://i.imgur.com/dj7NvUl.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 77, "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "5b0923f7-da08-4af1-a391-d0561a534a42", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8606163716", null, "https://i.imgur.com/GhnW3gD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 75, "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7411033533", null, "https://i.imgur.com/WkPS5Ds.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 60, "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "734a6dcd-060c-4108-a184-84997a5da2d1", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", null, "https://i.imgur.com/42rKRT2.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 55, "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "97fde454-7892-40ab-acff-c641b14d1eab", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7504196361", null, "https://i.imgur.com/62LMUUe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 24, "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "992d83f0-1439-40dc-95f4-5a708fd3c086", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7801138974", null, "https://i.imgur.com/6NU5RvT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 76, "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7609186138", null, "https://i.imgur.com/2HO3b8v.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 60, "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9002041303", null, "https://i.imgur.com/fkXWOZT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 75, "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "be158f8c-bc22-4469-b01c-b9e928499a05", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", null, "https://i.imgur.com/hx5EEMp.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 77, "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7904245096", null, "https://i.imgur.com/2xoQC2H.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 11, "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9103145306", null, "https://i.imgur.com/f5yYnPN.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 76, "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", null, "https://i.imgur.com/YO1cWgu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 55, "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "f40725ef-50bd-4b7b-b2ab-df41d875781e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8112144846", null, "https://i.imgur.com/YK3Y8Ya.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 31, "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "f5628f68-e883-4b6a-8c6c-2511314af5a1", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "6902251307", null, "https://i.imgur.com/oSv4hEn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 11, "b922fbb1-e1e8-41c6-a903-931e1cd4b845" }
                });

            migrationBuilder.InsertData(
                table: "Laborants",
                columns: new[] { "Id", "Egn", "OutOnDate", "UserId" },
                values: new object[] { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", "8412194792", null, "fb454478-8b7c-48bd-86b4-a0b36bf261a2" });

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
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SheduleId",
                table: "Doctors",
                column: "SheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "IX_Laborants_UserId",
                table: "Laborants",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryPatients_UserId",
                table: "LaboratoryPatients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "Administrators");

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
                name: "Laborants");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "LaboratoryPatients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Shedules");

            migrationBuilder.DropTable(
                name: "Specialties");
        }
    }
}
