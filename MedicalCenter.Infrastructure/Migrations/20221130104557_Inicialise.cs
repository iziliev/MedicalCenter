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
                    { "3ec20065-9336-4017-89d0-1ee96dc6e4ba", "572545c0-31c9-40ca-926d-435d7ec5be8f", "Laborant", "LABORANT" },
                    { "69d06a34-d864-4930-8a7d-f97055530db7", "0e7fe5bc-05ea-4ae6-9c5d-d6de2a596697", "Administrator", "ADMINISTRATOR" },
                    { "6b894a41-5fec-4ca3-81eb-2038e01bcce0", "37b19683-20e0-4478-8bc0-a97cdd6a3dfb", "LaboratoryUser", "LABORATORYUSER" },
                    { "f1321c5f-1fee-426a-833b-5d19cb9bdf42", "3ef01e46-488b-4684-8ffc-c96965566013", "User", "USER" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "a15bd5cb-2f20-434e-a7e6-9eaa3734542d", "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdministratorId", "ConcurrencyStamp", "DoctorId", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LaborantId", "LaboratoryPatientId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "041639c2-fcd2-4899-a5c6-2025cbb3c1c7", 0, null, "188ac354-7685-47fd-bccc-d80aabba18e8", "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "30.11.2022", null, null, "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", "AQAAAAEAACcQAAAAEACU/Kz1k4f0yasjvHpb8M7RgK4i0wJm0r1FwW7UV31mIyGgulVPyQjEN00N8hBv7A==", "+359888888115", false, "Doctor", "4ffae09e-07ff-4633-95ec-16923e5ac23c", false, "k_moskova" },
                    { "095da4be-9891-4cd9-a2ad-05dbbb0e2085", 0, null, "6fc0e3d3-3b8c-426d-ace5-6b39a191d3a3", "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "30.11.2022", null, null, "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", "AQAAAAEAACcQAAAAEEHHcNHgJgSrVwQ4nu4FqnL3xBhRX0HneYpqdkgnnhSmPxzgpZZQlhtrl8NwlkIjmw==", "+359888888111", false, "Doctor", "df4920d8-ca30-4d93-913a-6deab88d7de3", false, "r_ikonomov" },
                    { "0bbf2307-d024-44b4-917f-a52ab9ddc013", 0, null, "9a5443ec-10c8-4e3d-8275-d558d07aedea", "473d0775-d1d3-4439-940b-fe949652859f", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "30.11.2022", null, null, "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", "AQAAAAEAACcQAAAAEOIrVe9yY+a0mLQ5sOn3kRrZEHnSVpHsuwA1mpaU7MYXOBKl0PtMZdWOqhj6vM0UFQ==", "+359888888106", false, "Doctor", "4b58aecf-6cf1-417e-b73b-81daac2e2207", false, "m_kalinkova" },
                    { "3f9592ad-6af3-4021-808f-39d7aa9246e9", 0, null, "bf146713-f4f2-4e2f-b4d3-32c915e3c7cb", "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "30.11.2022", null, null, "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", "AQAAAAEAACcQAAAAEIaFP2NkY5xXg5hvtzILq4b4f3sdemYcdfbupNfUbEgNj07WJqahinFCNA+Y9nKGxg==", "+359888888105", false, "Doctor", "75fe8af8-b499-4ca9-95a5-cec16c84b248", false, "m_blagoeva" },
                    { "734267e9-a59b-44c3-baee-7e52a2bd1c29", 0, null, "fd42f76a-3c74-4107-8ce1-3d3e39b36fc7", "4be5615e-0d14-4756-a090-bd157133f463", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "30.11.2022", null, null, "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", "AQAAAAEAACcQAAAAEAro/xOscSGTjHjCYhB5bm7vB/gdq7Bb2UMyP67eBl0CDL6dSgTMDq7V27qWgYhNxA==", "+359888888121", false, "Doctor", "7442ef24-e6b4-4658-b5e1-393ad3b3dd61", false, "i_belcheva" },
                    { "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e", 0, null, "2359af68-2cfd-43e2-9e53-8c2084a99caa", "22081bf0-1049-45ba-a9b3-3171271f1341", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "30.11.2022", null, null, "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", "AQAAAAEAACcQAAAAEOMpDJkOJlYd+ysoNM3LHXsBqFoncabNEMRfEHLY79e2h5XoSe++dnxStfasGaC4+g==", "+359888888101", false, "Doctor", "823e322a-2a1b-4907-9d3d-073229ebba7f", false, "s_slavchev" },
                    { "7c513995-bed0-4be3-b768-304cd697c3f9", 0, null, "7bb236fb-8576-48eb-87b3-57837581d83e", "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "n_paskov@mc-bg.com", false, "Николай", 1, false, "30.11.2022", null, null, "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", "AQAAAAEAACcQAAAAEMxpQ7xmI2MRuBQTF2sln5PIZsEiO6LHvYIM1yBghJgrWuKPPQhBGN23obgwMSXkvg==", "+359888888119", false, "Doctor", "2dfc3ba8-4981-4600-bdce-aac9dbf07b5f", false, "n_paskov" },
                    { "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca", 0, null, "87d6f9f1-8073-47af-b9f0-0f5d232dccee", "182466cf-4d18-4ba4-940c-71e8f445335c", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "30.11.2022", null, null, "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", "AQAAAAEAACcQAAAAEEA0ZqU9cmjGwK3qthfPuruMJ6l8o/ghB9qmT4sam/ZIIpyyHHrIssnzdJhYDz+k2A==", "+359888888110", false, "Doctor", "f0fe8690-ba22-48f5-8996-2c5d76b1515a", false, "s_atanasova" },
                    { "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe", 0, null, "591ed979-60a2-4220-9710-d6563c6d7292", "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "30.11.2022", null, null, "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", "AQAAAAEAACcQAAAAEII/FcE09SB1yJbOJ9MuaZeXsRGaQ+ywDPfDvDfiRZBdbst9B1ivJHjsIAsBBc0G6w==", "+359888888117", false, "Doctor", "2bae498f-1f60-456a-9f60-922ddb31bfb1", false, "g_kuchukov" },
                    { "9da9587f-e28e-4289-a559-7407d3ea34a5", 0, null, "f3070bc4-c138-4b9f-9e27-4a58e5d07e44", "4b95c2a0-314d-414d-a80a-db46ef2f810a", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "30.11.2022", null, null, "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", "AQAAAAEAACcQAAAAEKEbKWah0Git5QXEK9f0KEiEQRQl9173d3PrrEVQ2wUD5P4s2qhNLFZ0f4SarUbz0g==", "+359888888100", false, "Doctor", "3736f457-82f7-4dd8-9ae0-649302a22438", false, "m_monastirska" },
                    { "a8d60b9c-6bef-4eff-af47-bcce7daf311b", 0, null, "28f44e53-654f-4307-bed0-5fb72e625654", "992d83f0-1439-40dc-95f4-5a708fd3c086", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "30.11.2022", null, null, "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", "AQAAAAEAACcQAAAAEMTJ5Jo9XI+x8BRAQQ0fLVqlIgnNaNz3maH3BSDQfEg79zQ9n//CeFe52+sRW0bBqA==", "+359888888118", false, "Doctor", "990387b2-aace-4291-a67e-5df1457cef75", false, "k_stoicheva" },
                    { "b67a1365-3902-4728-8c9f-05369b1556b7", 0, null, "715ec61c-0d8b-4444-b65b-cbb3f1f418cb", "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "30.11.2022", null, null, "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", "AQAAAAEAACcQAAAAEEmOLS7R1wkgsrwo1Tl3dYUQ87b+QqKZy4WQoGW01lqllY9ey/JGhsAxBheyti+msg==", "+359888888112", false, "Doctor", "51130571-2b56-481a-871b-7acd8f44c140", false, "m_vuldjev" },
                    { "b922fbb1-e1e8-41c6-a903-931e1cd4b845", 0, null, "f2adcc5b-0411-4739-89e1-1d5f93f8929f", "f5628f68-e883-4b6a-8c6c-2511314af5a1", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "30.11.2022", null, null, "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", "AQAAAAEAACcQAAAAECreZCOLID/f4Eqxlg/VHz3qvgVO0IdJ8uBb6X4lqxRZhX3C3r1L6MR2xoNewzSQIw==", "+359888888104", false, "Doctor", "c4035d1d-fa2f-49fd-a87f-ad65918e1457", false, "t_stoev" },
                    { "c83d8295-ff6a-4644-a44a-c2bc294b220e", 0, null, "a85376bb-6337-4151-a7f0-f752a8b21548", "5b0923f7-da08-4af1-a391-d0561a534a42", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "30.11.2022", null, null, "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", "AQAAAAEAACcQAAAAEEtzLb262KgxxpZ1Fn0lUFIOviPCRawBacC3XeVDRQEMkRcYjMXYaB8EDUaUZg6JVw==", "+359888888116", false, "Doctor", "ea4c772b-797c-4c8e-9792-da8d78c1f04a", false, "k_atanasova" },
                    { "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb", 0, null, "70c88a64-273d-4717-b866-b86ec0bec9f5", "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "a_tomova@mc-bg.com", false, "Антония", 2, false, "30.11.2022", null, null, "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", "AQAAAAEAACcQAAAAEE0B8nAjCi0UKg6V1sdKPMMpAZkRp1NcIe8jjvfj9bORtfW7wV6sO8mec8ADasbQKg==", "+359888888114", false, "Doctor", "b6b6f593-65c1-444d-a978-be8a86d2f604", false, "a_tomova" },
                    { "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788", 0, null, "ceb31c76-5ec0-4411-8d63-5d3f7d298831", "be158f8c-bc22-4469-b01c-b9e928499a05", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "30.11.2022", null, null, "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", "AQAAAAEAACcQAAAAEHDO9v/UwGL0JG1Ef/+OEGQFvbpl6vnaR1ZAmL3RR+gb7JxJoidWpzCErIw+LNxdvg==", "+359888888120", false, "Doctor", "eda90ba0-f0e8-4290-a151-35192c4607f9", false, "r_uzunova" },
                    { "cf6e7092-584c-460d-9538-feee4a5b53d9", 0, null, "9e467f5a-736a-4e30-bc80-c0599e2933c5", "97fde454-7892-40ab-acff-c641b14d1eab", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "30.11.2022", null, null, "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", "AQAAAAEAACcQAAAAEMb9OSGajduZpX5pSQzts1rhUEgLZL8RqeRhIxyqyzaQRBkR3HDkbUf8yCbz8t4wyA==", "+359888888107", false, "Doctor", "1ab9dfd1-c7c9-49bb-ab9e-7a2963d9d0cf", false, "d_georgiev" },
                    { "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b", 0, "e0b65a18-1271-4146-a730-8e80a24cea78", "5e719529-6b00-4c60-9653-8c9c085a234b", null, "admin@mc-bg.com", false, "Ивайло", 1, false, null, null, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEFKeB8bWio7xHbcvRKj7VpDwqj2KC3dkw4q3l0/G+hSdaTF4OZGpExrSZI8dpNYBEg==", "+359888888888", false, "Administrator", "dd556a14-a4da-4f40-826e-7b4b35f32e85", false, "admin" },
                    { "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760", 0, null, "28a3fcc1-7631-4817-86e2-1b424fac63eb", "f40725ef-50bd-4b7b-b2ab-df41d875781e", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "30.11.2022", null, null, "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", "AQAAAAEAACcQAAAAEI4CGHtO8n6BpBThl/d/PGr4vhJCV6Wifn8B9E/uM5WFVKs2O06K7T2LH+4sYUZlhQ==", "+359888888109", false, "Doctor", "423a368e-ecb5-4f08-ae3c-016677d7c890", false, "s_tochev" },
                    { "da3da29d-5411-4750-a5c4-e4ae4e22965c", 0, null, "261312c0-6ef6-4c4a-a83e-aa4ed3168ff2", "499be402-5520-453d-a17d-3a52ac6ad798", "m_velikova@mc-bg.com", false, "Мими", 2, false, "30.11.2022", null, null, "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", "AQAAAAEAACcQAAAAEIjXX7KNqbFjpGXKCpFaHvTdbIMYlUwYReK3gBvlOHJDyC4kiZpn5eKdmsoIfyzcFg==", "+359888888103", false, "Doctor", "bd2d7c4a-8f64-4be4-a3a0-c3f65c1c5cf8", false, "m_velikova" },
                    { "f092f500-00e2-4544-952a-4cb91320558d", 0, null, "03d237b8-2d71-4a88-9b67-d3445543f92a", "734a6dcd-060c-4108-a184-84997a5da2d1", "h_hristov@mc-bg.com", false, "Христо", 1, false, "30.11.2022", null, null, "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", "AQAAAAEAACcQAAAAEHvh10zM+5ms11KlukphcYaCz2c32fMLI4j9Z5AEQ0zO3rfVAx+zoC5n0g0kzZ4HlA==", "+359888888113", false, "Doctor", "3175560f-a1da-449d-8cfc-d1bc353e2258", false, "h_hristov" },
                    { "f1221132-3b9f-4f33-9e4d-1514bc0221e8", 0, null, "1d46d4b1-b57c-4d00-a868-4ee5f6054e2e", "4775e4ac-4930-4113-bb19-6ed94e12fa24", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "30.11.2022", null, null, "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", "AQAAAAEAACcQAAAAEAr+jbkU4mGt+wvnRF76oltOmN9iI50uM968DpNyM7n0Tvz9AeeiPdSfAQdueyS1Fg==", "+359888888102", false, "Doctor", "c16b133b-5b4f-4034-b6cb-814134831629", false, "b_petkova" },
                    { "f142f846-dbe7-420e-bbce-4a9f83e36980", 0, null, "7ea21f78-9370-4647-b5cf-6f9fb188b825", "221de519-48d4-41cd-befd-1b414b2fea57", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "30.11.2022", null, null, "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", "AQAAAAEAACcQAAAAEOXuxzP5dTWf18FiTpxXRBNxz4TyxmEOvC07RWqUyhcsZ1j0fJnLtDlo7fJJuVWKpg==", "+359888888108", false, "Doctor", "7acf7616-5383-4e58-a29e-8813f72ad6dc", false, "r_ruseva" },
                    { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", 0, null, "1e9186b3-c56a-4544-a8af-11cef8c25579", null, "lab_vivanova@mc-bg.com", false, "Ваня", 2, false, "30.11.2022", "fb454478-8b7c-48bd-86b4-a0b36bf261a2", null, "Иванова", false, null, "LAB_VIVANOVA@MC-BG.COM", "LAB_VIVANOVA", "AQAAAAEAACcQAAAAEPnQgcnrRnpqoWKMzyYAlPeO/WQG6x9k19td3V6GS4b6ZN7DH5e0kTHPu4BhlqBSVg==", "+359888888881", false, "Laborant", "e001cb37-8332-4f01-9e48-ecbb925c0cb0", false, "lab_vivanova" }
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
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "b922fbb1-e1e8-41c6-a903-931e1cd4b845" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "69d06a34-d864-4930-8a7d-f97055530db7", "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "fd455a66-249b-4d16-b5a9-af8d92c6c231", "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "3ec20065-9336-4017-89d0-1ee96dc6e4ba", "fb454478-8b7c-48bd-86b4-a0b36bf261a2" }
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
