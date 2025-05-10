using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.DataServices;
using eWarranty.Core.Enums;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Core.ServiceLayer
{
    public class ProductsManagementSL
    {
        public async Task<ReceiveContext<ProductModel>> AddCustomerProduct(ProductRequest productRequest)
        {
            return await WebServiceUtils<ReceiveContext<ProductModel>>.PostData(ServiceEndPoints.AddCustomerProduct, productRequest);
        }
        public async Task<List<ProductModelWarrantyResponse>> GetCustomerProductsWithWarranty(long PurchaseCountryID, long CustomerId)
        {
            return await WebServiceUtils<List<ProductModelWarrantyResponse>>.GetData(string.Format(ServiceEndPoints.GetCustomerProductsWithWarranty,  CustomerId));
        }

        //for technician login
        public async Task<List<ProductModelWarrantyResponse>> GetCustomerDeliveryItems()
        {
            var result= await WebServiceUtils<List<ProductModelWarrantyResponse>>.GetData(string.Format(ServiceEndPoints.GetCustomerDeliveryItems));
            return result;
        }

        public async Task<List<ProductModelWarrantyResponse>> GetCustomerProducts(long CustomerId)
        {
            return await WebServiceUtils<List<ProductModelWarrantyResponse>>.GetData(ServiceEndPoints.GetCustomerProducts+ CustomerId);
        }

        public async Task<APIResponse> ServiceRequestCheck(long SelectedProductModelId)
        {
            return await WebServiceUtils<APIResponse>.GetData(ServiceEndPoints.ServiceRequestCheck + SelectedProductModelId);
        }
        public async Task<string> ProductFileUplod(string productRequest)
        {
            return await WebServiceUtils<string>.PostData(ServiceEndPoints.FileUplod, productRequest);
        }
        //public async Task<ReceiveContext<ResponseWithID>> DeleteCustomerProduct(long pid)
        //{
        //    return await WebServiceUtils<ReceiveContext<ResponseWithID>>.PostData(ServiceEndPoints.DeleteCustomerProduct+ pid,null);
        //}

        public async Task<APIResponse> DeleteCustomerProduct(long pid)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.DeleteCustomerProduct + pid, null);
        }

        public async Task<ProductModelResponse> GetCustomerProductModelByModelId(long pid)
        {
            return await WebServiceUtils<ProductModelResponse>.GetData(ServiceEndPoints.GetCustomerProductModelByModelId + pid);
        }
        //public async Task<APIResponse> GetIsServiceRequestRaiseAllowedForProduct(long ProductModelId)
        //{
        //    return await WebServiceUtils<APIResponse>.GetData(ServiceEndPoints.IsServiceRequestRaiseAllowedForProduct, ProductModelId);
        //}

        public async Task<APIResponse> GetIsServiceRequestRaiseAllowedForProduct(long ProductModelId)
        {
            var result1 = await WebServiceUtils<APIResponse>.GetData(string.Format(ServiceEndPoints.IsServiceRequestRaiseAllowedForProduct, ProductModelId));
            return result1;
        }

        public async Task<List<PrismModelMasterSearchView>> SearchModelNumberByModelNo(string ModelNo)
        {
            var result1 = await WebServiceUtils<List<PrismModelMasterSearchView>>.GetData(string.Format(ServiceEndPoints.SearchModelNumberByModelNo, ModelNo));
            return result1;
        }


        public async Task<string> GetWarrantyTC(int warrantytypeid)
        {
            return await WebServiceUtils<string>.GetData(string.Format(ServiceEndPoints.GetWarrantyTC, warrantytypeid));
        }

        ////api/PartRequests
    }
}
