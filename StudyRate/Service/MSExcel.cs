using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using StudyRate.Domain.Entities;
using StudyRate.Domain;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace StudyRate.Service
{
    public class MSExcel
    {
        private readonly AppDBContext _context;

        public MSExcel(AppDBContext context) => _context = context;

        public List<Mark> GetMarks(IFormFile uploadedFile, AcademicPlan academicPlan, int controlTypeID)
        {
            try
            {
                using (XLWorkbook workBook = new XLWorkbook(uploadedFile.OpenReadStream(), XLEventTracking.Disabled))
                {
                    var students = _context.Students.Where(x => x.GroupID == academicPlan.GroupID).ToList();
                    List<Mark> marks = new();
                    var controlType = _context.ControlTypes.FirstOrDefault(x => x.Id == controlTypeID);
                    var subject = _context.Subjects.FirstOrDefault(x => x.Id == academicPlan.SubjectID);

                    foreach (IXLWorksheet worksheet in workBook.Worksheets)
                    {
                        foreach (IXLColumn column in worksheet.ColumnsUsed().Skip(1))
                        {
                            foreach (IXLRow row in worksheet.RowsUsed())
                            {
                                Mark mark = new()
                                {
                                    ControlTypeID = controlTypeID,
                                    ControlType = controlType,
                                    Semester = academicPlan.Semester,
                                    SubjectID = academicPlan.SubjectID,
                                    Subject = subject,
                                    Score = Convert.ToInt32(row.Cell(column.ColumnNumber()).Value.ToString())
                                };

                                foreach (var student in students)
                                {
                                    if (row.Cell(1).Value.ToString().Contains(student.LastName) && row.Cell(1).Value.ToString().Contains(student.FirstName))
                                    {
                                        mark.StudentID = student.Id;
                                        mark.Student = student;
                                        break;
                                    }
                                }

                                marks.Add(mark);
                            }
                        }
                    }

                    return marks;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
