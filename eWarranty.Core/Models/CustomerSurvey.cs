using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CustomerSurvey
    {
        public CustomerSurvey()
        {
            SurveyQuestionAnswers = new HashSet<SurveyQuestionAnswer>();
        }

        public long CustomerSurveyId { get; set; }
        public long SurveyId { get; set; }
        public long? AttendedByPersonId { get; set; }
        public DateTime? AttendedOn { get; set; }
        public string Message { get; set; }

        public virtual Person AttendedByPerson { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswers { get; set; }
    }
}
