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
                    IsOutOfCompany = table.Column<bool>(type: "bit", nullable: false),
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
                    IsOutOfCompany = table.Column<bool>(type: "bit", nullable: false),
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
                    { "59a70b62-7c60-42a0-bc31-02493759b658", "bb8e7f77-6a52-457f-8628-590f46a23301", "User", "USER" },
                    { "6bc0d445-384d-49fd-82b8-23f64bc1471b", "aee0d45c-1b7d-45ba-a576-545dbe365f9b", "LaboratoryUser", "LABORATORYUSER" },
                    { "a0f9eff4-7d70-4e90-9259-97204969e5be", "1361f620-76d9-434c-a5b1-95342aacfbf8", "Administrator", "ADMINISTRATOR" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "c68ba5c3-6523-440c-8465-e1b44409777d", "Doctor", "DOCTOR" },
                    { "c269f6d4-e700-4c01-a702-f0325997837a", "3bc06555-02e3-4ae2-b075-6cbe1219877a", "Laborant", "LABORANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdministratorId", "ConcurrencyStamp", "DoctorId", "Email", "EmailConfirmed", "FirstName", "GenderId", "JoinOnDate", "LaborantId", "LaboratoryPatientId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "041639c2-fcd2-4899-a5c6-2025cbb3c1c7", 0, null, "83e1d953-a52b-46c0-8e0a-ac78af0da70b", "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "k_moskova@mc-bg.com", false, "Катерина", 2, "30.11.2022", null, null, "Москова", false, null, "K_MOSKOVA@MC-BG.COM", "K_MOSKOVA", "AQAAAAEAACcQAAAAEA62HDJJ8TGHe7HKqrxh+P858XK4wShu+OmsUvAdouMaFh+qahFkSs8zpYulnTTaMA==", "+359888888115", false, "Doctor", "97883bbe-7689-4b4a-8014-e118c6b38ca3", false, "k_moskova" },
                    { "095da4be-9891-4cd9-a2ad-05dbbb0e2085", 0, null, "9351148d-1f08-4168-b748-38a9529b1ebe", "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "r_ikonomov@mc-bg.com", false, "Росен", 1, "30.11.2022", null, null, "Икономов", false, null, "R_IKONOMOV@MC-BG.COM", "R_IKONOMOV", "AQAAAAEAACcQAAAAEACflAJ9b4XkxXrYAysifSG1IIJDgZkSKTqunKFp0OJxpzyV3u9XN8MFNMrQjN4tFQ==", "+359888888111", false, "Doctor", "e29ff5d6-f867-4a69-b627-0634f0c99b01", false, "r_ikonomov" },
                    { "0bbf2307-d024-44b4-917f-a52ab9ddc013", 0, null, "89ea602a-a13a-4d23-8bcb-e3e820e4bb32", "473d0775-d1d3-4439-940b-fe949652859f", "m_kalinkova@mc-bg.com", false, "Мария", 2, "30.11.2022", null, null, "Калинкова", false, null, "M_KALINKOVA@MC-BG.COM", "M_KALINKOVA", "AQAAAAEAACcQAAAAECSOf85Ul/r1mOKSP9wtOaFZ19HtJaTfV7mxYTdLxJ6IBQlEF5TNpgD0R1sdv0n96g==", "+359888888106", false, "Doctor", "0a00e064-f52b-4fe7-932f-dfea4f558b1b", false, "m_kalinkova" },
                    { "3f9592ad-6af3-4021-808f-39d7aa9246e9", 0, null, "942d7933-91b2-4438-b6b3-0e6f25b668ea", "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "m_blagoeva@mc-bg.com", false, "Мая", 2, "30.11.2022", null, null, "Благоева", false, null, "M_BLAGOEVA@MC-BG.COM", "M_BLAGOEVA", "AQAAAAEAACcQAAAAEL8XN7fXJHux4dch2Bvi9hvggNi1D2Rrx0mwL++a5VlQsMZDOgsu7lVvPn31Cm7yNg==", "+359888888105", false, "Doctor", "53db3a00-87e4-45da-8734-32c8f68ecce2", false, "m_blagoeva" },
                    { "734267e9-a59b-44c3-baee-7e52a2bd1c29", 0, null, "be10f854-449d-4fec-858e-ace3b0e06040", "4be5615e-0d14-4756-a090-bd157133f463", "i_belcheva@mc-bg.com", false, "Ирина", 2, "30.11.2022", null, null, "Белчева", false, null, "I_BELCHEVA@MC-BG.COM", "I_BELCHEVA", "AQAAAAEAACcQAAAAEG5pWZNJNw7Cc0svzulrebxSD4bzK11ycb5BNjJJ6kXAj+wzR9DL43LpgayeuYTkPQ==", "+359888888121", false, "Doctor", "2308181a-e08d-4b10-840e-ec689ba15b43", false, "i_belcheva" },
                    { "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e", 0, null, "7220786b-3474-4fb3-b442-da94214a54f4", "22081bf0-1049-45ba-a9b3-3171271f1341", "s_slavchev@mc-bg.com", false, "Станислав", 1, "30.11.2022", null, null, "Славчев", false, null, "S_SLAVCHEV@MC-BG.COM", "S_SLAVCHEV", "AQAAAAEAACcQAAAAEPgxM5SHOKNNFkzW21Nt7Za2IckcMb1a8xwjMryJZUbPXEdap/CZbWvos0W/aeVXNA==", "+359888888101", false, "Doctor", "ad6d1bd8-27f7-4951-9869-29a28fc14ec0", false, "s_slavchev" },
                    { "7c513995-bed0-4be3-b768-304cd697c3f9", 0, null, "5c96893b-8250-4b35-930f-62d167064eb1", "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "n_paskov@mc-bg.com", false, "Николай", 1, "30.11.2022", null, null, "Пасков", false, null, "N_PASKOV@MC-BG.COM", "N_PASKOV", "AQAAAAEAACcQAAAAEObgrP59HidgXd+4Ke2rXNFxQuQajFkjJp7e04MHM9ythdtSijReuDDLsAlCOKIXKQ==", "+359888888119", false, "Doctor", "4377e7b9-1977-4f5d-8462-8ea20fd5b9f8", false, "n_paskov" },
                    { "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca", 0, null, "3b8216e2-f3d0-451a-a0c0-86e2904cdd33", "182466cf-4d18-4ba4-940c-71e8f445335c", "s_atanasova@mc-bg.com", false, "Стела", 2, "30.11.2022", null, null, "Атанасова", false, null, "S_ATANASOVA@MC-BG.COM", "S_ATANASOVA", "AQAAAAEAACcQAAAAECivOleCjTNJZgTXQWcbBxllITDDf6yt5zHksAtggSXu6ZfExp9rm4GxwhYe53kOIQ==", "+359888888110", false, "Doctor", "0bdac5a5-2a61-4bc3-9e90-7ddfe81c73c1", false, "s_atanasova" },
                    { "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe", 0, null, "48861592-9f93-4f7b-81f2-f5be3ac231a1", "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "g_kuchukov@mc-bg.com", false, "Георги", 1, "30.11.2022", null, null, "Кичуков", false, null, "G_KUCHUKOV@MC-BG.COM", "G_KUCHUKOV", "AQAAAAEAACcQAAAAECSZGKRvZqolyPz80+Z9D731658B9nfKLcSybNAgocWb3kiHkVpK1yCPdRsBGzARXg==", "+359888888117", false, "Doctor", "7e641a7d-c1f7-4ed2-9d5c-1d87badcfd8a", false, "g_kuchukov" },
                    { "9da9587f-e28e-4289-a559-7407d3ea34a5", 0, null, "245fc03d-abf6-4e01-b6f6-b3355fde2df8", "4b95c2a0-314d-414d-a80a-db46ef2f810a", "m_monastirska@mc-bg.com", false, "Маргарита", 2, "30.11.2022", null, null, "Монастирска", false, null, "M_MONASTIRSKA@MC-BG.COM", "M_MONASTIRSKA", "AQAAAAEAACcQAAAAEPJSZF6gKgVEJcnuY72RdeG9H4q6kIyYWVUNkQwDZLIwu7qyJ9qFT5ZVFF8WucyQAA==", "+359888888100", false, "Doctor", "0bd720be-6529-4ea3-9dab-d843b4fa83e0", false, "m_monastirska" },
                    { "a8d60b9c-6bef-4eff-af47-bcce7daf311b", 0, null, "05e9ba86-affa-4c4d-8f39-123ae9e3fdb4", "992d83f0-1439-40dc-95f4-5a708fd3c086", "k_stoicheva@mc-bg.com", false, "Катина", 2, "30.11.2022", null, null, "Стойчева", false, null, "K_STOICHEVA@MC-BG.COM", "K_STOICHEVA", "AQAAAAEAACcQAAAAEDBn1Gy0HFQB0JE+H/+uR+ig25JSG/6lfmm17GYpxJWyTBk0kS4kSsj4HxM/ApTp9Q==", "+359888888118", false, "Doctor", "6248414a-ae7e-4dd0-b344-ff023c5c6c35", false, "k_stoicheva" },
                    { "b67a1365-3902-4728-8c9f-05369b1556b7", 0, null, "7a6770e8-e0f0-4d75-9ee8-df57ca934af7", "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "m_vuldjev@mc-bg.com", false, "Михаил", 1, "30.11.2022", null, null, "Вулджев", false, null, "M_VULDJEV@MC-BG.COM", "M_VULDJEV", "AQAAAAEAACcQAAAAEPjq22Pma+yWUELSEKRgNPDxWHtClizGNJAGqPDdsP4jsdkXjoW4k2LZA9cTJgrX9Q==", "+359888888112", false, "Doctor", "68648436-d6f1-4d93-957b-8a678daeca11", false, "m_vuldjev" },
                    { "b922fbb1-e1e8-41c6-a903-931e1cd4b845", 0, null, "42c7295c-86c7-46c1-bc2b-8759356b067a", "f5628f68-e883-4b6a-8c6c-2511314af5a1", "t_stoev@mc-bg.com", false, "Тодор", 1, "30.11.2022", null, null, "Стоев", false, null, "T_STOEV@MC-BG.COM", "T_STOEV", "AQAAAAEAACcQAAAAEBo9RElP2rczLAjKMp6bxEpAggJxbn3h671Ce4KOILwm7BpkCpWxItSZpVSkzDs27g==", "+359888888104", false, "Doctor", "5420e5c5-2dda-465b-92da-76e7274039ec", false, "t_stoev" },
                    { "c83d8295-ff6a-4644-a44a-c2bc294b220e", 0, null, "37d0376a-11f9-482c-aae3-37784a6c1120", "5b0923f7-da08-4af1-a391-d0561a534a42", "k_atanasova@mc-bg.com", false, "Кристина", 2, "30.11.2022", null, null, "Атанасова", false, null, "K_ATANASOVA@MC-BG.COM", "K_ATANASOVA", "AQAAAAEAACcQAAAAEN/M02ZvIgwEXSlg9Qud1RqMY0G1465cY1frgzVt8LhFzOrTfJ9IICupQVQAEGvbig==", "+359888888116", false, "Doctor", "50ec94c9-38a4-4bb9-898e-755bfdf59156", false, "k_atanasova" },
                    { "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb", 0, null, "cb6d797e-4f16-4fad-9295-9a9ea64e5a96", "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "a_tomova@mc-bg.com", false, "Антония", 2, "30.11.2022", null, null, "Томова", false, null, "A_TOMOVA@MC-BG.COM", "A_TOMOVA", "AQAAAAEAACcQAAAAEPjIhu7FhSDviPo7h3nEw5rFXT5rUINdgrj6NnVHIfDdKG46QSE8EPyds8RfwQVztw==", "+359888888114", false, "Doctor", "5b09e4fa-3299-4417-aab4-02d75cbe9882", false, "a_tomova" },
                    { "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788", 0, null, "58acaaac-baa4-4e5b-a302-9cd1bed5c598", "be158f8c-bc22-4469-b01c-b9e928499a05", "r_uzunova@mc-bg.com", false, "Росица", 2, "30.11.2022", null, null, "Узунова", false, null, "R_UZUNOVA@MC-BG.COM", "R_UZUNOVA", "AQAAAAEAACcQAAAAEG0mZe1qSsVee1OGynmDFwXJqr3T6wECKwRA3t1sXdUdZSaAkv42sX9L94YRzz8JeA==", "+359888888120", false, "Doctor", "def71936-bef4-4d7a-85fe-273f747c23e5", false, "r_uzunova" },
                    { "cf6e7092-584c-460d-9538-feee4a5b53d9", 0, null, "fdb1269a-ad36-45b9-8600-785ba932bfd3", "97fde454-7892-40ab-acff-c641b14d1eab", "d_georgiev@mc-bg.com", false, "Димитър", 1, "30.11.2022", null, null, "Георгиев", false, null, "D_GEORGIEV@MC-BG.COM", "D_GEORGIEV", "AQAAAAEAACcQAAAAEOCKHG1DdVQFuFPPshxFFJWth8SnQNnCL3k7iTTj/9O9z4ZB+vp9fwtI/k67CKRT5A==", "+359888888107", false, "Doctor", "d485941e-8f47-4fd2-a8eb-3d3fc84be7d0", false, "d_georgiev" },
                    { "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b", 0, "e0b65a18-1271-4146-a730-8e80a24cea78", "b2157702-e33d-48d5-a1f8-1907b5b7b396", null, "admin@mc-bg.com", false, "Ивайло", 1, null, null, null, "Илиев", false, null, "ADMIN@MC-BG.COM", "ADMIN", "AQAAAAEAACcQAAAAEErSdpSlXt2slGA3aC1ytemC0WZLIkctZqS2qkd12SpuUcCP38fJH08pMV3QOcgVBA==", "+359888888888", false, "Administrator", "49c876c6-1f7d-446f-94bc-e742852fa6c8", false, "admin" },
                    { "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760", 0, null, "2418c6f0-35fd-4192-aa5c-0397f95a2869", "f40725ef-50bd-4b7b-b2ab-df41d875781e", "s_tochev@mc-bg.com", false, "Сотир", 1, "30.11.2022", null, null, "Точев", false, null, "S_TOCHEV@MC-BG.COM", "S_TOCHEV", "AQAAAAEAACcQAAAAEJK8MgNKnPb6yqimxMB56wALFwnFszQ11JsvNIQXaBsAsTOglDLosSRz4Y7C9V0DLA==", "+359888888109", false, "Doctor", "6ce3e725-d124-4e33-bd7d-89f0dfe1d35f", false, "s_tochev" },
                    { "da3da29d-5411-4750-a5c4-e4ae4e22965c", 0, null, "24a7f22d-5026-4a29-ba9d-fe3c778e138d", "499be402-5520-453d-a17d-3a52ac6ad798", "m_velikova@mc-bg.com", false, "Мими", 2, "30.11.2022", null, null, "Великова", false, null, "M_VELIKOVA@MC-BG.COM", "M_VELIKOVA", "AQAAAAEAACcQAAAAELYVpcN82vBxb9FVZUZja2rZwP5GK97zNoJExxc+sliaKScE6UHWZSGBog10n+kekA==", "+359888888103", false, "Doctor", "38c65d44-32f1-48c5-86f9-917ce216d5b6", false, "m_velikova" },
                    { "f092f500-00e2-4544-952a-4cb91320558d", 0, null, "a5b196a9-7549-4fb3-8d37-0ca854366912", "734a6dcd-060c-4108-a184-84997a5da2d1", "h_hristov@mc-bg.com", false, "Христо", 1, "30.11.2022", null, null, "Христов", false, null, "H_HRISTOV@MC-BG.COM", "H_HRISTOV", "AQAAAAEAACcQAAAAEEtmvb+3f7lKSGzS6ZO8mIFkGkcTZfaDnUp8BUPUmJS3WYCFk4K4djEN6o6kL64J7g==", "+359888888113", false, "Doctor", "05a06635-9ec0-40d6-8f3d-0bb5f91f130c", false, "h_hristov" },
                    { "f1221132-3b9f-4f33-9e4d-1514bc0221e8", 0, null, "80f1db05-7c92-44a9-ac02-89f42d0c12f8", "4775e4ac-4930-4113-bb19-6ed94e12fa24", "b_petkova@mc-bg.com", false, "Бисерка", 2, "30.11.2022", null, null, "Петкова", false, null, "B_PETKOVA@MC-BG.COM", "B_PETKOVA", "AQAAAAEAACcQAAAAEO9UiAaVUNub5qeq0yZ01Ay6DDlHCkJ0L/aQgVy7I1ZFeeK5fK6UG6IQOULI3mF9yA==", "+359888888102", false, "Doctor", "e8e35a86-d628-449d-a190-27dc174927c1", false, "b_petkova" },
                    { "f142f846-dbe7-420e-bbce-4a9f83e36980", 0, null, "0d2a9819-f84d-4f58-83b6-2a600c333e3f", "221de519-48d4-41cd-befd-1b414b2fea57", "r_ruseva@mc-bg.com", false, "Ралица", 2, "30.11.2022", null, null, "Русева", false, null, "R_RUSEVA@MC-BG.COM", "R_RUSEVA", "AQAAAAEAACcQAAAAEPmzuXEHC3Z7UvnJtgu687GJtmzknFP33RYZHwNi5NRiJgN83E2lPfWtBCqTzXEWrg==", "+359888888108", false, "Doctor", "050e1aed-649d-4569-bdf4-fdc328a7b317", false, "r_ruseva" },
                    { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", 0, null, "5084664b-0abd-4679-8abc-cfa41f34ebb7", null, "lab_vivanova@mc-bg.com", false, "Ваня", 2, "30.11.2022", "fb454478-8b7c-48bd-86b4-a0b36bf261a2", null, "Иванова", false, null, "LAB_VIVANOVA@MC-BG.COM", "LAB_VIVANOVA", "AQAAAAEAACcQAAAAEKoOZ2a5PoN4jY7VVlujVPg5GXm99/nkujBERCPVQEQVsMQ3xmv2KI4LXfJPZWYdYQ==", "+359888888881", false, "Laborant", "34663979-c7e2-4505-94a0-a0b97ae1effc", false, "lab_vivanova" }
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
                columns: new[] { "Id", "UserId" },
                values: new object[] { "e0b65a18-1271-4146-a730-8e80a24cea78", "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "b922fbb1-e1e8-41c6-a903-931e1cd4b845" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "a0f9eff4-7d70-4e90-9259-97204969e5be", "d026cf1f-a334-41f4-a1b7-31b7a56b9f1b" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "adafe450-9ff7-4dd9-8236-ac41a28a640b", "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "c269f6d4-e700-4c01-a702-f0325997837a", "fb454478-8b7c-48bd-86b4-a0b36bf261a2" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "IsOutOfCompany", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "17dcc03b-321f-4484-a96a-61f3b8fe6dc8", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707192482", false, null, "https://i.imgur.com/E5Yga61.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 44, "095da4be-9891-4cd9-a2ad-05dbbb0e2085" },
                    { "182466cf-4d18-4ba4-940c-71e8f445335c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7702262899", false, null, "https://i.imgur.com/oFAixEu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 44, "8c1bcbb9-96f4-4e4e-8ec2-fc26fb79ddca" },
                    { "22081bf0-1049-45ba-a9b3-3171271f1341", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512150522", false, null, "https://i.imgur.com/73peyhD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 1, "79fb8276-3bf8-4e70-9ac3-0e53a0d3a29e" },
                    { "221de519-48d4-41cd-befd-1b414b2fea57", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9401161818", false, null, "https://i.imgur.com/LKNbRcV.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 31, "f142f846-dbe7-420e-bbce-4a9f83e36980" },
                    { "473d0775-d1d3-4439-940b-fe949652859f", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9107227892", false, null, "https://i.imgur.com/yQmifbA.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 24, "0bbf2307-d024-44b4-917f-a52ab9ddc013" },
                    { "4775e4ac-4930-4113-bb19-6ed94e12fa24", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7412135099", false, null, "https://i.imgur.com/66UFmBy.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 8, "f1221132-3b9f-4f33-9e4d-1514bc0221e8" },
                    { "499be402-5520-453d-a17d-3a52ac6ad798", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8707015574", false, null, "https://i.imgur.com/7VzO2Pm.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 8, "da3da29d-5411-4750-a5c4-e4ae4e22965c" },
                    { "4b95c2a0-314d-414d-a80a-db46ef2f810a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7903129851", false, null, "https://i.imgur.com/9gZeKsk.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 1, "9da9587f-e28e-4289-a559-7407d3ea34a5" },
                    { "4be5615e-0d14-4756-a090-bd157133f463", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158992", false, null, "https://i.imgur.com/dj7NvUl.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 77, "734267e9-a59b-44c3-baee-7e52a2bd1c29" },
                    { "5b0923f7-da08-4af1-a391-d0561a534a42", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8606163716", false, null, "https://i.imgur.com/GhnW3gD.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 75, "c83d8295-ff6a-4644-a44a-c2bc294b220e" },
                    { "61f0536e-26ec-46cc-9386-1c7cb348f1e7", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7411033533", false, null, "https://i.imgur.com/WkPS5Ds.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 60, "c8517d67-c0f3-4cb8-ac8c-96602aaad8bb" },
                    { "734a6dcd-060c-4108-a184-84997a5da2d1", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512155144", false, null, "https://i.imgur.com/42rKRT2.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 55, "f092f500-00e2-4544-952a-4cb91320558d" },
                    { "97fde454-7892-40ab-acff-c641b14d1eab", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7504196361", false, null, "https://i.imgur.com/62LMUUe.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 24, "cf6e7092-584c-460d-9538-feee4a5b53d9" },
                    { "992d83f0-1439-40dc-95f4-5a708fd3c086", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7801138974", false, null, "https://i.imgur.com/6NU5RvT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 76, "a8d60b9c-6bef-4eff-af47-bcce7daf311b" },
                    { "9c85bdfe-768b-43bc-bc3d-91d3565edd7a", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7609186138", false, null, "https://i.imgur.com/2HO3b8v.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 60, "041639c2-fcd2-4899-a5c6-2025cbb3c1c7" },
                    { "9e38d1b5-6ba5-4e49-bbf0-7d893dd5b040", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9002041303", false, null, "https://i.imgur.com/fkXWOZT.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 75, "8f052e1c-d7f5-40d4-9ee4-9c9f29a85ffe" },
                    { "be158f8c-bc22-4469-b01c-b9e928499a05", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512158631", false, null, "https://i.imgur.com/hx5EEMp.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 77, "cd25b1ea-70c5-47d2-9617-3b7d0e6bc788" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "Education", "Egn", "IsOutOfCompany", "OutOnDate", "ProfileImageUrl", "Representation", "SheduleId", "SpecialtyId", "UserId" },
                values: new object[,]
                {
                    { "c96d7a14-8865-43bc-b756-8a6ad16b3cf4", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7904245096", false, null, "https://i.imgur.com/2xoQC2H.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 11, "3f9592ad-6af3-4021-808f-39d7aa9246e9" },
                    { "cb55ad4a-e7c3-4cd6-8efb-6ccd3c369f4e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "9103145306", false, null, "https://i.imgur.com/f5yYnPN.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 76, "7c513995-bed0-4be3-b768-304cd697c3f9" },
                    { "d5adc893-6e93-4b1f-9ce5-7105069e7a6c", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "7512152504", false, null, "https://i.imgur.com/YO1cWgu.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 55, "b67a1365-3902-4728-8c9f-05369b1556b7" },
                    { "f40725ef-50bd-4b7b-b2ab-df41d875781e", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "8112144846", false, null, "https://i.imgur.com/YK3Y8Ya.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 31, "d3ba8e2c-1f0f-4879-86b0-372d1b0bc760" },
                    { "f5628f68-e883-4b6a-8c6c-2511314af5a1", "Това е поредица от латински думи които, както са позиционирани, не образувайте изречения с пълен смисъл, а дайте живот на тестов текст, полезен за запълване на пространства, които впоследствие ще бъдат заети от ad hoc текстове, съставени от комуникационни специалисти. Със сигурност е най -известният заместващ текст дори ако има различни версии, които се различават от реда, в който се повтарят латинските думи. Lorem ipsum съдържа шрифтове , които се използват повече, аспект което ви позволява да имате преглед на изобразяването на текста по отношение на избор на шрифт an d размер на шрифта.", "Когато се отнася до Lorem ipsum, се използват различни изрази, а именно текст за попълване, измислен текст, сляп текст или заместващ текст: накратко, значението му също може да бъде нула, но полезността му е толкова ясна, че да мине през вековете и да устои на ироничните и модерни версии, дошли с появата на мрежата.", "6902251307", false, null, "https://i.imgur.com/oSv4hEn.jpg", "Lorem ipsum dolor sit amet. Графичните и типографските оператори знаят това добре, в действителност всички професии, занимаващи се с комуникационната вселена, имат стабилна връзка с тези думи, но какво е това? Lorem ipsum е фиктивен текст без никакъв смисъл.", 1, 11, "b922fbb1-e1e8-41c6-a903-931e1cd4b845" }
                });

            migrationBuilder.InsertData(
                table: "Laborants",
                columns: new[] { "Id", "Egn", "IsOutOfCompany", "OutOnDate", "UserId" },
                values: new object[] { "fb454478-8b7c-48bd-86b4-a0b36bf261a2", "8412194792", false, null, "fb454478-8b7c-48bd-86b4-a0b36bf261a2" });

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
