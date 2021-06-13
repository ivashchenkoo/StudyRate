using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;
using StudyRate.Domain;
using System.Diagnostics;

namespace StudyRate.Service
{
    public class GSheets
    {
        private readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private readonly string ApplicationName = "Legislators";
        private SheetsService service;

        private readonly AppDBContext _context;

        public GSheets(AppDBContext context)
        {
            _context = context;
            ConnectToGSheets();
        }

        public List<Mark> ReadEntries(string tableID, string sheet, AcademicPlan academicPlan, int controlTypeID)
        {
            try
            {
                var range = $"{sheet}!A:B";
                var request = service.Spreadsheets.Values.Get(tableID, range);
                var response = request.Execute();
                var values = response.Values;

                if (values != null && values.Count > 0)
                {
                    var students = _context.Students.Where(x => x.GroupID == academicPlan.GroupID).ToList();
                    List<Mark> marks = new();
                    var controlType = _context.ControlTypes.FirstOrDefault(x => x.Id == controlTypeID);
                    var subject = _context.Subjects.FirstOrDefault(x => x.Id == academicPlan.SubjectID);

                    foreach (var row in values)
                    {
                        Mark mark = new()
                        {
                            ControlTypeID = controlTypeID,
                            ControlType = controlType,
                            Semester = academicPlan.Semester,
                            SubjectID = academicPlan.SubjectID,
                            Subject = subject,
                            Score = Convert.ToInt32(row[1].ToString())
                        };

                        foreach (var student in students)
                        {
                            if (row[0].ToString().Contains(student.LastName) && row[0].ToString().Contains(student.FirstName))
                            {
                                mark.StudentID = student.Id;
                                mark.Student = student;
                                break;
                            }
                        }

                        marks.Add(mark);
                    }

                    return marks;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        private bool ConnectToGSheets()
        {
            try
            {
                GoogleCredential credential;
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                }

                service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
