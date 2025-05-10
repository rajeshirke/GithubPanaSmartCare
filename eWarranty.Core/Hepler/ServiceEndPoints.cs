using System;
namespace eWarranty.Core.Hepler
{
    public static class ServiceEndPoints
    {
        //public static Uri StagingServerUri => new Uri("http://devsrv01.panasonic.ae:82/api/");
        //public static Uri LiveServerUri => new Uri("https://prism.panasonic.ae/smartcareApi/api/");

        //public static string StagingServerImageUri => "http://devsrv01.panasonic.ae:83/Files/";
        //public static string LiveServerImageUri => "https://prism.panasonic.ae/SmartCare/Files/";

        //public static string StagingWebAppUri => "http://devsrv01.panasonic.ae:83/";
        //public static string LiveWebAppUri => "https://prism.panasonic.ae/SmartCare/";

        //public static string StagingPromotionUri => "https://prism.panasonic.ae/";
        //public static string LivePromotionUri => "https://prism.panasonic.ae/";


        //public static Uri ServerBaseUri { get { return LiveServerUri; } }

        //public static string ServerImageUri { get { return LiveServerImageUri; } }

        //public static string WebAppUri { get { return LiveWebAppUri; } }

        //public static string PromotionUri { get { return LivePromotionUri; } }

        ////--------------------------MAST------------------------
        public static Uri StagingServerUri => new Uri("http://mcgapp.org:9095/api/");

        public static string StagingServerImageUri => "http://mcgapp.org:9094/Files/";

        public static string StagingWebAppUri => "http://mcgapp.org:9094/";

        public static string StagingPromotionUri => "https://mastcgroup.com/privacy-policy/";
        public static string LivePromotionUri => "https://mastcgroup.com/privacy-policy/";

        public static Uri ServerBaseUri { get { return StagingServerUri; } }

        public static string ServerImageUri { get { return StagingServerImageUri; } }

        public static string WebAppUri { get { return StagingWebAppUri; } }

        public static string PromotionUri { get { return StagingPromotionUri; } }

        #region Account
        public static string Login => "Login";
        public static string Register => "Login/Register";
        public static string UserToken => "UserToken/VerifyEmailMobileToken";
        public static string SavePersonProfilePicture => "People/SavePersonProfilePicture/";
        public static string CreateUpdatePushNotificationToken => "PushNotification/CreateUpdatePushNotificationToken";
        //CreateUpdatePushNotificationToken
        //  /api/
        public static string VerifyEmailMobileTokenForgetPassword => "UserToken/VerifyEmailMobileTokenForgetPassword";
        
        public static string ChangePassword => "Login/ChangePassword";
        public static string ForgotPassword => "Login/ForgotPassword";
        public static string UpdatePersonDetails => "People/UpdatePersonDetails/";
        public static string ResendOTP => "Login/ResendOTP?UserID=";
        public static string ForgotPasswordOTP => "Login/ForgotPasswordOTP";
        public static string GetWarrantyCard => "Products/GetWarrantyCard/";
        public static string PostTechnicianLocationTracking => "Technician/PostTechnicianLocationTracking";
        ///api/Login/ForgotPasswordOTP
        ///PostTechnicianLocationTracking
        #endregion

        #region Addresses
        public static string GetCustomerAddresses => "Addresses/GetCustomerAddresses/";        ///api/Addresses/GetCustomerAddresses/{PersonId}
        public static string AddAddresses => "Addresses";
        public static string UpdateAddress => "Addresses/";
        ////api/Addresses/{id}
        #endregion

        #region Master Data
        ///////MasterData/GetAllCountries
        public static string GetActiveCountryList => "MasterData/GetActiveCountryList";
        public static string GetCitiesByCountryIdOld => "MasterData/GetCitiesByCountryId/{0}";
        public static string GetCitiesByCountryId => "MasterData/GetAllCitiesByCountryId/{0}";
        public static string GetAreaByCityId => "MasterData/GetAreaByCityId/{0}";

        public static string GetAllCountries => "MasterData/GetAllCountries";
        public static string GetCountryDetailsByCodeLimited => "MasterData/GetCountryDetailsByCodeLimited?CountryCode=";

        public static string ValidateSerialNumber => "MasterData/ValidateSerialNumber/";

        public static string SearchSerialNumberByInitials => "MasterData/SearchSerialNumberByInitials/{0}/{1}";
        public static string SearchModelNumberByInitials => "MasterData/SearchModelNumberByInitials?ModelNumberinitials=";
        public static string SearchAllModelNumbers => "MasterData/SearchModelNumber";
        public static string SearchModelNumberByModelNo => "MasterData/SearchModelNumberByModelNo/{0}";

        public static string FileUplod => "FileInfoes/Uploadbase64image";
        public static string DeleteCustomerProduct => "Products/DeleteCustomerProduct?id=";
        
        public static string GetCountryMaster => "MasterData/GetPrismCountryMaster";
        public static string GetProductCategory => "MasterData/GetPrismProductCategory";
        public static string GetCountryDetailsByCode => "MasterData/GetCountryDetailsByCodeLimited?CountryCode=";
        public static string GetServiceRequestTypes => "MasterData/GetServiceRequestTypes";
        public static string GetServiceRequestsByServiceCenter => "ServiceRequests/GetServiceRequestsByServiceCenter/{0}/{1}";  //0=service center id, 1=dashboard status
        public static string GetServiceRequestsByServiceCenterSupervisor => "ServiceRequests/GetServiceRequestsByServiceCenterSupervisor/{0}/{1}";  //0=service center id, 1=dashboard status
        public static string GetServiceRequestWithoutInvoiceDetails => "ServiceRequests/GetServiceRequestWithoutInvoiceDetailsBySupervisor/{0}"; //0=SelectedRequestId
        public static string GetServiceRequestStatus => "MasterData/GetServiceRequestStatus";

        #endregion

        #region Products
        ///api/ServiceRequests/GetServiceRequestImprovedAllDetails/{id}
        public static string GetCustomerProductsWithWarranty => "Products/GetCustomerProductsWithWarrantyExtra?CustomerId={0}";

        //for technician login
        public static string GetCustomerDeliveryItems => "Products/GetCustomerDeliveryItems";//(int? PurchaseCountryID = 0, int? UserId = null)
        public static string GetWarrantyTC => "Products/GetWarrantyTermsAndConditions/";
        public static string AddCustomerProduct => "Products/AddCustomerProduct";
        public static string GetCustomerProducts => "Products/GetCustomerProductsWithWarranty?CustomerId=";
        public static string ServiceRequestCheck => "ServiceRequests/ServiceRequestCheck?ProductModelId=";
        public static string GetCustomerProductModelByModelId => "Products/GetCustomerProductModelByModelId/";
        /////api/Products/GetCustomerProductModelByModelId/{modelId}
        #endregion

        #region ServicesRequest
        //  /api/ServiceRequests/CreateInvoice
        public static string GetServiceRequestImprovedAllDetails => "ServiceRequests/GetServiceRequestImprovedAllDetails/";
        public static string GetServiceRequestImprovedAllDetailsNew => "ServiceRequests/GetServiceRequestImprovedAllDetailsNew/{0}";

        public static string AddServiceRequests => "ServiceRequests";
        public static string GetServiceRequestsByCustomer => "ServiceRequests/GetServiceRequestsByCustomer/";
        public static string GetServiceRequestDetails => "ServiceRequests/GetServiceRequestAllDetails/";
        public static string IsServiceRequestRaiseAllowedForProduct => "ServiceRequests/IsServiceRequestRaiseAllowedForProduct/{0}";
        public static string CreateStandBySetRequest => "ServiceRequests/CreateStandBySetRequest";
        public static string UpdateServiceRequest => "ServiceRequests/UpdateServiceRequest";

        #endregion

        #region Service Centers
        //ServiceCenters
        // ServiceCenters/GetServiceCentersNearestToLocation?CountryId=1&latitude=34234234&longitude=2342342
        public static string GetServiceCentersNearestToLocation => "ServiceCenters/GetServiceCentersNearestToLocation?CountryId={0}&latitude={1}&longitude={2}";
        public static string GetServiceCentersByProductAndNearestLocation => "ServiceCenters/GetServiceCentersByProductAndNearestLocation?CountryId={0}&ProductClassificationId={1}&latitude={2}&longitude={3}";

        //new 
        public static string GetServiceCentersNearestToLocationByProductCategoryId => "ServiceCenters/GetServiceCentersNearestToLocationByProductCategoryId?CountryId={0}&latitude={1}&longitude={2}&productCategoryId={3}";


        #endregion

        #region AMCRequest
        //AmcRequest  /api/AmcrequestMasters/GetAmcMasterByProductCategory/{ServiceCenterId}/{ProductCategoryId}
        public static string GetAmcMasterByProductCategory => "AmcrequestMasters/GetAmcMasterByProductCategory/{0}/{1}?AmcTypeId={2}";
        //public static string AmcRequestCustomers => "AmcRequestCustomers";
        public static string GetAmcRequestCustomers => "AmcRequestCustomers";
        public static string AmcRequestCustomers => "AmcRequestCustomers";
        public static string GetAmcRequestsByCustomer => "AmcRequestCustomers/GetAmcRequestsByCustomer/{0}";
        ///api/AmcRequestCustomers/GetAmcRequestsByCustomer/{CustomerId}

        public static string GetAmcTermsByServicecenter => "AmcrequestMasters/GetAmcTermsByServicecenter/{0}"; //0=ServiceCenterId

        public static string GetAMCRequests = "Requests/GetRequests?PersonRoleId={0}&ServiceCenterID={1}"; //0=PersonRoleId,1=ServiceCenterID,2=TypeID,3=StatusId

        public static string ApproveAMCReq = "AmcRequestCustomers/{0}/{1}"; //0=id,1=AmcRequestCustomerRequest

        public static string ApproveAMC = "AmcRequestCustomers/";
        #endregion

        #region Technicaian
        public static string CreateInvoice => "ServiceRequests/CreateInvoice";
        public static string GetServiceRequestsAssignedToTechnician => "Technician/GetServiceRequestsAssignedToTechnician/";
        public static string GetServiceRequestsOfTechnician => "Technician/GetServiceRequestsOfTechnician";
        public static string GetServiceRequestsByDashboardStatus => "Technician/GetServiceRequestsByDashboardStatus";
        public static string GetTechnicianServiceRequestDetails => "ServiceRequests/GetServiceRequestDetailsForTechnician/";
        public static string UpdateServiceRequests => "ServiceRequests/";
        public static string CreateServiceCostEstimations => "ServiceCostEstimations";
        public static string GetPromoCodeForCustomerProductmodel => "CampaignMasters/GetPromoCodeForCustomerProductmodel/{0}/{1}";
        public static string GetAllModels => "ModelServiceManual/GetAllModels";
        public static string GetModelServiceManualById => "ModelServiceManual/GetModelServiceManualById/";
        public static string GetServiceManualsByModelNumber => "ModelServiceManual/GetServiceManualsByModelNumber/";
        public static string GetModelNumbersForRepairTips => "RepairTipsFaq/GetModelNumbersForRepairTips";
        public static string GetTechPortalRepairTipsByModelNumber => "RepairTipsFaq/GetTechPortalRepairTipsByModelNumber?modelNumber={0}&Keyword={1}";
        public static string GetModelRepairTipsDocumentsById => "RepairTipsFaq/GetModelRepairTipsDocumentsById?RepairTipsId=";
        public static string GetTechnicianJobsCounts => "Technician/GetTechnicianJobsCounts/";
        public static string GenerateModelRepairTipsDocumentLinksByRepairTipsId => "RepairTipsFaq/GenerateModelRepairTipsDocumentLinksByRepairTipsId/";
        public static string TechPostChat => "Chat/PostChat";
        public static string GetTechChatsByFromPersonId => "Chat/GetChatsByFromPersonId/";

        // ///api/Chat/PostChat
        #endregion

        #region Parts
        public static string AddPartRequests => "PartRequests";
        public static string GetTechnicianStock => "PartStockMasters/GetTechnicianStock/";
        public static string GetServiceCenterStock => "PartStockMasters/GetServiceCenterStock/";
        public static string GetServiceChargeMasterForCostEstimation => "ServiceChargeMasters/GetServiceChargeMasterForCostEstimation/{0}/{1}/{2}/{3}/{4}";
        public static string GetTechnicianStockWithModelNumber => "PartStockMasters/GetTechnicianStockWithModelNumber/{0}/{1}"; //0-technicianId , 1-ModelNumber
        public static string GetServiceCenterStockWithModelNumber => "PartStockMasters/GetServiceCenterStockWithModelNumber/{0}/{1}";
        public static string GetPrismPartsByModelNumberByInitials => "PartStockMasters/GetPrismPartsByModelNumberByInitials/{0}"; //0=PartNoInitials
        public static string GetPrismPartsByModelNumber => "PartStockMasters/GetStockPartByModelNumber/{0}";//"PartStockMasters/GetPrismPartsByModelNumber/{0}"; //0=ModelNo
        public static string GetPartRequestsByTechnician => "PartRequests/GetPartRequestsByTechnician/{0}"; //0=PersonId
        public static string GetPartRequestsByServiceCenterAndStatus = "PartRequests/GetPartRequestsByServiceCenterAndStatus/{0}/{1}"; //0=service center id, 1=dashboardstatus
        public static string GetPartRequestByPartRequestId = "PartRequests/GetPartRequestByPartRequestId/{0}/{1}/{2}"; //0=PartRequestId,1=serviceCenterId,2=StatusId        
        //cost estimation details for customer
        public static string GetServiceChargeMasterForCostEstimationCustomer => "ServiceChargeMasters/GetServiceChargeMasterForCostEstimation/{0}/{1}/{2}/{3}/{4}";


        ////api/Products/GetCustomerProductsWithWarranty
        #endregion

        #region FollowUp
        public static string GetFollowupsByServiceRequest => "FollowUps/GetFollowupsByServiceRequest/";
        public static string PostFollowUps => "FollowUps";
        public static string GetAllActiveSurveys => "Survey/GetAllActiveSurveys";
        public static string PostCustomerSurvey => "Survey/PostCustomerSurvey";
        public static string GetCustomerSurveyByPersonId => "Survey/GetCustomerSurveyByPersonId/";
        public static string GetQuestionsAnswersByRequestTypeId => "CustomerFeedback/GetQuestionsAnswersByRequestTypeId/";
        public static string PostCustomerFeedback => "CustomerFeedback/PostCustomerFeedback";
        ////api/Survey/GetCustomerSurveyByPersonId/{PersonId}
        #endregion

        #region ChatBot
        public static string ChatBotRequest => "Chatbot/";
        public static string ChatBotPostRequest => "Chatbot";
        public static string GetChatInqueriesByCustomer => "Chatbot/GetChatInqueriesByCustomer/";
        public static string GetByLanguage => "Chatbot/GetByLanguage/{0}/{1}"; //0=id,1=langID

        #endregion

        #region Notification
        public static string GetUnreadNotifications => "Notifications/GetUnreadNotifications/";
        public static string UpdateNotificationReadDate => "Notifications/UpdateNotificationReadDate/{0}/{1}";
        #endregion

        #region Accessory
        public static string SearchAvailableAccessories => "Accessory/SearchAvailableAccessories/{0}?ServiceCenterId={1}&keyword={2}";
        public static string GetShoppingCartItemsByPersonId => "ShoppingCart/GetShoppingCartItemsByPersonId/";
        public static string GetAvailableAccessories => "Accessory/GetAvailableAccessories/{0}"; //0-CountryID
        public static string GetAccessoryById => "Accessory/GetAccessoryById/";
        public static string GetAccessoryStocksById => "Accessory/GetAccessoryStocksById";
        public static string AddToShoppingCart => "ShoppingCart/AddToShoppingCart";
        public static string UpdateShoppingCart => "ShoppingCart/UpdateShoppingCart/{0}";
        public static string PostOrder => "Order/PostOrder";
        public static string GetOrdersByPersonId => "Order/GetOrdersByPersonId/";
        public static string GetOrderListByPersonId => "Order/GetOrderListByPersonId/{0}";
        public static string GetOrdersByOrderId => "Order/GetOrdersByOrderId/{0}/{1}";
        public static string GetOrdersByOrderIdPersonId => "Order/GetOrdersByOrderIdPersonId/{0}/{1}";

        public static string GetOrder => "Order/GetOrder/";
        public static string ReturnOrderRequest => "Order/ReturnOrder";
        public static string FullReturnOrder => "Order/FullReturnOrder";
        #endregion

        #region Technician FAQ
        public static string GetTechnicianQueriesWithSolution => "Technician/GetTechnicianQueriesWithSolution/{0}";
        public static string SaveTechnicianQuery => "Technician/SaveTechnicianQuery";
        public static string SearchTechnicianQueries => "Technician/SearchTechnicianQueries/{0}/{1}";

        #endregion

        #region Technician OrderRequests
        public static string GetTechnicianAssignedOrderRequests => "Order/GetTechnicianAssignedOrderRequests/{0}";
        #endregion

        public static string GetServiceRequestCostEstimationForCustomer => "ServiceChargeMasters/GetServiceRequestCostEstimationForCustomer/{0}"; //ServiceRequestId

        public static string RejectOrder = "Order/CancelOrder/";  //0=orderdetailid

        //promotions
        public static string GetAllPromoCodeForCustomer = "CampaignMasters/GetAllPromoCodeForCustomer/{0}/{1}/{2}"; //0=PersonId 1=CountryId 2=ProductCategoryId

        public static string UpdateParts = "PartRequests/{0}"; //0=PartRequestId

        public static string UpdatePartRequest = "PartRequests/{0}";

        public static string GetAccessoryOrderByServiceCenterAndStatus = "Accessory/GetAccessoryOrderByServiceCenterAndStatus/{0}/{1}"; //0=serviceCenterId,1=StatusId

        public static string AcceptOrder = "Order/AssignDelivery";

        public static string GetUnreadNotificationsByNotificationEventType => "Notifications/GetUnreadNotificationsByNotificationEventType/{0}/{1}";

        public static string CancelAccessoryOrder = "Order/CancelOrder/{0}";    //0= orderdetailID

        public static string GetTechnicianWithLimitedDatas = "Technician/GetTechnicianWithLimitedDatas"; //0=ServiceCenterId,1=PersonRoleId,3=ProductCategoryId,4=CustomerSRPreferredDateTime

        public static string SaveAssignedTechnicianJob = "ServiceRequests/{0}";

    }

}
