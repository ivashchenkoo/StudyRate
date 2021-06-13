using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Repositories.Abstract;

namespace StudyRate.Domain
{
    public class DataManager
    {
        public IFacultyRepository Faculties { get; set; }
        public IDepartmentRepository Departments { get; set; }
        public IProfessorRepository Professors { get; set; }
        public ISpecialtyRepository Specialties { get; set; }
        public IGroupRepository Groups { get; set; }
        public IStudentRepository Students { get; set; }
        public ISubjectRepository Subjects { get; set; }
        public IAcademicPlanRepository AcademicPlans { get; set; }
        public IControlTypeRepository ControlTypes { get; set; }
        public IMarkRepository Marks { get; set; }
        public IPositionRepository Positions { get; set; }

        public DataManager(IFacultyRepository facultyRepository, IDepartmentRepository departmentRepository, IProfessorRepository professorRepository,
            ISpecialtyRepository specialtyRepository, IGroupRepository groupRepository, IStudentRepository studentRepository,
            ISubjectRepository subjectRepository, IAcademicPlanRepository academicPlanRepository, IControlTypeRepository controlTypeRepository,
            IMarkRepository markRepository, IPositionRepository positionRepository)
        {
            Faculties = facultyRepository;
            Departments = departmentRepository;
            Professors = professorRepository;
            Specialties = specialtyRepository;
            Groups = groupRepository;
            Students = studentRepository;
            Subjects = subjectRepository;
            AcademicPlans = academicPlanRepository;
            ControlTypes = controlTypeRepository;
            Marks = markRepository;
            Positions = positionRepository;
        }
    }
}
