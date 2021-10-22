using AuditChecklistMicroservice.ServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {
        GetQuestionsList getQuestion = new GetQuestionsList(); 
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        [HttpGet("AuditCheckListQuestions")]
        [Authorize]
        public ActionResult<List<string>> Get(string auditType)
        {
            _log4net.Info("Get method of checklist microservice is invoked");

            List<string> QuestionList = getQuestion.Questions(auditType);

            if (QuestionList != null)
            {
                _log4net.Info("Question list for " + auditType + " is returned");
                return Ok(QuestionList);
            }
            else
            {
                _log4net.Info("Audit Type Mismatch!");
                return new BadRequestObjectResult("Audit Type Mismatch!");
            }

        }
    }
}
