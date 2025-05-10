using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class SurveyAnswer
    {
        public SurveyAnswer()
        {
            SurveyQuestionAnswers = new HashSet<SurveyQuestionAnswer>();
        }

        public long SurveyAnswerId { get; set; }
        public long SurveyQuestionId { get; set; }
        public string Answer { get; set; }

        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
    }
}
