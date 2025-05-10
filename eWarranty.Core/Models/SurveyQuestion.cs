using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            SurveyAnswers = new HashSet<SurveyAnswer>();
            SurveyQuestionAnswers = new HashSet<SurveyQuestionAnswer>();
        }

        public long SurveyQuestionId { get; set; }
        public long SurveyId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; }
        public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
    }
}
