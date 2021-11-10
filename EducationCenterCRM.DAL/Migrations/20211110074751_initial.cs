using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationCenterCRM.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "StudingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudingType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudingRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Title);
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Invalidated = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicTitle = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationWeeks = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CourseLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicTitle",
                        column: x => x.TopicTitle,
                        principalTable: "Topics",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationCenterUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkToProfile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_AspNetUsers_EducationCenterUserId",
                        column: x => x.EducationCenterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Person_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StudentCapacity = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudingType = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Person_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "2d59a720-2abb-4875-bedb-1d7f4fe4c1bb", "EducationCenterRole", "Student", "STUDENT" },
                    { "41efbc7e-1687-4607-b380-2c46bb29d7a9", "79df6f06-0497-456f-bf07-19017ca7f00f", "EducationCenterRole", "Admin", "ADMIN" },
                    { "eda16b48-8a72-41a6-bca3-c90f4a2210cf", "78b74c91-f84a-4cb6-ba40-c8f3033e086a", "EducationCenterRole", "Manager", "MANAGER" },
                    { "1cb03013-2a17-487d-9089-441c9d51172c", "71bf6e42-47eb-40c7-bb24-60c3f36f631a", "EducationCenterRole", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonLastName", "PersonName", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "53b5ffde-9630-4258-87c3-9844dcb250c0", 0, new DateTime(1993, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "a2b521e8-2ef7-4b83-9097-99e3d288c5c3", "EducationCenterUser", "cobrebaseido-4239@yopmail.com", false, false, null, null, null, null, "Яловой", "Георгий", "+375291239635", false, "f03be9de-0fa4-4d3e-9d8f-05dd230f1ddc", false, "cobrebaseido-4239@yopmail.com" },
                    { "f01a0643-8509-4d65-acfd-2f04d99e811a", 0, new DateTime(1998, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f93cf030-f05a-4422-a13e-672aff5f9e07", "EducationCenterUser", "jeibrucrouquixi-1073@yopmail.com", false, false, null, null, null, null, "Тимошенко", "Чеслав", "+375291235217", false, "eaea0449-dd38-4a22-bc5e-4bbbdb3f44b3", false, "jeibrucrouquixi-1073@yopmail.com" },
                    { "f2f49e38-92ce-4275-9e1b-595984befeec", 0, new DateTime(1989, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "9d77b4a3-0366-4308-8301-0b48ffbec958", "EducationCenterUser", "kaumeusateileu-9412@yopmail.com", false, false, null, null, null, null, "Мирный", "Даниил", "+375299514564", false, "a1201bb2-f08f-4270-879f-9462316625e3", false, "kaumeusateileu-9412@yopmail.com" },
                    { "1df28a2d-bd21-4c77-b10c-d8631c7a0837", 0, new DateTime(1994, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "57c4e40e-d825-4421-a511-401dff7e2be4", "EducationCenterUser", "croimappossoteu-1134@yopmail.com", false, false, null, null, null, null, "Дзюба", "Гордей", "+375291265463", false, "100c9cb1-97b7-405d-998e-e4b920d7863a", false, "croimappossoteu-1134@yopmail.com" },
                    { "a45a0f56-df7c-43b5-a4fb-2dc5eeaef6ca", 0, new DateTime(1989, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "df3eb42b-8bbf-4d45-9274-061c29b41d55", "EducationCenterUser", "qweewq@om.com", false, false, null, null, null, null, "Прокофьева", "Анастасия", "+375296207583", false, "25d540c9-f1c1-43e7-89fb-8a74e364c089", false, "qweewq@om.com" },
                    { "cf83c3bc-8e5d-477b-af52-29868ba738ec", 0, new DateTime(1986, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "71948830-9784-4dac-86b7-3273a351eea0", "EducationCenterUser", "asdfwq@om.com", false, false, null, null, null, null, "Галкин", "Даниил", "+375294632561", false, "7b2e5b22-4484-468b-b374-ec58e1a9019a", false, "asdfwq@om.com" },
                    { "93397388-d01a-46ef-a029-24e911e74553", 0, new DateTime(1990, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "f63c075a-b1dc-4bc8-be18-0747602d34b8", "EducationCenterUser", "guilo-339@yopmail.com", false, false, null, null, null, null, "Никольский", "Артем", "+375294632561", false, "d30ad9d5-addb-4262-bb03-1f98a7fc2e23", false, "guilo-339@yopmail.com" },
                    { "86837c36-10b3-4af5-b53f-43331df6f6ad", 0, new DateTime(1990, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "79b34125-ce83-41af-a285-14d87b72b663", "EducationCenterUser", "gougeigubreudo-4919@yopmail.com", false, false, null, null, null, null, "Дубченко", "Мирослав", "+375291234561", false, "1a64a46a-ff80-4ff4-9339-6bfe37cbade1", false, "gougeigubreudo-4919@yopmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Title", "Description" },
                values: new object[,]
                {
                    { "English", " Если вы хотите «войти в IT» и построить успешную карьеру в индустрии, то вам обязательно нужно знать английский язык. Не имеет значения, какое направление вы выберете и в какой компании в перспективе будете работать, так или иначе столкнетесь с необходимостью применять английский" },
                    { ".Net", ".Net (ASP.NET, Unity)" },
                    { "Java", "Full-stack, JS, Spring" },
                    { "Business analysis", "	 Бизнес-анализ как дисциплина тесно связан с анализом требований, но нацелен на определение изменений, которые необходимы для того, чтобы та или иная компания (организация) достигла своих стратегических целей. Эти изменения затрагивают стратегию, структуру, политику, процессы и информационные системы." },
                    { "QA", "Тестирование дистанционно – это контроль качества программного продукта. Оно может быть ручным или автоматизированным (с помощью Java/Python). Это не разовая активность, а процесс, который длится на протяжении всего жизненного цикла программного обеспечения. Курсы тестировщиков ПО – быстрый старт к востребованной и высокооплачиваемой IT-профессии" },
                    { "Design", " Программа по UI/UX и веб-дизайну включает в себя знакомство с инструментарием, обучение созданию визуальной составляющей IT-продуктов, проектированию сайтов, приложений и других сервисов. Вы научитесь воплощать свои идеи, разрабатывать привлекательный и функциональный дизайн, сможете оформить или пополнить портфолио качественными проектами." }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1cb03013-2a17-487d-9089-441c9d51172c", "93397388-d01a-46ef-a029-24e911e74553" },
                    { "1cb03013-2a17-487d-9089-441c9d51172c", "cf83c3bc-8e5d-477b-af52-29868ba738ec" },
                    { "1cb03013-2a17-487d-9089-441c9d51172c", "a45a0f56-df7c-43b5-a4fb-2dc5eeaef6ca" },
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "86837c36-10b3-4af5-b53f-43331df6f6ad" },
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "1df28a2d-bd21-4c77-b10c-d8631c7a0837" },
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "f2f49e38-92ce-4275-9e1b-595984befeec" },
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "f01a0643-8509-4d65-acfd-2f04d99e811a" },
                    { "6ee8c136-0977-4454-b5bc-bc0d93192091", "53b5ffde-9630-4258-87c3-9844dcb250c0" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseLevel", "Description", "DurationWeeks", "ImageUrl", "Price", "Program", "Title", "TopicTitle" },
                values: new object[,]
                {
                    { 1, 0, "C# (си шарп) – объектно-ориентированный язык программирования, разработанный компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он продолжит развиваться и находить применение в различных отраслях.C Sharp впитал лучшие качества, а также унаследовал особенности синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.Благодаря огромному количеству документации C# достаточно прост в изучении. А собственная среда разработки Visual Studio, готовые шаблоны, модули, процедуры делают язык комфортным в применении. После прохождения базового курса «Программирование на C#» можно выбрать направление для дальнейшего развития – заниматься промышленной разработкой ПО на ASP.NET или созданием мобильных игр на Unity.", 18, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnpoO8C2w4eMbJ1NaPLaJgrwC7smBhuwSSRA&usqp=CAU", 400.0, "1. Getting Started", "Introduction to C#", ".Net" },
                    { 10, 2, "Данный курс сочетает в себе элементы теоретического знания с практическими деловыми навыками, что позволяет закрепить базовые знания, развить устную речь и расширить словарный запас", 50, "https://is5-ssl.mzstatic.com/image/thumb/Purple127/v4/da/ef/da/daefda5e-2add-30ed-5689-9fd7f516b23b/source/512x512bb.jpg", 2000.0, "1. What is Unity", "Бизнес Английский ", "English" },
                    { 9, 0, "Данный курс обеспечит получение базовых знаний, необходимых в повседневной жизни и профессиональной сфере.", 50, "https://speakwell.co.in/wp-content/uploads/2017/08/3.jpg", 1000.0, "", "Английский для начинающих ", "English" },
                    { 8, 1, "Python подходит для автоматизации лучше, чем другие языки программирования благодаря своим характеристикам: он интерпретируемый, простой в изучении и более лаконичный. Язык кроссплатформенный, поэтому, за редким исключением, все приложения, написанные на нём, будут работать под любой системой. Среди плюсов также обширный набор библиотек и активная поддержка сообществом, так что, скорее всего, нужный модуль для ваших нужд уже написан.", 34, "https://techrocks.ru/wp-content/uploads/2017/09/python-learn-logo.jpg", 700.0, "", "Автоматизированное тестирование на Python", "QA" },
                    { 7, 1, "Тестировщик-автоматизатор или QA Automation engineer – это специалист, который отвечает за качество произведенного продукта. Главная его задача – писать автоскрипты, которые будут проверять работу ПО. Это позволяет упростить процесс тестирования и сократить время на выполнение задания.", 40, "https://grodno.in/source/photos/app/b_c291cmNlL3Bob3Rvcy8yMDIwLzAyLzEwL21ha2V0LW5vdnl5LmpwZw==_640_c1c1188269.jpg", 500.0, "1. What is Unity", "Автоматизированное тестирование на Java", "QA" },
                    { 6, 1, " Одним из важнейших направлений разработки информационных систем является метод визуальной интерпретации создаваемых решений, то есть моделирование. Грамотно выстроенная модель подобна хорошо проработанной топографической карте, которая с высокой степенью надежности гарантирует, что Вы не заблудитесь в хитросплетениях реальности, не всегда интерпретируемых однозначно.", 10, "https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://coursera-course-photos.s3.amazonaws.com/db/00f7d7d51348529ad0323db833cd55/Cuadrado.png?auto=format%2Ccompress&dpr=1", 350.0, "", "Продвинутый курс по использованию нотации UML для практического анализа и визуального моделирования", "Business analysis" },
                    { 5, 1, "Данный специалист помогает максимально учесть цели и возможности организации в ходе работы над программными продуктами, даёт рекомендации по внедрению новых технологий с минимальными рисками. Именно бизнес-аналитик определяет потребности и предлагает эффективные решения, приносящие выгоды заинтересованным сторонам.", 24, "https://analytics.infozone.pro/wp-content/uploads/2019/09/business_analysis_techniques-720x380.jpg", 1000.0, "", "Бизнес-анализ в области разработки ПО", "Business analysis" },
                    { 12, 1, " UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Для того, чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).", 27, "https://thumbs.dreamstime.com/b/web-design-studio-web-site-responsive-design-presentation-computer-display-laptop-smart-phone-tablet-web-design-studio-web-175052877.jpg", 700.0, "1. What is Unity", "Веб-дизайн и дизайн мобильных интерфейсов", "Design" },
                    { 4, 1, "На современном движке Unity разработано более 50 процентов всех мобильных игр. Среди них – Albion Online, Pokemon GO, HearthStone, Inside и множество других крутых проектов. C помощью Unity можно разрабатывать приложения под любую платформу, само направление отличается относительно низким порогом вхождения, а еще имеет сильное комьюнити. Все это позволяет начинающему разработчику достаточно быстро освоиться в движке. Заинтересовались? Тогда записывайтесь на курсы по разработке игр на Unity в Минске.", 30, "https://unity.com/sites/default/files/styles/social_media_sharing_twitter/public/2019-11/unity-logo-600x400%402x.jpg?h=10d202d3&itok=LgYBHKk9", 600.0, "1. What is Unity", "Unity", ".Net" },
                    { 3, 1, "Платформа ASP.NET от компании Microsoft применяется для создания как простых web-сайтов, так и масштабных проектов – высоконадежных сетевых порталов, которые рассчитаны на многотысячную аудиторию. Благодаря безопасности и гибкости активно используется крупными компаниями: популярные сайты Microsoft, Lego, Volvo, Toyota, L'Oreal разработаны именно на ASP.NET.Сегодня ASP.NET – в авангарде web-разработки, а специалисты, работающие с этой технологией, находятся в числе самых востребованных в Беларуси. Как показывает статистика, выпускники IT-Academy, которые успешно оканчивают курсы по ASP.NET в Минске, быстрее находят работу.", 40, "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/113201276/original/3adcfe36722f42c0a44f46a81f06064c9988fe3a/do-asp-dot-net-core-mvc-applications.png", 700.0, "1. Controllers and MVC", "ASP.NET", ".Net" },
                    { 11, 0, "Ещё несколько лет назад Photoshop был абсолютным лидером по популярности среди digital-дизайнеров. Но постепенно начали появляться и другие, более специализированные, графические редакторы – такие как Figma и Sketch. Эти инструменты созданы специально для разработки веб-проектов и мобильных приложений и намного лучше подходят для UI/UX дизайна.", 10, "https://media.istockphoto.com/vectors/unified-modeling-language-acronym-business-concept-vector-id1272853458?k=20&m=1272853458&s=612x612&w=0&h=-7X5_-FpAZfAHPUQgmcBUjVz6ueByOnTfTcXySWSA7Q=", 200.0, "", "Обучение инструментам UI/UX дизайна", "Design" },
                    { 2, 0, "Язык программирования Java находится в числе лидеров во многих рейтингах: TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google, IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность обусловлена практически безграничными его возможностями и областями применения. Java не зависит от определённой платформы, его называют безопасным, портативным, высокопроизводительным и динамичным языком.Специалист, который знает этот язык, точно не останется без работы – уже более 7 миллиардов устройств по всему миру работают на Java. При этом те, кто освоит основы программирования на Java на курсах в Минске, могут развиваться в совершенно разных направлениях: заниматься enterprise-разработкой, промышленным программированием, разработкой мобильных приложений под Android, автоматизированным тестированием или программной роботизацией бизнес-процессов (RPA).", 18, "https://www.osp.ru/FileStorage/DOCUMENTS_ILLUSTRATIONS/13230112/original.jpg", 400.0, "1. Getting Started", "Introduction to Java", "Java" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Bio", "Discriminator", "EducationCenterUserId", "LinkToProfile" },
                values: new object[,]
                {
                    { 3, " teacher bio", "Teacher", "a45a0f56-df7c-43b5-a4fb-2dc5eeaef6ca", " teacher link" },
                    { 2, " teacher bio", "Teacher", "cf83c3bc-8e5d-477b-af52-29868ba738ec", " teacher link" },
                    { 1, " teacher bio", "Teacher", "93397388-d01a-46ef-a029-24e911e74553", " teacher link" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "StartDate", "Status", "StudentCapacity", "StudingType", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 2, null, "first_group" },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 1, null, "third_group" },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 2, null, "fourth_group" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, 0, null, "second_group" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Discriminator", "EducationCenterUserId", "GroupId" },
                values: new object[,]
                {
                    { 4, "Student", "86837c36-10b3-4af5-b53f-43331df6f6ad", 1 },
                    { 7, "Student", "f01a0643-8509-4d65-acfd-2f04d99e811a", 1 },
                    { 6, "Student", "f2f49e38-92ce-4275-9e1b-595984befeec", 3 },
                    { 8, "Student", "53b5ffde-9630-4258-87c3-9844dcb250c0", 3 },
                    { 5, "Student", "1df28a2d-bd21-4c77-b10c-d8631c7a0837", 2 }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicTitle",
                table: "Courses",
                column: "TopicTitle");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherId",
                table: "Groups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EducationCenterUserId",
                table: "Person",
                column: "EducationCenterUserId",
                unique: true,
                filter: "[EducationCenterUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GroupId",
                table: "Person",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Groups_GroupId",
                table: "Person",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_EducationCenterUserId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Topics_TopicTitle",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Person_TeacherId",
                table: "Groups");

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
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "StudingRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
