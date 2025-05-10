using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class CustomerSurveyRequest
    {
        public long SurveyId { get; set; }
        public long? AttendedByPersonId { get; set; }
        public DateTime? AttendedOn { get; set; }
        public string Message { get; set; }
        public List<SurveyQuestionAnswerRequest> SurveyQuestionAnswers { get; set; }
    }

    public class SurveyQuestionAnswerRequest
    {
        public long? SurveyAnswerId { get; set; }
        public long SurveyQuestionId { get; set; }
        public int? SurveyRating { get; set; }
    }
}
