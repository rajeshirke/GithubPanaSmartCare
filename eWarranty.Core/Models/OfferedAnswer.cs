using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class OfferedAnswer
    {
        public OfferedAnswer()
        {
            SurveyQuestionAnswers = new HashSet<SurveyQuestionAnswer>();
        }

        public int OfferedAnswerId { get; set; }
        public string AnswerText { get; set; }

        public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
    }
}
