using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class CustomerSurveyResponse
    {
        public long CustomerSurveyId { get; set; }
        public long SurveyId { get; set; }
        public long? AttendedByPersonId { get; set; }
        public DateTime? AttendedOn { get; set; }
        public string Message { get; set; }
        public string AttendedByPersonName { get; set; }
        public virtual SurveyDetailResponse Survey { get; set; }
    }

    public class SurveyDetailResponse
    {
        public long SurveyId { get; set; }
        public string Description { get; set; }
        public ICollection<SurveyQuestionResponse> SurveyQuestions { get; set; }
    }
}
