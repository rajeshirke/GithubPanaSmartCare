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
    public class AmcRequestManagementSL
    {
        public async Task<PrismCountryMasterView> GetCountryMaster()
        {
            return await WebServiceUtils<PrismCountryMasterView>.GetData(ServiceEndPoints.GetCountryMaster);
        }
        public async Task<List<AmcRequestMasterResponse>> GetAmcMasterByProductCategory(long ServiceCenterId, int ProductCategoryId, int ACMTypeId)
        {
            return await WebServiceUtils<List<AmcRequestMasterResponse>>.GetData(string.Format(ServiceEndPoints.GetAmcMasterByProductCategory,ServiceCenterId, ProductCategoryId, ACMTypeId));
        }
        public async Task<APIResponse> AmcRequestCustomers(AmcRequestCustomerRequest amcRequestCustomerRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.AmcRequestCustomers, amcRequestCustomerRequest);
        }
        public async Task<List<AmcRequestCustomerLimitedResponse>> GetAmcRequestsByCustomer(long PersonId)
        {
            return await WebServiceUtils<List<AmcRequestCustomerLimitedResponse>>.GetData(string.Format(ServiceEndPoints.GetAmcRequestsByCustomer, PersonId));
        }


        //AMC Terms and Conditions
        public async Task<string> GetAmcTermsByServicecenter(long ServiceCenterId)
        {
            return await WebServiceUtils<string>.GetData(string.Format(ServiceEndPoints.GetAmcTermsByServicecenter, ServiceCenterId));
        }

        public async Task<List<RequestResponse>> GetAMCRequests(int PersonRoleId,int ServiceCenterId)
        {
            return await WebServiceUtils<List<RequestResponse>>.GetData(string.Format(ServiceEndPoints.GetAMCRequests, PersonRoleId, ServiceCenterId));
        }

        public async Task<APIResponse> ApproveAMCReq(AmcRequestCustomerRequest amcRequestCustomerRequest)
        {
            return await WebServiceUtils<APIResponse>.PutData(ServiceEndPoints.ApproveAMC + amcRequestCustomerRequest.RequestId, amcRequestCustomerRequest);
        }

    }
}
