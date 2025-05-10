using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class SurveyQuestionResponse
    {
        public long SurveyQuestionId { get; set; }
        public long SurveyId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }
        public virtual ICollection<SurveyAnswerResponse> SurveyAnswers { get; set; }
        public virtual ICollection<SurveyQuestionAnswerResponse> SurveyQuestionAnswers { get; set; }
    }

    public class SurveyAnswerResponse
    {
        public long SurveyAnswerId { get; set; }
        public long SurveyQuestionId { get; set; }
        public string Answer { get; set; }
    }

    public class SurveyQuestionAnswerResponse
    {
        public long SurveyQuestionAnswerId { get; set; }
        public long? SurveyAnswerId { get; set; }
        public long SurveyQuestionId { get; set; }
        public int? SurveyRating { get; set; }
        public long? CustomerSurveyId { get; set; }
    }
}
