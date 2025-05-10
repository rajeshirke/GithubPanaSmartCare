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
    public class UserManagementSL
    {
        public async Task<ReceiveContext<PersonLoginResponse>> ValidateUser(LoginRequest loginRequest)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.Login, loginRequest);
        }
        public async Task<APIResponse> CreateUpdatePushNotificationToken(PushNotificationToken loginRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.CreateUpdatePushNotificationToken, loginRequest);
        }
        public async Task<APIResponse> SavePersonProfilePicture(long PersonId, FilesToUpload filesToUpload )
        {
            return await WebServiceUtils<APIResponse>.PutData(ServiceEndPoints.SavePersonProfilePicture+ PersonId, filesToUpload);
        }
        //SavePersonProfilePicture
        public async Task<ReceiveContext<PersonLoginResponse>> Register(PersonRegisterRequest person)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.Register, person);
        }
        public async Task<ReceiveContext<string>> ChangePassword(PasswordRequestModel password)
        {
            return await WebServiceUtils<ReceiveContext<string>>.PostData(ServiceEndPoints.ChangePassword, password);
        }
        public async Task<ReceiveContext<PersonLoginResponse>> ForgotPassword(ForgotPasswordRequest email)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.ForgotPasswordOTP, email);
        }
        public async Task<ValidateTokenResponse> UserTokenValidate(UserTokenValidateReq userToken)
        {
            return await WebServiceUtils<ValidateTokenResponse>.PostData(ServiceEndPoints.UserToken, userToken);
        }
        public async Task<ValidateTokenResponse> VerifyEmailMobileTokenForgetPassword(UserTokenValidateReq userToken)
        {
            return await WebServiceUtils<ValidateTokenResponse>.PostData(ServiceEndPoints.VerifyEmailMobileTokenForgetPassword, userToken);
        }
        public async Task<APIResponse> ResendOTP(string UserId)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.ResendOTP+UserId,null);
        }
        public async Task<APIResponse> UpdatePersonDetails(PersonUpdateRequest personUpdate)
        {
            return await WebServiceUtils<APIResponse>.PutData(ServiceEndPoints.UpdatePersonDetails+ personUpdate.PersonId, personUpdate);
        }

        public async Task<List<PersonNotificationResponse>> GetUnreadNotifications(long PersonId)
        {
            return await WebServiceUtils<List<PersonNotificationResponse>>.GetData(ServiceEndPoints.GetUnreadNotifications + PersonId);
        }
        public async Task<bool> UpdateNotificationReadDate(long PersonId,int NotificationId)
        {
            return await WebServiceUtils<bool>.PutData(string.Format(ServiceEndPoints.UpdateNotificationReadDate, PersonId, NotificationId),null);
        }
        //public async Task<ReceiveContext<string>> GetWarrantyCard(long modelId)
        //{
        //    return await WebServiceUtils<ReceiveContext<string>>.PostData(ServiceEndPoints.GetWarrantyCard + modelId,null);
        //}

        public async Task<APIResponse> GetWarrantyCard(long modelId)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.GetWarrantyCard + modelId, null);
        }

        public async Task<APIResponse> PostTechnicianLocationTracking(TechnicianLocationTrackingRequest modelId)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.PostTechnicianLocationTracking, modelId);
        }
        ///PostTechnicianLocationTracking


        ///Promotions List
        public async Task<List<CampaignMasterResponses>> GetAllPromoCodeForCustomer(long PersonId,long CountryId,long ProductCategoryId)
        {
            return await WebServiceUtils<List<CampaignMasterResponses>>.GetData(string.Format(ServiceEndPoints.GetAllPromoCodeForCustomer, PersonId, CountryId, ProductCategoryId));
        }

        public async Task<List<PersonNotificationResponse>> GetUnreadNotificationsByNotificationEventType(long PersonId,long NotificationEventTypeId)
        {
            return await WebServiceUtils<List<PersonNotificationResponse>>.GetData(string.Format(ServiceEndPoints.GetUnreadNotificationsByNotificationEventType, PersonId, NotificationEventTypeId));
        }
    }
}
