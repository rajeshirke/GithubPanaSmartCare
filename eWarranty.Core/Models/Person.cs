using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Person
    {
        public Person()
        {
           
            Addresses = new HashSet<Address>();
            AmcRequestCustomerApprovedByPersons = new HashSet<AmcRequestCustomer>();
            AmcRequestCustomerCustomers = new HashSet<AmcRequestCustomer>();
            CampaignMasters = new HashSet<CampaignMaster>();
            ChatbotEnquiryAssignedPersons = new HashSet<ChatbotEnquiry>();
            ChatbotEnquiryCustomerPersons = new HashSet<ChatbotEnquiry>();
            CustomerFeedbacks = new HashSet<CustomerFeedback>();
            CustomerSurveys = new HashSet<CustomerSurvey>();
            FollowUpFromPersons = new HashSet<FollowUp>();
            FollowUpToPersons = new HashSet<FollowUp>();
            InverseParentPerson = new HashSet<Person>();
            NotificationHistories = new HashSet<NotificationHistory>();
            PartRequestRequestedByTechnicians = new HashSet<PartRequest>();
            PartRequestUpdatedByPersons = new HashSet<PartRequest>();
            PartStockMasterEntryByPersons = new HashSet<PartStockMaster>();
            PartStockMasterTechnicianPersons = new HashSet<PartStockMaster>();
            PartStockTransactionsHistories = new HashSet<PartStockTransactionsHistory>();
            PersonCompanies = new HashSet<PersonCompany>();
            PersonServiceCenters = new HashSet<PersonServiceCenter>();
            ProductApprovalRequests = new HashSet<ProductApprovalRequest>();
            RequestCreatedByNavigations = new HashSet<Request>();
            RequestUpdatedByNavigations = new HashSet<Request>();
            ServiceRequestCustomerPersons = new HashSet<ServiceRequest>();
            ServiceRequestTechnicianPersons = new HashSet<ServiceRequest>();
            Surveys = new HashSet<Survey>();
            TechnicianProductCategories = new HashSet<TechnicianProductCategory>();
        }

        public long PersonId { get; set; }
        public Guid UserId { get; set; }
        public long? ParentPersonId { get; set; }
        public int CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PreferredLanguageId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public int? Salutation { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? PersonRoleId { get; set; }
        public int? PersonStatusId { get; set; }
        public bool? IsEmailValidated { get; set; }
        public bool? IsMobileValidated { get; set; }
        public bool? IsPasswordChanged { get; set; }
        public int? CompanyId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? ProfilePictureFileInfoId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        public virtual Person ParentPerson { get; set; }
        public virtual PersonRole PersonRole { get; set; }
        public virtual PersonStatu PersonStatus { get; set; }
        public virtual Language PreferredLanguage { get; set; }
        public virtual Salutation SalutationNavigation { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual FileInfo ProfilePictureFileInfo { get; set; }
        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomerApprovedByPersons { get; set; }
        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomerCustomers { get; set; }
        public virtual ICollection<CampaignMaster> CampaignMasters { get; set; }
        public virtual ICollection<ChatbotEnquiry> ChatbotEnquiryAssignedPersons { get; set; }
        public virtual ICollection<ChatbotEnquiry> ChatbotEnquiryCustomerPersons { get; set; }
        public virtual ICollection<CustomerFeedback> CustomerFeedbacks { get; set; }
        public virtual ICollection<CustomerSurvey> CustomerSurveys { get; set; }
        public virtual ICollection<FollowUp> FollowUpFromPersons { get; set; }
        public virtual ICollection<FollowUp> FollowUpToPersons { get; set; }
        public virtual ICollection<Person> InverseParentPerson { get; set; }
        public virtual ICollection<NotificationHistory> NotificationHistories { get; set; }
        public virtual ICollection<PartRequest> PartRequestRequestedByTechnicians { get; set; }
        public virtual ICollection<PartRequest> PartRequestUpdatedByPersons { get; set; }
        public virtual ICollection<PartStockMaster> PartStockMasterEntryByPersons { get; set; }
        public virtual ICollection<PartStockMaster> PartStockMasterTechnicianPersons { get; set; }
        public virtual ICollection<PartStockTransactionsHistory> PartStockTransactionsHistories { get; set; }
        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
        public virtual ICollection<PersonServiceCenter> PersonServiceCenters { get; set; }
        public virtual ICollection<ProductApprovalRequest> ProductApprovalRequests { get; set; }
        public virtual ICollection<Request> RequestCreatedByNavigations { get; set; }
        public virtual ICollection<Request> RequestUpdatedByNavigations { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequestCustomerPersons { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequestTechnicianPersons { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<TechnicianProductCategory> TechnicianProductCategories { get; set; }
    }
}
