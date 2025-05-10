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
    public class AddressesSL
    {
        public async Task<List<AddressResponse>> GetCustomerAddresses(long PersonId)
        {
            return await WebServiceUtils<List<AddressResponse>>.GetData(ServiceEndPoints.GetCustomerAddresses+ PersonId);
        }
        public async Task<ReceiveContext<ResponseWithID>> AddAddresses(AddressRequest address)
        {
            return await WebServiceUtils<ReceiveContext<ResponseWithID>>.PostData(ServiceEndPoints.AddAddresses , address);
        }
        public async Task<APIResponse> UpdateAddress(long AddressId, AddressRequest addressRequest)
        {
            return await WebServiceUtils<APIResponse>.PutData(ServiceEndPoints.UpdateAddress + AddressId, addressRequest);
        }
    }
}
