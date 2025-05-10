using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.DataServices;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Core.ServiceLayer
{
    public class FollowUpManagementSL
    {
        public async Task<List<FollowUp>> GetFollowupsByServiceRequest(long ServiceRequestID)
        {
            return await WebServiceUtils<List<FollowUp>>.GetData(ServiceEndPoints.GetFollowupsByServiceRequest+ServiceRequestID);
        }
        public async Task<ReceiveContext<FollowUp>> PostFollowUps(FollowUp followUp)
        {
            return await WebServiceUtils<ReceiveContext<FollowUp>>.PostData(ServiceEndPoints.PostFollowUps, followUp);
        }

        //public async Task<SurveyResponse> GetAllActiveSurveys()
        //{
        //    return await WebServiceUtils<SurveyResponse>.GetData(ServiceEndPoints.GetAllActiveSurveys);
        //}
        public async Task<List<SurveyResponse>> GetAllActiveSurveys()
        {
            return await WebServiceUtils<List<SurveyResponse>>.GetData(ServiceEndPoints.GetAllActiveSurveys);
        }
        public async Task<bool> PostCustomerSurvey(List<CustomerSurveyRequest> customerSurveys)
        {
            return await WebServiceUtils<bool>.PostData(ServiceEndPoints.PostCustomerSurvey, customerSurveys);
        }
        public async Task<List<CustomerSurveyResponse>> GetCustomerSurveyByPersonId(long PersonId)
        {
            return await WebServiceUtils<List<CustomerSurveyResponse>>.GetData(ServiceEndPoints.GetCustomerSurveyByPersonId + PersonId);
        }
        public async Task<List<FeedbackQuestion>> GetQuestionsAnswersByRequestTypeId(long ServiceRequestTypeId)
        {
            return await WebServiceUtils<List<FeedbackQuestion>>.GetData(ServiceEndPoints.GetQuestionsAnswersByRequestTypeId+ ServiceRequestTypeId);
        }
        public async Task<bool> PostCustomerFeedback(CustomerFeedbackRequest customerFeedback)
        {
            return await WebServiceUtils<bool>.PostData(ServiceEndPoints.PostCustomerFeedback, customerFeedback);
        }

        public async Task<List<ChatbotEnquiryResponse>> GetChatInqueriesByCustomer(long PersonId)
        {
            return await WebServiceUtils<List<ChatbotEnquiryResponse>>.GetData(ServiceEndPoints.GetChatInqueriesByCustomer+PersonId);
        }
        ////api/CustomerFeedback/PostCustomerFeedback
    }
}
