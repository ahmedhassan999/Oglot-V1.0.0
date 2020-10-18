  using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 //[Authorize(Roles = "Admin,Employee")]
    public class LessonReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LessonReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subject/Lessons/5
        [HttpGet("lessons/{subjectid}")]
        public async Task<ActionResult> GetLessonReport(int subjectid)
        {
            var Subjid =await _context.Subject.FindAsync(subjectid);

            if (Subjid == null)
            {
                return NotFound();
            }
            
            var lessonReport =await
                (
                from lesson in _context.Lesson
              
                where lesson.SubjectId == subjectid
                select new
                {
                    id = lesson.Id,

                    subject = lesson.Subject.Name,
                    stage = lesson.Subject.Semester.Class.Stage.Name,
                    semester=lesson.Subject.Semester.Name,
                    lessonclass =lesson.Subject.Semester.Class.Name,

                    lessonname = lesson.Name,
                    intro = lesson.Intro,
                    content = lesson.LessonContent,
                    notes = lesson.Notes,
                    learningvarity = lesson.LearningVarity,

                    objectives = lesson.Objective,
                 
                    strategy = lesson.Strategy,
                  
                    learningmethodology = lesson.LearningMethodology,

                    additionalsupport = lesson.AdditionalSupport,
                    url = lesson.Url,

                    evaluation = lesson.Evaluation,
                    //????????????????????????dynamic?????????????????????//
                    //target evaluation
                    evaluationQuestion = lesson.LessonQuestion.Where(x=>x.QuestionTargetId==1),

                    homework = lesson.HomeWork,
                    //????????????????????????dynamic?????????????????????//
                    //target homework
                    hwQuestion = lesson.LessonQuestion.Where(x => x.QuestionTargetId == 2),
                  
                    resource = lesson.Resource

                }).ToListAsync();

            var OrderedReport = lessonReport.OrderBy(x => x.id);
            if (lessonReport == null)
            {
                return NotFound();
            }

            return Ok(lessonReport);
        }
    }
}
