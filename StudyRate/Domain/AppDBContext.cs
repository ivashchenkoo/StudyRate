using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AcademicPlan> AcademicPlans { get; set; }
        public DbSet<ControlType> ControlTypes { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Username = "Oleksandr_Iv",
                Password_hash = "admin12345"
            });

            modelBuilder.Entity<Faculty>().HasData(new Faculty
            {
                Id = 1,
                Name = "Факультет транспортних та інформаційних технологій",
                ShortForm = "ФТІТ"
            });

            modelBuilder.Entity<Faculty>().HasData(new Faculty
            {
                Id = 2,
                Name = "Факультет економіки та права",
                ShortForm = "ФЕП"
            });

            modelBuilder.Entity<Faculty>().HasData(new Faculty
            {
                Id = 3,
                Name = "Факультет транспортного будівництва",
                ShortForm = "ФТБ"
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "Інформаційних систем і технологій",
                FacultyID = 1
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                Name = "Кафедра комп’ютерної, інженерної графіки та дизайну",
                FacultyID = 1
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                Name = "Кафедра дорожньо-будівельних матеріалів і хімії",
                FacultyID = 3
            });

            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 4,
                Name = "Іноземних мов",
                FacultyID = 2
            });

            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 1,
                Name = "Викладач",
                ShortForm = "Викл."
            });

            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 2,
                Name = "Старший викладач",
                ShortForm = "Ст. викл."
            });

            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 3,
                Name = "Доцент",
                ShortForm = "Доц."
            });

            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 4,
                Name = "Професор",
                ShortForm = "Проф."
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 1,
                FirstName = "Василь",
                MiddleName = "Геннадійович",
                LastName = "Воронов",
                PhoneNumber = "+380663921056",
                PositionID = 3,
                DepartmentID = 1,
                Email = "voronov_vg@ukr.net",
                PasswordHash = "25y8VeXDr6"
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 2,
                FirstName = "Марина",
                MiddleName = "Петрівна",
                LastName = "Сагайдак",
                PhoneNumber = "+380666437156",
                PositionID = 2,
                DepartmentID = 1,
                Email = "marisag@gmail.com",
                PasswordHash = "7M479dMKyt"
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 3,
                FirstName = "Олексій",
                MiddleName = "Григорович",
                LastName = "Супрун",
                PhoneNumber = "+380977787156",
                PositionID = 1,
                DepartmentID = 2,
                Email = "superun2@i.ua",
                PasswordHash = "fUGbd4F557"
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 4,
                FirstName = "Володимир",
                MiddleName = "Олександрович",
                LastName = "Черняхівський",
                PhoneNumber = "+380957786666",
                PositionID = 4,
                DepartmentID = 3,
                Email = "voch_prof@ukr.net",
                PasswordHash = "tFBvcS4548"
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 5,
                FirstName = "Петро",
                MiddleName = "Григорович",
                LastName = "Супрун",
                PhoneNumber = "+380677742366",
                PositionID = 3,
                DepartmentID = 2,
                Email = "superun1@i.ua",
                PasswordHash = "V9cR5vZ79z"
            });

            modelBuilder.Entity<Professor>().HasData(new Professor
            {
                Id = 6,
                FirstName = "Галина",
                MiddleName = "Миколаївна",
                LastName = "Ступак",
                PhoneNumber = "+380980061326",
                PositionID = 2,
                DepartmentID = 4,
                Email = "stupak.galina@gmail.com",
                PasswordHash = "ZH8L6znt45"
            });

            modelBuilder.Entity<Specialty>().HasData(new Specialty
            {
                Id = 1,
                Name = "Комп'ютерні науки",
                FacultyID = 1
            });

            modelBuilder.Entity<Specialty>().HasData(new Specialty
            {
                Id = 2,
                Name = "Програмна розробка",
                FacultyID = 1
            });

            modelBuilder.Entity<Specialty>().HasData(new Specialty
            {
                Id = 3,
                Name = "Документознавство",
                FacultyID = 2
            });

            modelBuilder.Entity<Specialty>().HasData(new Specialty
            {
                Id = 4,
                Name = "Машинобудування",
                FacultyID = 3
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 1,
                Name = "КН-1",
                YearOfEntering = 2017,
                SpecialtyID = 1
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 2,
                Name = "КН-2",
                YearOfEntering = 2017,
                SpecialtyID = 1
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 3,
                Name = "ПР-1",
                YearOfEntering = 2018,
                SpecialtyID = 2
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 4,
                Name = "ДЗ-1",
                YearOfEntering = 2019,
                SpecialtyID = 3
            });

            modelBuilder.Entity<Group>().HasData(new Group
            {
                Id = 5,
                Name = "МБ-1",
                YearOfEntering = 2019,
                SpecialtyID = 4
            });

            modelBuilder.Entity<ControlType>().HasData(new ControlType
            {
                Id = 1,
                Name = "Екзамен"
            });

            modelBuilder.Entity<ControlType>().HasData(new ControlType
            {
                Id = 2,
                Name = "Залік"
            });

            modelBuilder.Entity<ControlType>().HasData(new ControlType
            {
                Id = 3,
                Name = "Курсова робота"
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 1,
                Name = "Комп'ютерна графіка",
            });
            
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 2,
                Name = "Комп'ютерні мережі",
            });
            
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 3,
                Name = "Математичні методи дослідження операцій",
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 4,
                Name = "Методи і системи штучного інтелекту",
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 5,
                Name = "Англійська мова",
            });
            
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 6,
                Name = "Офісні технології",
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 7,
                Name = "Машинобудування",
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 8, 
                Name = "Комп'ютерні системи статистичної обробки інформації",
            });

            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                Id = 9, 
                Name = "Алгоритмізація і програмування",
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 1, 
                GroupID = 1,
                SubjectID = 9,
                Semester = 1,
                ProfessorID = 2
            });
            
            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 2, 
                GroupID = 1,
                SubjectID = 9,
                Semester = 2,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 3,
                GroupID = 1,
                SubjectID = 1,
                Semester = 1,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 4,
                GroupID = 1,
                SubjectID = 1,
                Semester = 2,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 5,
                GroupID = 1,
                SubjectID = 5,
                Semester = 3,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 6,
                GroupID = 1,
                SubjectID = 5,
                Semester = 4,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 7,
                GroupID = 1,
                SubjectID = 6,
                Semester = 3,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 8,
                GroupID = 1,
                SubjectID = 6,
                Semester = 4,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 9,
                GroupID = 1,
                SubjectID = 3,
                Semester = 5,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 10,
                GroupID = 1,
                SubjectID = 3,
                Semester = 6,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 11,
                GroupID = 1,
                SubjectID = 8,
                Semester = 5,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 12,
                GroupID = 1,
                SubjectID = 8,
                Semester = 6,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 13,
                GroupID = 1,
                SubjectID = 8,
                Semester = 5,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 14,
                GroupID = 1,
                SubjectID = 8,
                Semester = 6,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 15,
                GroupID = 1,
                SubjectID = 4,
                Semester = 7,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 16,
                GroupID = 1,
                SubjectID = 4,
                Semester = 8,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 17,
                GroupID = 1,
                SubjectID = 2,
                Semester = 7,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 18,
                GroupID = 1,
                SubjectID = 2,
                Semester = 8,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 19,
                GroupID = 2,
                SubjectID = 9,
                Semester = 1,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 20,
                GroupID = 2,
                SubjectID = 9,
                Semester = 2,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 21,
                GroupID = 2,
                SubjectID = 1,
                Semester = 1,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 22,
                GroupID = 2,
                SubjectID = 1,
                Semester = 2,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 23,
                GroupID = 2,
                SubjectID = 5,
                Semester = 3,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 24,
                GroupID = 2,
                SubjectID = 5,
                Semester = 4,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 25,
                GroupID = 2,
                SubjectID = 6,
                Semester = 3,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 26,
                GroupID = 2,
                SubjectID = 6,
                Semester = 4,
                ProfessorID = 2
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 27,
                GroupID = 2,
                SubjectID = 3,
                Semester = 5,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 28,
                GroupID = 2,
                SubjectID = 3,
                Semester = 6,
                ProfessorID = 1
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 29,
                GroupID = 2,
                SubjectID = 8,
                Semester = 5,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 30,
                GroupID = 2,
                SubjectID = 8,
                Semester = 6,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 31,
                GroupID = 2,
                SubjectID = 8,
                Semester = 5,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 32,
                GroupID = 2,
                SubjectID = 8,
                Semester = 6,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 33,
                GroupID = 2,
                SubjectID = 4,
                Semester = 7,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 34,
                GroupID = 2,
                SubjectID = 4,
                Semester = 8,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 35,
                GroupID = 2,
                SubjectID = 2,
                Semester = 7,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 36,
                GroupID = 2,
                SubjectID = 2,
                Semester = 8,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 37,
                GroupID = 3,
                SubjectID = 2,
                Semester = 1,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 38,
                GroupID = 3,
                SubjectID = 2,
                Semester = 2,
                ProfessorID = 5
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 39,
                GroupID = 3,
                SubjectID = 3,
                Semester = 6,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 40,
                GroupID = 3,
                SubjectID = 4,
                Semester = 5,
                ProfessorID = 3
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 41,
                GroupID = 4,
                SubjectID = 5,
                Semester = 1,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 42,
                GroupID = 4,
                SubjectID = 5,
                Semester = 2,
                ProfessorID = 6
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 43,
                GroupID = 5,
                SubjectID = 7,
                Semester = 1,
                ProfessorID = 4
            });

            modelBuilder.Entity<AcademicPlan>().HasData(new AcademicPlan
            {
                Id = 44,
                GroupID = 5,
                SubjectID = 7,
                Semester = 2,
                ProfessorID = 4
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "Василь",
                MiddleName = "Іванович",
                LastName = "Чигирин",
                IdentificationCode = 2436123613636,
                GradebookNumber = "GB00001",
                GroupID = 1
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 2,
                FirstName = "Петро",
                MiddleName = "Іванович",
                LastName = "Сагайдак",
                IdentificationCode = 13651636136,
                GradebookNumber = "GB00002",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 3,
                FirstName = "Ганна",
                MiddleName = "Петрівна",
                LastName = "Сахно",
                IdentificationCode = 6546346346,
                GradebookNumber = "GB00003",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 4,
                FirstName = "Микола",
                MiddleName = "Миколайович",
                LastName = "Іванов",
                IdentificationCode = 354635635,
                GradebookNumber = "GB00004",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 5,
                FirstName = "Іван",
                MiddleName = "Геннадійович",
                LastName = "Васильов",
                IdentificationCode = 46347357357,
                GradebookNumber = "GB00005",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 6,
                FirstName = "Марина",
                MiddleName = "Іванівна",
                LastName = "Крисак",
                IdentificationCode = 7435743573,
                GradebookNumber = "GB00006",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 7,
                FirstName = "Сергій",
                MiddleName = "Володимирович",
                LastName = "Дощ",
                IdentificationCode = 34743576345,
                GradebookNumber = "GB00007",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 8,
                FirstName = "Єлизавета",
                MiddleName = "Русланівна",
                LastName = "Кошкіна",
                IdentificationCode = 73357357357,
                GradebookNumber = "GB00008",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 9,
                FirstName = "Іван",
                MiddleName = "Іванович",
                LastName = "Іванов",
                IdentificationCode = 3853858542,
                GradebookNumber = "GB00009",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 10,
                FirstName = "Григорій",
                MiddleName = "Григорович",
                LastName = "Григоров",
                IdentificationCode = 732573254724,
                GradebookNumber = "GB00010",
                GroupID = 1
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 11,
                FirstName = "Микола",
                MiddleName = "Миколайович",
                LastName = "Колісніченко",
                IdentificationCode = 75372429846,
                GradebookNumber = "GB00011",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 12,
                FirstName = "Генадій",
                MiddleName = "Петрович",
                LastName = "Ковальчук",
                IdentificationCode = 247427423,
                GradebookNumber = "GB00012",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 13,
                FirstName = "Тетяна",
                MiddleName = "Вікторівна",
                LastName = "Мірінець",
                IdentificationCode = 7537357,
                GradebookNumber = "GB00013",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 14,
                FirstName = "Микола",
                MiddleName = "Петрович",
                LastName = "Коваль",
                IdentificationCode = 73458346342,
                GradebookNumber = "GB00014",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 15,
                FirstName = "Григорій",
                MiddleName = "Іванович",
                LastName = "Калачов",
                IdentificationCode = 7345735775,
                GradebookNumber = "GB00015",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 16,
                FirstName = "Дарина",
                MiddleName = "Ігорівна",
                LastName = "Калачова",
                IdentificationCode = 73573573579,
                GradebookNumber = "GB00016",
                GroupID = 2
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 17,
                FirstName = "Іван",
                MiddleName = "Сергійович",
                LastName = "Ярошенко",
                IdentificationCode = 8735354245,
                GradebookNumber = "GB00017",
                GroupID = 3
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 18,
                FirstName = "Іван",
                MiddleName = "Іванович",
                LastName = "Петренко",
                IdentificationCode = 463457835,
                GradebookNumber = "GB00018",
                GroupID = 3
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 19,
                FirstName = "Григорій",
                MiddleName = "Васильович",
                LastName = "Семенов",
                IdentificationCode = 354735732,
                GradebookNumber = "GB00019",
                GroupID = 3
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 20,
                FirstName = "Владислав",
                MiddleName = "Олександрович",
                LastName = "Грихін",
                IdentificationCode = 7357357,
                GradebookNumber = "GB00020",
                GroupID = 3
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 21,
                FirstName = "Сабір",
                MiddleName = "Арашович",
                LastName = "Ізмаілов",
                IdentificationCode = 358358,
                GradebookNumber = "GB00021",
                GroupID = 4
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 22,
                FirstName = "Вікторія",
                MiddleName = "Дмитрівна",
                LastName = "Маміна",
                IdentificationCode = 32462436246,
                GradebookNumber = "GB00022",
                GroupID = 4
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 23,
                FirstName = "Дмитро",
                MiddleName = "Олександрович",
                LastName = "Губар",
                IdentificationCode = 734527532,
                GradebookNumber = "GB00023",
                GroupID = 5
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 24,
                FirstName = "Петро",
                MiddleName = "Олександрович",
                LastName = "Петренко",
                IdentificationCode = 13245137,
                GradebookNumber = "GB00024",
                GroupID = 5
            });
            
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 25,
                FirstName = "Дмитро",
                MiddleName = "Дмитрович",
                LastName = "Кабачинський",
                IdentificationCode = 73345735473,
                GradebookNumber = "GB00025",
                GroupID = 5
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 1,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 2,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 3,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 4,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 5,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 6,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 7,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 8,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 9,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 10,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 11,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 12,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 13,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 14,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 15,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 16,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 17,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 18,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 19,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 20,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 21,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 22,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 23,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 24,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 25,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 26,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 27,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 28,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 29,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 30,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 31,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 32,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 33,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 34,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 35,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 36,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 37,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 38,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 39,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 40,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 41,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 42,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 43,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 44,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 45,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 46,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 47,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 48,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 49,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 50,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 51,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 52,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 53,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 54,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 55,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 56,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 57,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 58,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 59,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 60,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 61,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 62,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 63,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 64,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 65,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 66,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 67,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 68,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 69,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 70,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 3,
                SubjectID = 6,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 71,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 72,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 73,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 74,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 75,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 76,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 77,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 78,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 79,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 80,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 81,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 82,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 83,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 84,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 85,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 86,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 87,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 88,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 89,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 90,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 91,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 92,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 93,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 94,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 95,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 96,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 97,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 98,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 99,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 100,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 101,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 102,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 103,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 104,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 105,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 106,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 107,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 108,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 109,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 110,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 9,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 111,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 112,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 113,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 114,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 115,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 116,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 117,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 118,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 119,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 120,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 9,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 121,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 122,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 123,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 124,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 125,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 126,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 127,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 128,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 129,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 130,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 5,
                SubjectID = 8,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 131,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 132,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 133,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 134,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 135,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 136,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 137,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 138,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 139,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 140,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 141,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 142,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 143,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 144,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 145,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 146,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 147,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 148,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 149,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 150,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 151,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 152,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 153,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 154,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 155,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 156,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 157,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 158,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 159,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 160,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 161,
                StudentID = 1,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 162,
                StudentID = 2,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 163,
                StudentID = 3,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 164,
                StudentID = 4,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 165,
                StudentID = 5,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 166,
                StudentID = 6,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 167,
                StudentID = 7,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 168,
                StudentID = 8,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 169,
                StudentID = 9,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 170,
                StudentID = 10,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 171,
                StudentID = 1,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 172,
                StudentID = 2,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 173,
                StudentID = 3,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 174,
                StudentID = 4,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 175,
                StudentID = 5,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 176,
                StudentID = 6,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 177,
                StudentID = 7,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 99
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 178,
                StudentID = 8,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 179,
                StudentID = 9,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 180,
                StudentID = 10,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 181,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 71
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 182,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 183,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 184,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 185,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 71
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 186,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 9,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 187,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 188,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 189,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 190,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 65
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 191,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 192,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 9,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 193,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 194,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 77
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 195,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 196,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 197,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 198,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 1,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 199,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 68
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 200,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 201,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 202,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 66
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 203,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 204,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 1,
                Score = 65
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 205,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 206,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 207,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 208,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 66
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 209,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 210,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 5,
                Score = 67
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 211,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 212,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 71
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 213,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 214,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 67
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 215,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 216,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 5,
                Score = 87
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 217,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 77
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 218,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 70
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 219,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 71
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 220,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 221,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 222,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 3,
                SubjectID = 6,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 223,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 224,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 75
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 225,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 226,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 227,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 65
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 228,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 4,
                SubjectID = 6,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 229,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 230,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 231,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 232,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 233,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 234,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 3,
                Score = 66
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 235,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 84
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 236,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 69
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 237,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 238,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 239,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 240,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 3,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 241,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 242,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 75
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 243,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 67
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 244,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 245,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 246,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 247,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 66
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 248,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 249,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 67
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 250,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 65
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 251,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 252,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 253,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 254,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 255,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 256,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 70
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 257,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 258,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 5,
                SubjectID = 8,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 259,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 260,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 261,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 262,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 263,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 264,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 6,
                SubjectID = 8,
                Score = 69
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 265,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 80
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 266,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 94
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 267,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 268,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 86
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 269,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 270,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 4,
                Score = 69
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 271,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 272,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 273,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 274,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 275,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 276,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 4,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 277,
                StudentID = 11,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 70
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 278,
                StudentID = 12,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 279,
                StudentID = 13,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 280,
                StudentID = 14,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 69
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 281,
                StudentID = 15,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 282,
                StudentID = 16,
                ControlTypeID = 1,
                Semester = 7,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 283,
                StudentID = 11,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 284,
                StudentID = 12,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 81
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 285,
                StudentID = 13,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 78
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 286,
                StudentID = 14,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 73
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 287,
                StudentID = 15,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 71
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 288,
                StudentID = 16,
                ControlTypeID = 2,
                Semester = 8,
                SubjectID = 2,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 289,
                StudentID = 17,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 2,
                Score = 91
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 290,
                StudentID = 18,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 2,
                Score = 77
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 291,
                StudentID = 19,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 2,
                Score = 75
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 292,
                StudentID = 20,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 2,
                Score = 74
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 293,
                StudentID = 17,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 2,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 294,
                StudentID = 18,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 2,
                Score = 92
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 295,
                StudentID = 19,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 296,
                StudentID = 20,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 2,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 297,
                StudentID = 17,
                ControlTypeID = 1,
                Semester = 6,
                SubjectID = 3,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 298,
                StudentID = 18,
                ControlTypeID = 1,
                Semester = 6,
                SubjectID = 3,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 299,
                StudentID = 19,
                ControlTypeID = 1,
                Semester = 6,
                SubjectID = 3,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 300,
                StudentID = 20,
                ControlTypeID = 1,
                Semester = 6,
                SubjectID = 3,
                Score = 83
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 301,
                StudentID = 17,
                ControlTypeID = 2,
                Semester = 5,
                SubjectID = 4,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 302,
                StudentID = 18,
                ControlTypeID = 2,
                Semester = 5,
                SubjectID = 4,
                Score = 72
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 303,
                StudentID = 19,
                ControlTypeID = 2,
                Semester = 5,
                SubjectID = 4,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 304,
                StudentID = 20,
                ControlTypeID = 2,
                Semester = 5,
                SubjectID = 4,
                Score = 97
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 305,
                StudentID = 21,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 5,
                Score = 82
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 306,
                StudentID = 22,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 5,
                Score = 77
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 307,
                StudentID = 21,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 5,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 308,
                StudentID = 22,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 5,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 309,
                StudentID = 23,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 7,
                Score = 89
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 310,
                StudentID = 24,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 7,
                Score = 88
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 311,
                StudentID = 25,
                ControlTypeID = 1,
                Semester = 1,
                SubjectID = 7,
                Score = 75
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 312,
                StudentID = 23,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 7,
                Score = 79
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 313,
                StudentID = 24,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 7,
                Score = 76
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 314,
                StudentID = 25,
                ControlTypeID = 2,
                Semester = 2,
                SubjectID = 7,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 315,
                StudentID = 1,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 316,
                StudentID = 2,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 98
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 317,
                StudentID = 3,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 318,
                StudentID = 4,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 100
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 319,
                StudentID = 5,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 93
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 320,
                StudentID = 6,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 96
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 321,
                StudentID = 7,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 95
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 322,
                StudentID = 8,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 85
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 323,
                StudentID = 9,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 90
            });

            modelBuilder.Entity<Mark>().HasData(new Mark
            {
                Id = 324,
                StudentID = 10,
                ControlTypeID = 3,
                Semester = 1,
                SubjectID = 9,
                Score = 90
            });
        }
    }
}
