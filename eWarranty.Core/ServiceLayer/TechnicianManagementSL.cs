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
    public class TechnicianManagementSL
    {
        public async Task<List<ServiceRequest>> GetServiceRequestsAssignedToTechnician(long technicianId)
        {
            return await WebServiceUtils<List<ServiceRequest>>.GetData(ServiceEndPoints.GetServiceRequestsAssignedToTechnician+ technicianId);
        }
        public async Task<List<ServiceRequestResponce>> GetServiceRequestsOfTechnician(TechGetServiceRequests techGetServiceRequests)
        {
            return await WebServiceUtils<List<ServiceRequestResponce>>.PostData(ServiceEndPoints.GetServiceRequestsOfTechnician, techGetServiceRequests);
        }
        public async Task<List<ServiceRequestResponce>> GetServiceRequestsByDashboardStatus(TechnicianSrRequest techGetServiceRequests)
        {
            return await WebServiceUtils<List<ServiceRequestResponce>>.PostData(ServiceEndPoints.GetServiceRequestsByDashboardStatus, techGetServiceRequests);
        }
        
        public async Task<ServiceRequest> GetTechnicianServiceRequestDetails(long serviceRequestId)
        {
            return await WebServiceUtils<ServiceRequest>.GetData(ServiceEndPoints.GetTechnicianServiceRequestDetails+serviceRequestId);
        }
        public async Task<ReceiveContext<UpdateSRResponse>> UpdateServiceRequests(long serviceRequestId, ServiceRequestUpdateforTech serviceRequest)
        {
            return await WebServiceUtils<ReceiveContext<UpdateSRResponse>>.PutData(ServiceEndPoints.UpdateServiceRequests + serviceRequestId, serviceRequest);
        }
        public async Task<List<PartStockMaster>>GetTechnicianStock(long technicianId)
        {
            return await WebServiceUtils<List<PartStockMaster>>.GetData(ServiceEndPoints.GetTechnicianStock + technicianId);
        }
            //new
        public async Task<List<PartStockMaster>> GetTechnicianStockWithModelNumber(long technicianId,string Modelno="")
        {
            return await WebServiceUtils<List<PartStockMaster>>.GetData(string.Format(ServiceEndPoints.GetTechnicianStockWithModelNumber,technicianId, Modelno));
        }
           //new
        public async Task<List<PartStockMaster>> GetServiceCenterStockWithModelNumber(long technicianId, string Modelno)
        {
            return await WebServiceUtils<List<PartStockMaster>>.GetData(string.Format(ServiceEndPoints.GetServiceCenterStockWithModelNumber, technicianId, Modelno));
        }

        public async Task<List<PartStockMaster>> GetServiceCenterStock(long serviceCenterId)
        {
            return await WebServiceUtils<List<PartStockMaster>>.GetData(ServiceEndPoints.GetServiceCenterStock + serviceCenterId);
        }
        public async Task<List<ServiceChargeMaster>> GetServiceChargeMasterForCostEstimation(long ServiceRequestTypeID, int CountryID, int ServiceCenterID,int ProductClassificationId,long ServiceRequestId)
        {
            return await WebServiceUtils<List<ServiceChargeMaster>>.GetData(string.Format(ServiceEndPoints.GetServiceChargeMasterForCostEstimation, ServiceRequestTypeID, CountryID, ServiceCenterID, ProductClassificationId, ServiceRequestId));
        }

        //cost estimation details for Customer
        public async Task<List<ServiceChargeMasterResponse>> GetServiceChargeMasterForCostEstimationCustomer(long ServiceRequestTypeID, int CountryID, int ServiceCenterID, int ProductClassificationId, long ServiceRequestId)
        {
            return await WebServiceUtils<List<ServiceChargeMasterResponse>>.GetData(string.Format(ServiceEndPoints.GetServiceChargeMasterForCostEstimationCustomer, ServiceRequestTypeID, CountryID, ServiceCenterID, ProductClassificationId, ServiceRequestId));
        }

        public async Task<ReceiveContext<ResponseWithID>> CreateServiceCostEstimations(CreateCostEstimationPartCharges costEstimationPartCharges)
        {
            return await WebServiceUtils<ReceiveContext<ResponseWithID>>.PostData(ServiceEndPoints.CreateServiceCostEstimations, costEstimationPartCharges);
        }
        public async Task<ReceiveContext<ResponseWithID>> CreateServiceCostEstimations(ServiceCostEstimationRequest costEstimationPartCharges)
        {
            return await WebServiceUtils<ReceiveContext<ResponseWithID>>.PostData(ServiceEndPoints.CreateServiceCostEstimations, costEstimationPartCharges);
        }
        public async Task<List<PromoCode>> GetPromoCodeForCustomerProductmodel(int CountryId, int ProductCategoryId)
        {
            return await WebServiceUtils<List<PromoCode>>.GetData(string.Format(ServiceEndPoints.GetPromoCodeForCustomerProductmodel, CountryId, ProductCategoryId));
        }
        public async Task<ReceiveContext<APIResponse>> AddPartRequests(PartRequest partRequest)
        {
            return await WebServiceUtils<ReceiveContext<APIResponse>>.PostData(ServiceEndPoints.AddPartRequests, partRequest);
        }
        public async Task<ReceiveContext<ResponseWithID>> SRCreateInvoice(CreateInvoiceRequest createInvoiceRequest)
        {
            return await WebServiceUtils<ReceiveContext<ResponseWithID>>.PostData(ServiceEndPoints.CreateInvoice, createInvoiceRequest);
        }
        public async Task<ServiceRequestDetailsResponse> GetServiceRequestImprovedAllDetails(long serviceRequestId)
        {
            return await WebServiceUtils<ServiceRequestDetailsResponse>.GetData(ServiceEndPoints.GetServiceRequestImprovedAllDetails + serviceRequestId);
        }
        public async Task<TechnicianJobCounts> GetTechnicianJobsCounts(long technicianId)
        {
            return await WebServiceUtils<TechnicianJobCounts>.GetData(ServiceEndPoints.GetTechnicianJobsCounts + technicianId);
        }
        public async Task<List<string>> GenerateModelRepairTipsDocumentLinksByRepairTipsId(int RepairTipsId)
        {
            return await WebServiceUtils<List<string>>.GetData(ServiceEndPoints.GenerateModelRepairTipsDocumentLinksByRepairTipsId+RepairTipsId);
        }

        public async Task<APIResponse> TechPostChat(ChatRequest chatRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.TechPostChat, chatRequest);
        }
        public async Task<List<ChatResponse>> GetTechChatsByFromPersonId(long technicianId)
        {
            return await WebServiceUtils<List<ChatResponse>>.GetData(ServiceEndPoints.GetTechChatsByFromPersonId + technicianId);
        }

        public async Task<List<TechnicianQueryResponse>> GetTechnicianQueriesWithSolutions(long technicianid)
        {
            var result1 = await WebServiceUtils<List<TechnicianQueryResponse>>.GetData(string.Format(ServiceEndPoints.GetTechnicianQueriesWithSolution, technicianid));
            return result1;
        }

        //save technician query
        public async Task<APIResponse> PostTechnicianFAQ(TechnicianQueryRequest technicianFAQ)
        {
            var abc = await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.SaveTechnicianQuery, technicianFAQ);
            return abc;
        }

        //search technician query
        public async Task<List<TechnicianQueryResponse>> GetTechnicianQueries(string modelnumber, string searchtext)
        {
            var result = await WebServiceUtils<List<TechnicianQueryResponse>>.GetData(string.Format(ServiceEndPoints.SearchTechnicianQueries, modelnumber, searchtext));
            return result;
        }

        //GetTechnicianAssignedOrderRequests
        public async Task<List<AccessoryOrderDetailResponse>> GetTechnicianOrderRequests(long technicianid)
        {
            return await WebServiceUtils<List<AccessoryOrderDetailResponse>>.GetData(string.Format(ServiceEndPoints.GetTechnicianAssignedOrderRequests, technicianid));
        }

        //send satnd by request
        public async Task<APIResponse> CreateStandBySetRequest(StandBySetRequestRequest standBySetRequestRequest)
        {
            var abc = await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.CreateStandBySetRequest, standBySetRequestRequest);
            return abc;
        }

        //PromoCode
        //string.Format(ServiceEndPoints.GetServiceCentersNearestToLocation, CountryId, latitude, longitude)


        //Search Part Number by initials
        public async Task<List<string>> GetPrismPartsByModelNumberByInitials(string PartNumber)
        {
            return await WebServiceUtils<List<string>>.GetData(string.Format(ServiceEndPoints.GetPrismPartsByModelNumberByInitials, PartNumber));
        }

        //model wise part nos
        public async Task<List<string>> GetPrismPartsByModelNumber(string ModelNo)
        {
            return await WebServiceUtils<List<string>>.GetData(string.Format(ServiceEndPoints.GetPrismPartsByModelNumber, ModelNo));
        }

        //Technician spare parts list
        public async Task<List<PartRequestView>> GetPartRequestsByTechnician(int PersonId)
        {
            return await WebServiceUtils<List<PartRequestView>>.GetData(string.Format(ServiceEndPoints.GetPartRequestsByTechnician, PersonId));
        }

        public async Task<List<PartRequestView>> GetPartRequestsByServiceCenterAndStatus(int ServiceCenterId,int DashboardStatus=1)
        {
            return await WebServiceUtils<List<PartRequestView>>.GetData(string.Format(ServiceEndPoints.GetPartRequestsByServiceCenterAndStatus, ServiceCenterId, DashboardStatus));
        }

        public async Task<PartRequestView> GetPartRequestByPartRequestId(int PartRequestId, int ServiceCenterId, int DashboardStatus = 1)
        {
            return await WebServiceUtils<PartRequestView>.GetData(string.Format(ServiceEndPoints.GetPartRequestByPartRequestId, PartRequestId,ServiceCenterId, DashboardStatus));
        }

        public async Task<APIResponse> UpdatePartRequest(int PartRequestId, PartRequestRequest partRequestRequest)
        {
            return await WebServiceUtils<APIResponse>.PutData(string.Format(ServiceEndPoints.UpdatePartRequest, PartRequestId), partRequestRequest);
        }

        public async Task<List<GetTechnicianWithAvailableTimeSlot>> GetTechnicianWithLimitedDatas(TechnicianWithLimitedDataRequest technicianWithLimitedDataRequest)
        {
            return await WebServiceUtils<List<GetTechnicianWithAvailableTimeSlot>>.PostData(ServiceEndPoints.GetTechnicianWithLimitedDatas, technicianWithLimitedDataRequest);
        }


        public async Task<APIResponse> SaveAssignedTechnicianJob(ServiceRequestCreateRequest serviceRequestCreateRequest)
        {
            return await WebServiceUtils<APIResponse>.PutData(string.Format(ServiceEndPoints.SaveAssignedTechnicianJob, serviceRequestCreateRequest.ServiceRequestId), serviceRequestCreateRequest);
        }
    }
}
