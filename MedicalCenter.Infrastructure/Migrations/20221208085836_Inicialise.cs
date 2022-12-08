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
                    { "1382ab01-813e-4993-ba82-9b55dafd62a6", "b05f18e7-a048-4d0b-987a-7d4080822eb1", "User", "USER" },
                    { "21054893-923f-4121-980e-d45fd8cb2d2c", "114c17fb-ec41-4dc5-bc70-d979e49ac6b8", "Administrator", "ADMINISTRATOR" },
                    { "44078427-01ab-4211-b865-b97d481bd493", "8b425ef2-1970-4e1c-ab0d-f5879bb05fcc", "Laborant", "LABORANT" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "9fb8904b-7a38-46c8-96ea-1e4699a87518", "Doctor", "DOCTOR" },
                    { "c37e5c42-68fc-40b6-82b6-3bcb6b06c8b7", "b3524dcf-44c8-4802-acaa-c37b1288fcb3", "LaboratoryUser", "LABORATORYUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdministratorId", "ConcurrencyStamp", "DoctorId", "Email", "EmailConfirmed", "FirstName", "GenderId", "IsOutOfCompany", "JoinOnDate", "LaborantId", "LaboratoryPatientId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "041639c2-fcd2-4899-a5c6-2025cbb3c1c7", 0, null, "0deeb384-50ad-4bc8-90b4-4b4a9a9ad2f3", "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "k_moskova@mc-bg.com", false, "Катерина", 2, false, "08.12.2022", null, null, "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", "AQAAAAEAACcQAAAAELpDW871DTUWggvQspz2kdUGJ19RJhW1r2w7DnAkgnUrzg7BL1Viwz8PErsGseGz4w==", "+359888888115", false, "Doctor", "7d8ef4e3-4557-47e5-9222-fe636362d879", false, "k_moskova" },
                    { "095da4be-9891-4cd9-a2ad-05dbbb0e2085", 0, null, "b1b756a3-74a1-40ee-a540-01822020ee82", "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "r_ikonomov@mc-bg.com", false, "Росен", 1, false, "08.12.2022", null, null, "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", "AQAAAAEAACcQAAAAEI/cA7Yhj1buvDCm7HenJ9gYaxCeUMHBpCO5V8Bo836Gw+YTKdYyh5H8k4VAT7ffhg==", "+359888888111", false, "Doctor", "16070f7f-c522-4b59-83ff-52a2f3015dad", false, "r_ikonomov" },
                    { "0bbf2307-d024-44b4-917f-a52ab9ddc013", 0, null, "ab480acf-da72-4249-a1ea-66a58e678a87", "473d0775-d1d3-4439-940b-fe949652859f", "m_kalinkova@mc-bg.com", false, "Мария", 2, false, "08.12.2022", null, null, "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", "AQAAAAEAACcQAAAAEFHIX2aY+kQM5s8jt4CvtNgvLNostE2a3lRrnzEEK9oHMPYaHX5TUURVXVrcNonG1g==", "+359888888106", false, "Doctor", "c649c5f8-48f7-4909-97ed-8064e9ce9cc2", false, "m_kalinkova" },
                    { "3f9592ad-6af3-4021-808f-39d7aa9246e9", 0, null, "48fe697b-6840-40a4-be97-52573cdc4c30", "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "m_blagoeva@mc-bg.com", false, "Мая", 2, false, "08.12.2022", null, null, "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", "AQAAAAEAACcQAAAAEEE6P26BwHN1o9hyU0PQ0m1mexnHzWcH1+UWk6vTDsMUVf2oeiSuCsJdkm+1YvgyLQ==", "+359888888105", false, "Doctor", "05c849ee-33be-4a7f-bb90-bff15bbde00c", false, "m_blagoeva" },
                    { "734267e9-a59b-44c3-baee-7e52a2bd1c29", 0, null, "ebef979c-77f2-4b63-ad51-7b6e753a52fe", "4be5615e-0d14-4756-a090-bd157133f463", "i_belcheva@mc-bg.com", false, "Ирина", 2, false, "08.12.2022", null, null, "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", "AQAAAAEAACcQAAAAECahy+zAcMUaHrOdFhZmoTgUX0NEth41I/BHa+Iy8IMId70n88/ssPIRU+PLcWjjuQ==", "+359888888121", false, "Doctor", "f55a855b-a62c-4490-bb70-35a3bed75b0e", false, "i_belcheva" },
                    { "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e", 0, null, "8fab32cf-328e-4928-875d-35ffe0507f61", "22081bf0-1049-45ba-a9b3-3171271f1341", "s_slavchev@mc-bg.com", false, "Станислав", 1, false, "08.12.2022", null, null, "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", "AQAAAAEAACcQAAAAEF1KKvR4ikV8FaNqoyfMNqaqKBGAxQascX1W12j6V3SX7B07QAu04rhySRbo4W6XUw==", "+359888888101", false, "Doctor", "e9cc609c-383f-41bf-879e-db1e68549855", false, "s_slavchev" },
                    { "7c513995-bed0-4be3-b768-304cd697c3f9", 0, null, "5ee873b3-9689-4830-8060-f2bc1b496e8f", "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "n_paskov@mc-bg.com", false, "Николай", 1, false, "08.12.2022", null, null, "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", "AQAAAAEAACcQAAAAELFB/GAxwq/gcpyjINBzAlnOF2aa921JhETXySkMNE4ijzNNIW44kHuyFvOv8HpI1Q==", "+359888888119", false, "Doctor", "d5aa6cb2-7b46-42c2-a1de-e99709b0c3b5", false, "n_paskov" },
                    { "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca", 0, null, "1c3289e8-351b-48d8-b615-18ecbb1ebf2c", "182466cf-4d18-4ba4-940c-71e8f445335c", "s_atanasova@mc-bg.com", false, "Стела", 2, false, "08.12.2022", null, null, "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", "AQAAAAEAACcQAAAAEFqcXA7lctA65w/TLYS6G8E8Qq37nwr/25l7KPQF2ZBBmdSjynD8Vytrhz5PnadTdg==", "+359888888110", false, "Doctor", "e19b589c-e66a-42f1-9a51-29eb3341993a", false, "s_atanasova" },
                    { "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe", 0, null, "a10881b3-c2d3-420d-8332-e93bc08f8574", "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "g_kuchukov@mc-bg.com", false, "Георги", 1, false, "08.12.2022", null, null, "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", "AQAAAAEAACcQAAAAEKXxBvjTJCJLo1YZWocL5pKIftE40VmHUHb3aX14Af69+ny/iIYT+WElyijDX/CcIQ==", "+359888888117", false, "Doctor", "048eed50-8775-4d08-95e9-f55195dc6b94", false, "g_kuchukov" },
                    { "9da9587f-e28e-4289-a559-7407d3ea34a5", 0, null, "9633606d-b859-4ad5-af71-8e6893b24005", "4b95c2a0-314d-414d-a80a-db46ef2f810a", "m_monastirska@mc-bg.com", false, "Маргарита", 2, false, "08.12.2022", null, null, "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", "AQAAAAEAACcQAAAAEHdJ1nJbtromB78jd3e47j4tBbcpYfsS21pRNytH6ynYfq0kBnN1h7RXO2oPJ2fmjw==", "+359888888100", false, "Doctor", "4965b1b1-a5c2-4b41-8866-8cf9fd05c648", false, "m_monastirska" },
                    { "a8d60b9c-6bef-4eff-af47-bcce7daf311b", 0, null, "1d541f25-21ce-4372-8977-f39b6ad16be7", "992d83f0-1439-40dc-95f4-5a708fd3c086", "k_stoicheva@mc-bg.com", false, "Катина", 2, false, "08.12.2022", null, null, "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", "AQAAAAEAACcQAAAAEMoWWNE+WJHzT1sLrzCNfLe1BXjVA+on9TWYg8QmW37Ymgck8X47O2j18m6Mg8jF5A==", "+359888888118", false, "Doctor", "4531e1a5-40be-4b69-8f3b-b2f5f802016e", false, "k_stoicheva" },
                    { "b67a1365-3902-4728-8c9f-05369b1556b7", 0, null, "dd503749-7a92-43eb-8bbd-dab6cd6519ce", "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "m_vuldjev@mc-bg.com", false, "Михаил", 1, false, "08.12.2022", null, null, "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", "AQAAAAEAACcQAAAAEFdXYa/1EKSNh7XCIeoHn6GxGg/YkTxQfgM2nPO8j9n9KsjIKrOVQsB37p4Zip8CjQ==", "+359888888112", false, "Doctor", "fb026c6b-87d6-48c8-a239-16c894178f02", false, "m_vuldjev" },
                    { "b922fbb1-e1e8-41c6-a903-931e1cd4b845", 0, null, "1a18b9d4-9348-4144-a651-4a328b80f600", "f5628f68-e883-4b6a-8c6c-2511314af5a1", "t_stoev@mc-bg.com", false, "Тодор", 1, false, "08.12.2022", null, null, "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", "AQAAAAEAACcQAAAAEGO+XpVO1HreBhrP7Z+I1qvamK0BAXSa7lrMhAk/TxHw/zMTFUt5eLP/KZ1p1ZmDyw==", "+359888888104", false, "Doctor", "3c66efd9-7869-4632-bafb-3974c05a5301", false, "t_stoev" },
                    { "c83d8295-ff6a-4644-a44a-c2bc294b220e", 0, null, "6eb39580-46fd-44cc-8499-0ec708869890", "5b0923f7-da08-4af1-a391-d0561a534a42", "k_atanasova@mc-bg.com", false, "Кристина", 2, false, "08.12.2022", null, null, "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", "AQAAAAEAACcQAAAAEFFKpC4rbgA07smhDcbbcXRXEsHhvLaab1Cfdqt+5/xJO9foC7woWGZTYj9EvRZGPA==", "+359888888116", false, "Doctor", "fb27012b-60e9-4efc-bae4-434ba22853e4", false, "k_atanasova" },
                    { "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb", 0, null, "2d34b537-8fa8-4183-8e56-de2189114157", "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "a_tomova@mc-bg.com", false, "Антония", 2, false, "08.12.2022", null, null, "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", "AQAAAAEAACcQAAAAEAEZ8q6Q7bXKvVmDcGg2xK58wAZulo/vdhHYJGcWWukMkT+IN6qZUWjojHcrD9/Brw==", "+359888888114", false, "Doctor", "2fcf059a-5685-434e-976a-a918c5d628a1", false, "a_tomova" },
                    { "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788", 0, null, "be66536c-bdd5-433d-8384-367eccb39ece", "be158f8c-bc22-4469-b01c-b9e928499a05", "r_uzunova@mc-bg.com", false, "Росица", 2, false, "08.12.2022", null, null, "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", "AQAAAAEAACcQAAAAEJ36lLPZkjrsH6gdKUvdhSoY9WVxOMOYmML+S1jKES4fhFLM94w0dn9b2bgVy+uHDQ==", "+359888888120", false, "Doctor", "fd581595-bb8f-431e-96bc-536455ad2f2c", false, "r_uzunova" },
                    { "cf6e7092-584c-460d-9538-feee4a5b53d9", 0, null, "ad22848f-1a2d-4f93-a25b-2adcf20b078e", "97fde454-7892-40ab-acff-c641b14d1eab", "d_georgiev@mc-bg.com", false, "Димитър", 1, false, "08.12.2022", null, null, "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", "AQAAAAEAACcQAAAAEAWLu9RRwjesusHDx//8uETpp118R5G3Q0aVxgEuA3JLq+tIf8HBTxSTL6tGi8DEvQ==", "+359888888107", false, "Doctor", "aade12d7-eddc-4e4e-8d73-fef3c22d0762", false, "d_georgiev" },
                    { "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b", 0, "e0b65a18-1271-4146-a730-8e80a24cea78", "73f213b1-52de-47fc-9e60-292a86b5e94c", null, "admin@mc-bg.com", false, "Ивайло", 1, false, "08.12.2022", null, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEJ9kDxn4vudf2sIcU64peYcXYFLNXoQy41e3il06bgsZUO+a3DZGyd7Fmh8Ra8/vkA==", "+359888888888", false, "Administrator", "efaf79b1-36b5-4cec-bb27-87d3c9d0fcae", false, "admin" },
                    { "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760", 0, null, "7a384fc2-536e-46a7-80e4-dc7c00abbfea", "f40725ef-50bd-4b7b-b2ab-df41d875781e", "s_tochev@mc-bg.com", false, "Сотир", 1, false, "08.12.2022", null, null, "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", "AQAAAAEAACcQAAAAEP3qrge848YGkUbXckvghXBV3KsKxqgPmsnGPVpnaJynSwvEA6LsQl7sOx1/AZDhzg==", "+359888888109", false, "Doctor", "6545ed8a-3eb1-4f0f-a8e7-460c14d2f565", false, "s_tochev" },
                    { "da3da29d-5411-4750-a5c4-e4ae4e22965c", 0, null, "4ef228d6-1d3b-487f-9938-665dc6c0f7e5", "499be402-5520-453d-a17d-3a52ac6ad798", "m_velikova@mc-bg.com", false, "Мими", 2, false, "08.12.2022", null, null, "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", "AQAAAAEAACcQAAAAEIJBd/RB8xft7lv1naECJWd9uwKArD0ilpCVnXh2amUgij2J7Pkyh7jx498HmX7Qzw==", "+359888888103", false, "Doctor", "cdee5090-b856-449a-9fec-f5df3d88bee6", false, "m_velikova" },
                    { "f092f500-00e2-4544-952a-4cb91320558d", 0, null, "92eab3ce-c64d-4a29-a900-024ef1e06a21", "734a6dcd-060c-4108-a184-84997a5da2d1", "h_hristov@mc-bg.com", false, "Христо", 1, false, "08.12.2022", null, null, "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", "AQAAAAEAACcQAAAAEAlOUk3RzVByUwnyLZSQyq91yV8b9uS2ndMEh0i6T06jUWtU/f+GvJ5g74kE/lNCVQ==", "+359888888113", false, "Doctor", "7a065c74-d5bf-4d62-a471-4e9d7bad6037", false, "h_hristov" },
                    { "f1221132-3b9f-4f33-9e4d-1514bc0221e8", 0, null, "8dd1496e-0f54-4906-8f2e-e0b32c76ae3a", "4775e4ac-4930-4113-bb19-6ed94e12fa24", "b_petkova@mc-bg.com", false, "Бисерка", 2, false, "08.12.2022", null, null, "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", "AQAAAAEAACcQAAAAEBZ2kyst8TmVXXt0376g9Wca9QeO38beWslUa8mrLQNnY6c4T9jXR0xLKZEKe2A6pw==", "+359888888102", false, "Doctor", "42aade35-71bd-4d88-b132-cfdde210ecd3", false, "b_petkova" },
                    { "f142f846-dbe7-420e-bbce-4a9f83e36980", 0, null, "1addc82a-1f65-4691-9580-a3345cd9b42d", "221de519-48d4-41cd-befd-1b414b2fea57", "r_ruseva@mc-bg.com", false, "Ралица", 2, false, "08.12.2022", null, null, "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", "AQAAAAEAACcQAAAAEGtGL4nBFAb0J8poQ7Mz5P2PuJQWr3yItEjYDLkJCVnJNfd8FDR92p6zuEBU4sQ4xg==", "+359888888108", false, "Doctor", "e097ebda-345f-4625-92a2-1309c6929a6c", false, "r_ruseva" },
                    { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", 0, null, "96ad09dc-e5d7-47aa-82f4-43c7b1f58d63", null, "lab_vivanova@mc-bg.com", false, "Ваня", 2, false, "08.12.2022", "fb454478-8b7c-48bd-86b4-a0b36bf261a2", null, "Иванова", false, null, "LAB_VIVANOVA@MC-BG.COM", "LAB_VIVANOVA", "AQAAAAEAACcQAAAAEG7eex9zYWbWchWcTpTi4rUSYM0Ji/D6jMoPgPWYeCn9Myg7Eng9tC4Cpkwa8RGnKw==", "+359888888881", false, "Laborant", "f413496b-e7da-4db6-8554-b53cb3ecfb95", false, "lab_vivanova" }
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
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "b922fbb1-e1e8-41c6-a903-931e1cd4b845" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "21054893-923f-4121-980e-d45fd8cb2d2c", "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "7f35ce32-b6d5-4263-a6f1-a4866727d065", "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "44078427-01ab-4211-b865-b97d481bd493", "fb454478-8b7c-48bd-86b4-a0b36bf261a2" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707192482", null, "https://i.imgur.com/E5Yga61.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 44, "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "182466cf-4d18-4ba4-940c-71e8f445335c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7702262899", null, "https://i.imgur.com/oFAixEu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 44, "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "22081bf0-1049-45ba-a9b3-3171271f1341", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", null, "https://i.imgur.com/73peyhD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 1, "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "221de519-48d4-41cd-befd-1b414b2fea57", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9401161818", null, "https://i.imgur.com/LKNbRcV.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 31, "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "473d0775-d1d3-4439-940b-fe949652859f", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9107227892", null, "https://i.imgur.com/yQmifbA.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 24, "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "4775e4ac-4930-4113-bb19-6ed94e12fa24", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7412135099", null, "https://i.imgur.com/66UFmBy.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 8, "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "499be402-5520-453d-a17d-3a52ac6ad798", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707015574", null, "https://i.imgur.com/7VzO2Pm.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 8, "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "4b95c2a0-314d-414d-a80a-db46ef2f810a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7903129851", null, "https://i.imgur.com/9gZeKsk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 1, "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "4be5615e-0d14-4756-a090-bd157133f463", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", null, "https://i.imgur.com/dj7NvUl.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 77, "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "5b0923f7-da08-4af1-a391-d0561a534a42", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8606163716", null, "https://i.imgur.com/GhnW3gD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 75, "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7411033533", null, "https://i.imgur.com/WkPS5Ds.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 60, "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "734a6dcd-060c-4108-a184-84997a5da2d1", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", null, "https://i.imgur.com/42rKRT2.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 55, "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "97fde454-7892-40ab-acff-c641b14d1eab", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7504196361", null, "https://i.imgur.com/62LMUUe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 24, "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "992d83f0-1439-40dc-95f4-5a708fd3c086", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7801138974", null, "https://i.imgur.com/6NU5RvT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 76, "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7609186138", null, "https://i.imgur.com/2HO3b8v.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 60, "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9002041303", null, "https://i.imgur.com/fkXWOZT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 75, "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "be158f8c-bc22-4469-b01c-b9e928499a05", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", null, "https://i.imgur.com/hx5EEMp.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 77, "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7904245096", null, "https://i.imgur.com/2xoQC2H.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 11, "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9103145306", null, "https://i.imgur.com/f5yYnPN.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 76, "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", null, "https://i.imgur.com/YO1cWgu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 55, "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "f40725ef-50bd-4b7b-b2ab-df41d875781e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8112144846", null, "https://i.imgur.com/YK3Y8Ya.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 2, 31, "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
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
