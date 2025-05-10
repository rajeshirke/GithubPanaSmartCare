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
    public class ServiceRequestSL
    {
        //public async Task<ReceiveContext<string>> AddServiceRequests(ServiceRequest serviceRequest)
        //{
        //    return await WebServiceUtils<ReceiveContext<string>>.PostData(ServiceEndPoints.AddServiceRequests, serviceRequest);
        //}

        public async Task<APIResponse> AddServiceRequests(ServiceRequest serviceRequest)
        {
            var result= await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.AddServiceRequests, serviceRequest);
            return result;
        }

        public async Task<List<ServiceRequestResponce>> GetCustomerServiceRequests(long PersonId)
        {
            return await WebServiceUtils<List<ServiceRequestResponce>>.GetData(ServiceEndPoints.GetServiceRequestsByCustomer+ PersonId);
        }
        public async Task<ServiceRequest> GetServiceRequestDetails(long serviceRequestId)
        {
            return await WebServiceUtils<ServiceRequest>.GetData(ServiceEndPoints.GetServiceRequestDetails + serviceRequestId);
        }
        public async Task<ServiceRequestDetailsResponse> GetServiceRequestImprovedAllDetails(long serviceRequestId)
        {
            return await WebServiceUtils<ServiceRequestDetailsResponse>.GetData(ServiceEndPoints.GetServiceRequestImprovedAllDetails + serviceRequestId);
        }

        public async Task<ServiceRequestDetailsNewResponse> GetServiceRequestImprovedAllDetailsNew(long serviceRequestId)
        {
            return await WebServiceUtils<ServiceRequestDetailsNewResponse>.GetData(string.Format(ServiceEndPoints.GetServiceRequestImprovedAllDetailsNew, serviceRequestId));
        }
        //GetServiceRequestImprovedAllDetails
        public async Task<List<Root>> GetChatbotData(long id)
        {
            return await WebServiceUtils<List<Root>>.GetData(ServiceEndPoints.ChatBotRequest + id);
        }

        public async Task<ReceiveContext<string>> PostChatBotRequest(ChatBotRequest chatBotRequest)
        {
            return await WebServiceUtils<ReceiveContext<string>>.PostData(ServiceEndPoints.ChatBotPostRequest, chatBotRequest);
        }

        //new
        public async Task<List<Root>> GetByLanguage(long id,long LanguageID)
        {
            return await WebServiceUtils<List<Root>>.GetData(string.Format(ServiceEndPoints.GetByLanguage, id, LanguageID));
        }


        public async Task<ServiceCostEstimationCustomerResponse> GetServiceRequestCostEstimationForCustomer(long ServiceReqId)
        {
            return await WebServiceUtils<ServiceCostEstimationCustomerResponse>.GetData(string.Format(ServiceEndPoints.GetServiceRequestCostEstimationForCustomer, ServiceReqId));
        }


        public async Task<List<ServiceRequestResponceSupervisor>> GetServiceRequestsByServiceCenterSupervisor(int ServiceCenterId, int DashboardStatus = 1)
        {
            return await WebServiceUtils<List<ServiceRequestResponceSupervisor>>.GetData(string.Format(ServiceEndPoints.GetServiceRequestsByServiceCenterSupervisor, ServiceCenterId, DashboardStatus));
        }

        public async Task<ServiceRequestDetailsSupervisorResponse> GetServiceRequestWithoutInvoiceDetails(int SelectedServiceReqId)
        {
            return await WebServiceUtils<ServiceRequestDetailsSupervisorResponse>.GetData(string.Format(ServiceEndPoints.GetServiceRequestWithoutInvoiceDetails, SelectedServiceReqId));
        }

        public async Task<List<EntityKeyValueResponse>> GetServiceRequestStatus()
        {
            return await WebServiceUtils<List<EntityKeyValueResponse>>.GetData(string.Format(ServiceEndPoints.GetServiceRequestStatus));
        }

        public async Task<APIResponse> UpdateServiceRequest(ServiceCenterUpdateRequest serviceCenterUpdateRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.UpdateServiceRequest, serviceCenterUpdateRequest);
        }
    }
}
