using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRate.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfEntering = table.Column<int>(type: "int", nullable: false),
                    SpecialtyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Specialties_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    CourseWork = table.Column<bool>(type: "bit", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_Professors_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AcademicPlans_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationCode = table.Column<long>(type: "bigint", nullable: false),
                    GradebookNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    ControlTypeID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_ControlTypes_ControlTypeID",
                        column: x => x.ControlTypeID,
                        principalTable: "ControlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ControlTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Екзамен" },
                    { 2, "Залік" },
                    { 3, "Курсова робота" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Факультет транспортних та інформаційних технологій" },
                    { 2, "Факультет економіки та права" },
                    { 3, "Факультет транспортного будівництва" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Комп'ютерна графіка" },
                    { 2, "Комп'ютерні мережі" },
                    { 3, "Математичні методи дослідження операцій" },
                    { 4, "Методи і системи штучного інтелекту" },
                    { 5, "Англійська мова" },
                    { 6, "Офісні технології" },
                    { 7, "Машинобудування" },
                    { 8, "Комп'ютерні системи статистичної обробки інформації" },
                    { 9, "Алгоритмізація і програмування" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Інформаційних систем і технологій" },
                    { 2, 1, "Кафедра комп’ютерної, інженерної графіки та дизайну" },
                    { 4, 2, "Іноземних мов" },
                    { 3, 3, "Кафедра дорожньо-будівельних матеріалів і хімії" }
                });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "FacultyID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Комп'ютерні науки" },
                    { 2, 1, "Програмна розробка" },
                    { 3, 2, "Документознавство" },
                    { 4, 3, "Машинобудування" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "SpecialtyID", "YearOfEntering" },
                values: new object[,]
                {
                    { 1, "КН-1", 1, 2017 },
                    { 2, "КН-2", 1, 2017 },
                    { 3, "ПР-1", 2, 2018 },
                    { 4, "ДЗ-1", 3, 2019 },
                    { 5, "МБ-1", 4, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "DepartmentID", "Email", "FirstName", "LastName", "MiddleName", "PasswordHash", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { 1, 1, "voronov_vg@ukr.net", "Василь", "Воронов", "Геннадійович", "AQAAAAEAACcQAAAAEPB738/RwtDoWss5LdZkWZ4XcaIUE0X7N9enF21AVV3WIunor/IAz2vD7hhxrhd6SA==", "+380663921056", "Доцент" },
                    { 2, 1, "marisag@gmail.com", "Марина", "Сагайдак", "Петрівна", "AQAAAAEAACcQAAAAEPwQ3xeXTo01kUEmcgQ5DCauHRuYAPwmOn9aHuiCpPUwRL7oPxOvJk3wolLMUZzf0w==", "+380666437156", "Старший викладач" },
                    { 3, 2, "superun2@i.ua", "Олексій", "Супрун", "Григорович", "AQAAAAEAACcQAAAAEPOkJKGaDUG1//DWyaWZ70LLT7QmXmDwldx1MTXb3axK5yfLdgHVqoK3UTKtXEtQWA==", "+380977787156", "Старший викладач" },
                    { 5, 2, "superun1@i.ua", "Петро", "Супрун", "Григорович", "AQAAAAEAACcQAAAAELx+nxhz/08pqeKg8ry8Q997p5CRqz1z3ecYSWVN99E55MGD6zdZJYz9lcztjzt73g==", "+380677742366", "Доцент" },
                    { 6, 4, "stupak.galina@gmail.com", "Галина", "Ступак", "Миколаївна", "AQAAAAEAACcQAAAAECj3q8yMSuc4Xxgf5DA9+agOgsm8EjBzFUiLgnz2EDbCDgJaDvPiyLTUaUKbQggkvA==", "+380980061326", "Старший викладач" },
                    { 4, 3, "voch_prof@ukr.net", "Володимир", "Черняхівський", "Олександрович", "AQAAAAEAACcQAAAAEC0MMrruu/BVP+0evdiwDldusQrEq8hF+2NG/dJCmHPEDN/QpDsNeuoLqsuuBk20ZA==", "+380957786666", "Професор" }
                });

            migrationBuilder.InsertData(
                table: "AcademicPlans",
                columns: new[] { "Id", "CourseWork", "GroupID", "Hours", "ProfessorID", "Semester", "SubjectID" },
                values: new object[,]
                {
                    { 1, false, 1, 0, 2, 1, 9 },
                    { 22, false, 2, 0, 1, 2, 1 },
                    { 25, false, 2, 0, 2, 3, 6 },
                    { 26, false, 2, 0, 2, 4, 6 },
                    { 27, false, 2, 0, 1, 5, 3 },
                    { 28, false, 2, 0, 1, 6, 3 },
                    { 30, false, 2, 0, 3, 6, 8 },
                    { 31, false, 2, 0, 3, 5, 8 },
                    { 32, false, 2, 0, 3, 6, 8 },
                    { 33, false, 2, 0, 3, 7, 4 },
                    { 34, false, 2, 0, 3, 8, 4 },
                    { 35, false, 2, 0, 5, 7, 2 },
                    { 21, false, 2, 0, 1, 1, 1 },
                    { 36, false, 2, 0, 5, 8, 2 },
                    { 38, false, 3, 0, 5, 2, 2 },
                    { 39, false, 3, 0, 3, 6, 3 },
                    { 40, false, 3, 0, 3, 5, 4 },
                    { 5, false, 1, 0, 6, 3, 5 },
                    { 6, false, 1, 0, 6, 4, 5 },
                    { 23, false, 2, 0, 6, 3, 5 },
                    { 24, false, 2, 0, 6, 4, 5 },
                    { 41, false, 4, 0, 6, 1, 5 },
                    { 42, false, 4, 0, 6, 2, 5 },
                    { 43, false, 5, 0, 4, 1, 7 },
                    { 44, false, 5, 0, 4, 2, 7 },
                    { 37, false, 3, 0, 5, 1, 2 },
                    { 20, false, 2, 0, 2, 2, 9 },
                    { 29, false, 2, 0, 3, 5, 8 },
                    { 15, false, 1, 0, 3, 7, 4 },
                    { 19, false, 2, 0, 2, 1, 9 },
                    { 12, false, 1, 0, 3, 6, 8 },
                    { 11, false, 1, 0, 3, 5, 8 },
                    { 16, false, 1, 0, 3, 8, 4 },
                    { 17, false, 1, 0, 5, 7, 2 },
                    { 14, false, 1, 0, 3, 6, 8 },
                    { 10, false, 1, 0, 1, 6, 3 },
                    { 9, false, 1, 0, 1, 5, 3 },
                    { 18, false, 1, 0, 5, 8, 2 },
                    { 7, false, 1, 0, 2, 3, 6 },
                    { 4, false, 1, 0, 1, 2, 1 },
                    { 3, false, 1, 0, 1, 1, 1 },
                    { 2, false, 1, 0, 2, 2, 9 }
                });

            migrationBuilder.InsertData(
                table: "AcademicPlans",
                columns: new[] { "Id", "CourseWork", "GroupID", "Hours", "ProfessorID", "Semester", "SubjectID" },
                values: new object[,]
                {
                    { 8, false, 1, 0, 2, 4, 6 },
                    { 13, false, 1, 0, 3, 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "GradebookNumber", "GroupID", "IdentificationCode", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { 21, null, "Сабір", "GB00021", 4, 358358L, "Ізмаілов", "Арашович" },
                    { 22, null, "Вікторія", "GB00022", 4, 32462436246L, "Маміна", "Дмитрівна" },
                    { 20, null, "Владислав", "GB00020", 3, 7357357L, "Грихін", "Олександрович" },
                    { 19, null, "Григорій", "GB00019", 3, 354735732L, "Семенов", "Васильович" },
                    { 18, null, "Іван", "GB00018", 3, 463457835L, "Петренко", "Іванович" },
                    { 17, null, "Іван", "GB00017", 3, 8735354245L, "Ярошенко", "Сергійович" },
                    { 23, null, "Дмитро", "GB00023", 5, 734527532L, "Губар", "Олександрович" },
                    { 10, null, "Григорій", "GB00010", 1, 732573254724L, "Григоров", "Григорович" },
                    { 15, null, "Григорій", "GB00015", 2, 7345735775L, "Калачов", "Іванович" },
                    { 9, null, "Іван", "GB00009", 1, 3853858542L, "Іванов", "Іванович" },
                    { 8, null, "Єлизавета", "GB00008", 1, 73357357357L, "Кошкіна", "Русланівна" },
                    { 7, null, "Сергій", "GB00007", 1, 34743576345L, "Дощ", "Володимирович" },
                    { 6, null, "Марина", "GB00006", 1, 7435743573L, "Крисак", "Іванівна" },
                    { 5, null, "Іван", "GB00005", 1, 46347357357L, "Васильов", "Геннадійович" },
                    { 24, null, "Петро", "GB00024", 5, 13245137L, "Петренко", "Олександрович" },
                    { 16, null, "Дарина", "GB00016", 2, 73573573579L, "Калачова", "Ігорівна" },
                    { 4, null, "Микола", "GB00004", 1, 354635635L, "Іванов", "Миколайович" },
                    { 2, null, "Петро", "GB00002", 1, 13651636136L, "Сагайдак", "Іванович" },
                    { 1, null, "Василь", "GB00001", 1, 2436123613636L, "Чигирин", "Іванович" },
                    { 11, null, "Микола", "GB00011", 2, 75372429846L, "Колісніченко", "Миколайович" },
                    { 12, null, "Генадій", "GB00012", 2, 247427423L, "Ковальчук", "Петрович" },
                    { 13, null, "Тетяна", "GB00013", 2, 7537357L, "Мірінець", "Вікторівна" },
                    { 14, null, "Микола", "GB00014", 2, 73458346342L, "Коваль", "Петрович" },
                    { 3, null, "Ганна", "GB00003", 1, 6546346346L, "Сахно", "Петрівна" },
                    { 25, null, "Дмитро", "GB00025", 5, 73345735473L, "Кабачинський", "Дмитрович" }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 1, 1, 9 },
                    { 266, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 7, 12, 4 },
                    { 260, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 6, 12, 8 },
                    { 254, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 5, 12, 8 },
                    { 248, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 6, 12, 8 },
                    { 242, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 5, 12, 8 },
                    { 236, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 6, 12, 3 },
                    { 230, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 5, 12, 3 },
                    { 224, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 4, 12, 6 },
                    { 218, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 3, 12, 6 },
                    { 212, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 4, 12, 5 },
                    { 206, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 3, 12, 5 },
                    { 200, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 2, 12, 1 },
                    { 194, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1, 12, 1 },
                    { 188, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 12, 9 },
                    { 182, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 1, 12, 9 },
                    { 272, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 8, 12, 4 },
                    { 278, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 7, 12, 2 },
                    { 284, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 8, 12, 2 },
                    { 183, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 13, 9 },
                    { 279, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 7, 13, 2 },
                    { 273, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 8, 13, 4 },
                    { 267, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 7, 13, 4 },
                    { 261, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 6, 13, 8 },
                    { 255, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 5, 13, 8 },
                    { 249, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 6, 13, 8 },
                    { 243, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 5, 13, 8 },
                    { 283, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 8, 11, 2 },
                    { 237, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 6, 13, 3 },
                    { 225, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 4, 13, 6 },
                    { 219, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 3, 13, 6 },
                    { 213, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 4, 13, 5 },
                    { 207, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 3, 13, 5 },
                    { 201, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2, 13, 1 },
                    { 195, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 1, 13, 1 },
                    { 189, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 13, 9 },
                    { 231, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 5, 13, 3 },
                    { 285, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 8, 13, 2 },
                    { 277, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 7, 11, 2 },
                    { 265, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 7, 11, 4 },
                    { 120, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 6, 10, 9 },
                    { 110, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 5, 10, 9 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 100, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 6, 10, 3 },
                    { 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 5, 10, 3 },
                    { 80, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 4, 10, 6 },
                    { 70, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 3, 10, 6 },
                    { 60, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 4, 10, 5 },
                    { 50, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 3, 10, 5 },
                    { 40, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 10, 1 },
                    { 30, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1, 10, 1 },
                    { 20, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 2, 10, 9 },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 1, 10, 9 },
                    { 179, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 8, 9, 2 },
                    { 169, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 7, 9, 2 },
                    { 159, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 8, 9, 4 },
                    { 130, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 5, 10, 8 },
                    { 140, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 6, 10, 8 },
                    { 150, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 7, 10, 4 },
                    { 160, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 8, 10, 4 },
                    { 259, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 11, 8 },
                    { 253, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 5, 11, 8 },
                    { 247, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 6, 11, 8 },
                    { 241, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 5, 11, 8 },
                    { 235, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 6, 11, 3 },
                    { 229, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 5, 11, 3 },
                    { 223, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 4, 11, 6 },
                    { 271, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 8, 11, 4 },
                    { 217, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 3, 11, 6 },
                    { 205, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 3, 11, 5 },
                    { 199, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 2, 11, 1 },
                    { 193, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 11, 1 },
                    { 187, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 11, 9 },
                    { 181, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 1, 11, 9 },
                    { 180, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 8, 10, 2 },
                    { 170, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 7, 10, 2 },
                    { 211, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 4, 11, 5 },
                    { 184, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 1, 14, 9 },
                    { 190, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 2, 14, 9 },
                    { 196, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1, 14, 1 },
                    { 301, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 5, 17, 4 },
                    { 297, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 6, 17, 3 },
                    { 293, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 2, 17, 2 },
                    { 289, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 1, 17, 2 },
                    { 288, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 8, 16, 2 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 282, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 7, 16, 2 },
                    { 276, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 8, 16, 4 },
                    { 270, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 7, 16, 4 },
                    { 264, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 6, 16, 8 },
                    { 258, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 5, 16, 8 },
                    { 252, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 6, 16, 8 },
                    { 246, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 5, 16, 8 },
                    { 240, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 6, 16, 3 },
                    { 234, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 5, 16, 3 },
                    { 228, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 16, 6 },
                    { 290, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1, 18, 2 },
                    { 294, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 18, 2 },
                    { 298, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 6, 18, 3 },
                    { 302, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 5, 18, 4 },
                    { 313, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 24, 7 },
                    { 310, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 1, 24, 7 },
                    { 312, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2, 23, 7 },
                    { 309, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 1, 23, 7 },
                    { 308, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 2, 22, 5 },
                    { 306, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1, 22, 5 },
                    { 307, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 21, 5 },
                    { 222, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3, 16, 6 },
                    { 305, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1, 21, 5 },
                    { 300, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 20, 3 },
                    { 296, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 2, 20, 2 },
                    { 292, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 1, 20, 2 },
                    { 303, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 5, 19, 4 },
                    { 299, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 6, 19, 3 },
                    { 295, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 2, 19, 2 },
                    { 291, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 1, 19, 2 },
                    { 304, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 5, 20, 4 },
                    { 216, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 4, 16, 5 },
                    { 210, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 3, 16, 5 },
                    { 204, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 2, 16, 1 },
                    { 185, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 1, 15, 9 },
                    { 286, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 8, 14, 2 },
                    { 280, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 7, 14, 2 },
                    { 274, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 8, 14, 4 },
                    { 268, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 7, 14, 4 },
                    { 262, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 6, 14, 8 },
                    { 256, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 5, 14, 8 },
                    { 191, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2, 15, 9 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 250, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 6, 14, 8 },
                    { 238, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 6, 14, 3 },
                    { 232, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 5, 14, 3 },
                    { 226, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 4, 14, 6 },
                    { 220, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 3, 14, 6 },
                    { 214, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 4, 14, 5 },
                    { 208, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 3, 14, 5 },
                    { 202, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 2, 14, 1 },
                    { 244, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 5, 14, 8 },
                    { 149, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 7, 9, 4 },
                    { 197, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 15, 1 },
                    { 209, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 3, 15, 5 },
                    { 198, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 16, 1 },
                    { 192, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 16, 9 },
                    { 186, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1, 16, 9 },
                    { 287, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 8, 15, 2 },
                    { 281, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 7, 15, 2 },
                    { 275, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 8, 15, 4 },
                    { 269, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 7, 15, 4 },
                    { 203, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 2, 15, 1 },
                    { 263, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 6, 15, 8 },
                    { 251, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 6, 15, 8 },
                    { 245, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 5, 15, 8 },
                    { 239, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 6, 15, 3 },
                    { 233, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 5, 15, 3 },
                    { 227, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 4, 15, 6 },
                    { 221, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 3, 15, 6 },
                    { 215, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 4, 15, 5 },
                    { 257, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 5, 15, 8 },
                    { 139, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 6, 9, 8 },
                    { 129, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 5, 9, 8 },
                    { 119, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 6, 9, 9 },
                    { 14, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 2, 4, 9 },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 1, 4, 9 },
                    { 173, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 8, 3, 2 },
                    { 163, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 7, 3, 2 },
                    { 153, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 8, 3, 4 },
                    { 143, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 7, 3, 4 },
                    { 133, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 3, 8 },
                    { 123, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 5, 3, 8 },
                    { 113, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 6, 3, 9 },
                    { 103, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 5, 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 93, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 6, 3, 3 },
                    { 83, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 5, 3, 3 },
                    { 73, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 4, 3, 6 },
                    { 63, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 3, 3, 6 },
                    { 53, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 4, 3, 5 },
                    { 24, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1, 4, 1 },
                    { 34, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 2, 4, 1 },
                    { 44, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 3, 4, 5 },
                    { 54, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 4, 4, 5 },
                    { 35, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 2, 5, 1 },
                    { 25, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1, 5, 1 },
                    { 15, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 2, 5, 9 },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 1, 5, 9 },
                    { 174, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 8, 4, 2 },
                    { 164, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 7, 4, 2 },
                    { 154, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 8, 4, 4 },
                    { 43, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 3, 3, 5 },
                    { 144, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 7, 4, 4 },
                    { 124, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 5, 4, 8 },
                    { 114, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 6, 4, 9 },
                    { 104, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 5, 4, 9 },
                    { 94, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 4, 3 },
                    { 84, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 5, 4, 3 },
                    { 74, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 4, 6 },
                    { 64, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 3, 4, 6 },
                    { 134, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 6, 4, 8 },
                    { 33, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 3, 1 },
                    { 23, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1, 3, 1 },
                    { 13, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 3, 9 },
                    { 161, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 7, 1, 2 },
                    { 151, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 8, 1, 4 },
                    { 141, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 7, 1, 4 },
                    { 131, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 6, 1, 8 },
                    { 121, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 5, 1, 8 },
                    { 111, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 6, 1, 9 },
                    { 101, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 5, 1, 9 },
                    { 171, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 8, 1, 2 },
                    { 91, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 6, 1, 3 },
                    { 71, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 4, 1, 6 },
                    { 61, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 1, 6 },
                    { 51, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 4, 1, 5 },
                    { 41, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 3, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 31, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 1, 1 },
                    { 21, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 1, 1, 1 },
                    { 11, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 2, 1, 9 },
                    { 81, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 5, 1, 3 },
                    { 45, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 3, 5, 5 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 1, 2, 9 },
                    { 22, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 1, 2, 1 },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1, 3, 9 },
                    { 172, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 8, 2, 2 },
                    { 162, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 7, 2, 2 },
                    { 152, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 8, 2, 4 },
                    { 142, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 7, 2, 4 },
                    { 132, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 6, 2, 8 },
                    { 122, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 5, 2, 8 },
                    { 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 2, 2, 9 },
                    { 112, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 6, 2, 9 },
                    { 92, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 6, 2, 3 },
                    { 82, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 5, 2, 3 },
                    { 72, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 4, 2, 6 },
                    { 62, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 3, 2, 6 },
                    { 52, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 4, 2, 5 },
                    { 42, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 3, 2, 5 },
                    { 32, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 2, 2, 1 },
                    { 102, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 5, 2, 9 },
                    { 311, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 1, 25, 7 },
                    { 55, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 4, 5, 5 },
                    { 75, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 4, 5, 6 },
                    { 88, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 5, 8, 3 },
                    { 78, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 4, 8, 6 },
                    { 68, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 3, 8, 6 },
                    { 58, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 4, 8, 5 },
                    { 48, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 3, 8, 5 },
                    { 38, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 2, 8, 1 },
                    { 28, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1, 8, 1 },
                    { 18, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 2, 8, 9 },
                    { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1, 8, 9 },
                    { 177, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 8, 7, 2 },
                    { 167, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 7, 7, 2 },
                    { 157, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 8, 7, 4 },
                    { 147, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 7, 7, 4 },
                    { 137, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 6, 7, 8 },
                    { 127, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 5, 7, 8 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 98, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 6, 8, 3 },
                    { 108, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 5, 8, 9 },
                    { 118, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 6, 8, 9 },
                    { 128, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 5, 8, 8 },
                    { 109, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 5, 9, 9 },
                    { 99, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 9, 3 },
                    { 89, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 5, 9, 3 },
                    { 79, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 4, 9, 6 },
                    { 69, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 3, 9, 6 },
                    { 59, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 4, 9, 5 },
                    { 49, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 3, 9, 5 },
                    { 117, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 7, 9 },
                    { 39, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 9, 1 },
                    { 19, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 2, 9, 9 },
                    { 9, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1, 9, 9 },
                    { 178, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 8, 8, 2 },
                    { 168, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 7, 8, 2 },
                    { 158, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 8, 8, 4 },
                    { 148, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 7, 8, 4 },
                    { 138, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 6, 8, 8 },
                    { 29, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 1, 9, 1 },
                    { 107, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 5, 7, 9 },
                    { 97, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 6, 7, 3 },
                    { 87, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 5, 7, 3 },
                    { 56, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 4, 6, 5 },
                    { 46, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 3, 6, 5 },
                    { 36, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 2, 6, 1 },
                    { 26, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 1, 6, 1 },
                    { 16, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 2, 6, 9 },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 1, 6, 9 },
                    { 175, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 8, 5, 2 },
                    { 66, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 6, 6 },
                    { 165, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 7, 5, 2 },
                    { 145, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 7, 5, 4 },
                    { 135, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 6, 5, 8 },
                    { 125, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 5, 5, 8 },
                    { 115, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 6, 5, 9 },
                    { 105, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 5, 5, 9 },
                    { 95, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 6, 5, 3 },
                    { 85, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 5, 5, 3 },
                    { 155, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 8, 5, 4 },
                    { 65, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 3, 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "ControlTypeID", "DateAdded", "Score", "Semester", "StudentID", "SubjectID" },
                values: new object[,]
                {
                    { 76, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 4, 6, 6 },
                    { 96, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 6, 6, 3 },
                    { 77, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 4, 7, 6 },
                    { 67, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 3, 7, 6 },
                    { 57, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 7, 5 },
                    { 47, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 3, 7, 5 },
                    { 37, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 2, 7, 1 },
                    { 27, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1, 7, 1 },
                    { 17, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 7, 9 },
                    { 86, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 5, 6, 3 },
                    { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 1, 7, 9 },
                    { 166, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 7, 6, 2 },
                    { 156, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 8, 6, 4 },
                    { 146, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 7, 6, 4 },
                    { 136, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 6, 6, 8 },
                    { 126, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 5, 6, 8 },
                    { 116, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 6, 6, 9 },
                    { 106, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 5, 6, 9 },
                    { 176, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 8, 6, 2 },
                    { 314, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 2, 25, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_GroupID",
                table: "AcademicPlans",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_ProfessorID",
                table: "AcademicPlans",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPlans_SubjectID",
                table: "AcademicPlans",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyID",
                table: "Departments",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyID",
                table: "Groups",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ControlTypeID",
                table: "Marks",
                column: "ControlTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentID",
                table: "Marks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectID",
                table: "Marks",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_DepartmentID",
                table: "Professors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_FacultyID",
                table: "Specialties",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupID",
                table: "Students",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicPlans");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "ControlTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
