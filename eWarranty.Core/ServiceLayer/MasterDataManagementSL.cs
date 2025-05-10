using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.DataServices;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Core.ServiceLayer
{
    public class MasterDataManagementSL
    {
        public async Task<List<PrismProductCategoryView>> GetProductCategory()
        {//PrismProductCategoryView
            return await WebServiceUtils<List<PrismProductCategoryView>>.GetData(ServiceEndPoints.GetProductCategory);
        }
        public async Task<PrismCountryMasterView> GetCountryMaster()
        {
            return await WebServiceUtils<PrismCountryMasterView>.GetData(ServiceEndPoints.GetCountryMaster);
        }
        public async Task<CountryResponse> GetCountryDetailsByCode(string CountryCode)
        {
            return await WebServiceUtils<CountryResponse>.GetData(ServiceEndPoints.GetCountryDetailsByCode+CountryCode);
        }
        public async Task<List<CountryResponse>> GetCountryDetailsByCodeLimited(string CountryCode)
        {
            return await WebServiceUtils<List<CountryResponse>>.GetData(ServiceEndPoints.GetCountryDetailsByCodeLimited);
        }
        public async Task<List<CountryResponse>> GetActiveCountryList()
        {
            return await WebServiceUtils<List<CountryResponse>>.GetData(ServiceEndPoints.GetActiveCountryList);
        }

        public async Task<List<EntityKeyValueResponse>> GetCitiesByCountryId(long CountryId)
        {
            return await WebServiceUtils<List<EntityKeyValueResponse>>.GetData(string.Format(ServiceEndPoints.GetCitiesByCountryId, CountryId));
        }

        public async Task<List<EntityKeyValueResponse>> GetAreaByCityId(long CityId)
        {
            return await WebServiceUtils<List<EntityKeyValueResponse>>.GetData(string.Format(ServiceEndPoints.GetAreaByCityId, CityId));
        }
        public async Task<List<CountryResponse>> GetAllCountries()
        {
            return await WebServiceUtils<List<CountryResponse>>.GetData(ServiceEndPoints.GetAllCountries);
        }
        public async Task<List<ServiceRequestTypesResponse>> GetServiceRequestTypes()
        {
            return await WebServiceUtils<List<ServiceRequestTypesResponse>>.GetData(ServiceEndPoints.GetServiceRequestTypes);
        }
        public async Task<List<ModelNumberSearchResponse>> SearchModelNumberByInitials(string ModelNumberinitials,int productClassificationId)
        {
            return await WebServiceUtils<List<ModelNumberSearchResponse>>.GetData(ServiceEndPoints.SearchModelNumberByInitials+ModelNumberinitials);
        }
        public async Task<List<SerialNoSerchResponse>> SearchSerialNumberByInitials(string SerialNumberinitials, string ModelNumber)
        {
            return await WebServiceUtils<List<SerialNoSerchResponse>>.GetData(string.Format(ServiceEndPoints.SearchSerialNumberByInitials, SerialNumberinitials, ModelNumber));
        }
        public async Task<bool> ValidateSerialNumber(string SerialNumber)
        {
            return await WebServiceUtils<bool>.GetData(ServiceEndPoints.ValidateSerialNumber+ SerialNumber);
        }
        //string.Format(ServiceEndPoints.GetServiceCentersNearestToLocation, CountryId, latitude, longitude)

        //All Model Nos
        public async Task<List<ModelNumberSearchResponse>> SearchAllModelNumber()
        {
            return await WebServiceUtils<List<ModelNumberSearchResponse>>.GetData(ServiceEndPoints.SearchAllModelNumbers);
        }

    }
}
