using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Survey
    {
        public Survey()
        {
            CustomerSurveys = new HashSet<CustomerSurvey>();
            SurveyQuestions = new HashSet<SurveyQuestion>();
        }

        public long SurveyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedByPersonId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Person CreatedByPerson { get; set; }
        public virtual ICollection<CustomerSurvey> CustomerSurveys { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
