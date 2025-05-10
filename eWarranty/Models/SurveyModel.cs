using System;
namespace eWarranty.Models
{
    public class SurveyModel
    {
        public int qId { get; set; }

        public string QName { get; set; }

        public int SurveyRating { get; set; }

        public long SurveyId { get; set; }

        public string Description { get; set; }

        public long SurveyQuestionId { get; set; }

        public string QuestionText { get; set; }

        public int QuestionTypeId { get; set; }

    }
}
