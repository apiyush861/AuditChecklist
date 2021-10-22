using AuditChecklistMicroservice.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistMicroservice.ServiceLayer
{
    public class GetQuestionsList
    {
        public virtual List<string> Questions(string AuditType)
        {
            ChecklistRepo repo = new ChecklistRepo();
            return repo.GetQuestionList(AuditType);
        }
        
    }
}
