using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.DataServices;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Core.ServiceLayer
{
    public class ServiceCentersManagementSL
    {
        public async Task<List<ServiceCenter>> GetServiceCentersNearestToLocation(int CountryId,double latitude,double longitude)
        {
            return await WebServiceUtils<List<ServiceCenter>>.GetData(string.Format(ServiceEndPoints.GetServiceCentersNearestToLocation, CountryId, latitude, longitude));
        }

        //new
        public async Task<List<ServiceCenter>> GetServiceCentersNearestToLocationByProductCategoryId(int CountryId, double latitude, double longitude, long productCategoryId)
        {
            return await WebServiceUtils<List<ServiceCenter>>.GetData(string.Format(ServiceEndPoints.GetServiceCentersNearestToLocationByProductCategoryId, CountryId, latitude, longitude, productCategoryId));
        }


        public async Task<List<ServiceCenter>> GetServiceCentersByProductAndNearestLocation(int CountryId,int ProductClassificationId, double latitude, double longitude)
        {
            return await WebServiceUtils<List<ServiceCenter>>.GetData(string.Format(ServiceEndPoints.GetServiceCentersByProductAndNearestLocation, CountryId, ProductClassificationId, latitude, longitude));
        }
        public async Task<List<ServiceManualModelResponse>> GetAllModels()
        {
            return await WebServiceUtils<List<ServiceManualModelResponse>>.GetData(ServiceEndPoints.GetAllModels);
        }
        public async Task<List<string>> GetModelNumbersForRepairTips()
        {
            return await WebServiceUtils<List<string>>.GetData(ServiceEndPoints.GetModelNumbersForRepairTips);
        }
        public async Task<List<TechPortalDbrepairTipsView>> GetTechPortalRepairTipsByModelNumber(string modelnumber,string Symptom)
        {
            return await WebServiceUtils<List<TechPortalDbrepairTipsView>>.GetData(string.Format(ServiceEndPoints.GetTechPortalRepairTipsByModelNumber, modelnumber, Symptom));
        }
        public async Task<List<FileContentResponse>> GetModelRepairTipsDocumentsById(int RepairTipsId)
        {
            return await WebServiceUtils<List<FileContentResponse>>.GetData(ServiceEndPoints.GetModelRepairTipsDocumentsById+ RepairTipsId);
        }
        //TechPortalDbrepairTipsView
        public async Task<List<ServiceManualModelResponse>> GetModelServiceManualById(int id)
        {
            return await WebServiceUtils<List<ServiceManualModelResponse>>.GetData(ServiceEndPoints.GetModelServiceManualById+id);
        }
        public async Task<List<ModelServiceManualResponse>> GetServiceManualsByModelNumber(string id)
        {
            return await WebServiceUtils<List<ModelServiceManualResponse>>.GetData(ServiceEndPoints.GetServiceManualsByModelNumber + id);
        }

    }
}
