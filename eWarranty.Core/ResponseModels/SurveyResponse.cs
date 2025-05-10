using System;
using System.Collections.Generic;
using eWarranty.Core.Models;

namespace eWarranty.Core.ResponseModels
{
    public class SurveyResponse
    {
        public long SurveyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedByPersonId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedByPersonName { get; set; }
        public virtual ICollection<SurveyQuestionResponse> SurveyQuestions { get; set; }
    }
}
