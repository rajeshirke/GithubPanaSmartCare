using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class SurveyQuestionAnswer
    {
        public long SurveyQuestionAnswerId { get; set; }
        public long? SurveyAnswerId { get; set; }
        public long SurveyQuestionId { get; set; }
        public int? SurveyRating { get; set; }
        public long? CustomerSurveyId { get; set; }

        public virtual CustomerSurvey CustomerSurvey { get; set; }
        public virtual SurveyAnswer SurveyAnswer { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
