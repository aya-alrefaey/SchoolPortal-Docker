using grade_mvc.contexts;
using grade_mvc.Models;
using grade_mvc.services;
using grade_mvc.Viewmodels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace grade_mvc.Controllers
{
    public class GradeController : Controller
    {
        private readonly GradeDbContext _context;
        private readonly StudentsServiceClient _studentsClient;

        public GradeController(GradeDbContext context, StudentsServiceClient studentsClient)
        {
            _context = context;
            _studentsClient = studentsClient;
        }

        public async Task<IActionResult> Index()
        {
            var grades = await _context.Grades.ToListAsync();

            var result = new List<IndexViewModel>();
            
            var students = await _studentsClient.GetAllStudents();

            if (!students.Any())
            {
                ViewBag.ErrorMessage =
                    "Student service is unavailable. No students Info can be loaded.";
            }

            foreach (var grade in grades)
                {

                    var student = students?.FirstOrDefault(s => s.Id == grade.StudentId);

                    result.Add(new IndexViewModel
                    {
                        StudentId = grade.StudentId,
                        CourseName = grade.CourseName,
                        Score = grade.Score,
                        GradeId = grade.Id,
                        StudentName = student != null ? $"{student.FirstName} {student.LastName}" : "Name not available"

                    });
                }
           
           
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            if (grade == null)
            {
                return NotFound();
            }
            var student = await _studentsClient.GetStudentById(grade.StudentId);
            if (student == null)
            {
                ViewBag.ErrorMessage =
                    "Student service is unavailable. No student Info can be loaded.";
            }

            return View(new GradeViewModel
            {
                Id = grade.StudentId,
                CourseName = grade.CourseName,
                Score = grade.Score,
                GradeId = grade.Id,
                Notes = grade.Notes,
                GradeDate = grade.GradeDate,
                FirstName = student != null ? student.FirstName : " Name not available",
                LastName = student != null ? student.LastName : "",
                Gender = student?.Gender,
                DateOfBirth = student?.DateOfBirth,
                Email = student != null ? student.Email : "Not Available",
                EnrollmentDate = student?.EnrollmentDate,
                Phone = student != null ? student.Phone : "Not Available"

            });       
       
        }

        public async Task<IActionResult> Create()
        {
            var students = await _studentsClient.GetAllStudents();

            if (!students.Any())
            {
                ViewBag.ErrorMessage =
                    "Student service is unavailable. No students can be loaded.";
            }

            var studentList = students?.Select(s => new studentInfo{
                Id = s.Id,
                Name = $"{s.Id} - {s.FirstName} {s.LastName}"
            }).ToList();

            return View(new CreateViewmodel
            {
                Grade = new Grade { GradeDate = DateTime.Now },
                Students = studentList
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewmodel model)
        {
            
            if (ModelState.IsValid)
            {
                _context.Grades.Add(model.Grade);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

           
            var students = await _studentsClient.GetAllStudents();
           
            model.Students = students.Select(s => new studentInfo
            {
                Id = s.Id,
                Name = $"{s.Id} - {s.FirstName} {s.LastName}"
            }).ToList();


            return View(model);
        }


        //public async Task<IActionResult> Delete(int id)
        //{
        //    var grade = await _context.Grades
        //        .FirstOrDefaultAsync(s => s.Id == id);

        //    if (grade == null)
        //        return NotFound();

        //    return View("Details", grade);
        //}

        [HttpPost]

        public async Task<IActionResult> Deleteitem(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null)
                return NotFound();

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

           
            var students = await _studentsClient.GetAllStudents();
            if (!students.Any())
            {
                ViewBag.ErrorMessage =
                    "Student service is unavailable. No student Info can be loaded, You can't edit now";
            }

            var studentsInfo = students?.Select(s => new studentInfo
            {
                Id = s.Id,
                Name = $"{s.Id} - {s.FirstName} {s.LastName}" 
            }).ToList();

          
            var gradedata = new CreateViewmodel
            {
                Grade = grade,
                Students = studentsInfo
            };

            return View(gradedata);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateViewmodel model)
        {
            if (ModelState.IsValid)
            {
                _context.Grades.Update(model.Grade);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var studentsFromService = await _studentsClient.GetAllStudents();
            model.Students = studentsFromService?.Select(s => new studentInfo
            {
                Id = s.Id,
                Name = $"{s.Id} - {s.FirstName} {s.LastName}"
            }).ToList();

            return View(model);
        }

    }
}
