using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using eWarranty.Views.Customer.CommonPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Customer.ProfileView
{
    public class MyProfilePageViewModel : BaseViewModel
    {
        public MyProfilePageViewModel(INavigation navigation) : base(navigation)
        {
            try
            {
                languages = Extensions.Getlanguages();
                //defultuser
                Email = CommonAttribute.CustomeProfile.Email;
                //MobileNumber = CommonAttribute.CustomeProfile.MobileNumber;
                PhoneCode = CommonAttribute.CustomeProfile?.PhoneCode;
                MobileNumber = PhoneCode + " " + CommonAttribute.CustomeProfile?.MobileNumber;
                Name = CommonAttribute.CustomeProfile.FirstName + " " + CommonAttribute.CustomeProfile.LastName;

                if (string.IsNullOrEmpty(MobileNumber))
                    IsVisibleMobNo = false;
                else
                    IsVisibleMobNo = true;
            }
            catch (Exception ex)
            {

            }
            
        }
        public List<LanguageModel> languages { get; set; }
        public LanguageModel SelectedLanguage { get; set; }
        public Command UserPicCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //defultuser
                    FileData fileData = await TakePhotoAsync();
                    UserPic = ImageSource.FromStream(
            () => new MemoryStream(Convert.FromBase64String(fileData.string64baseData)));
                    var newFile = Path.Combine(FileSystem.CacheDirectory, fileData.FileName);
                    Application.Current.Properties["userpic"] = UserPic;


                });
            }
        }
        public Command AddressCommand
        {
            get
            {
                return new Command(() =>
                {
                    Navigation.PushAsync(new AddressesPage());

                });
            }
        }
        public async Task SaveUserPic(FileData fileData)
        {
            try
            {
                UserManagementSL userManagementSL = new UserManagementSL();
                FilesToUpload filesToUpload = new FilesToUpload();
                filesToUpload.fileInfoId = 0;
                filesToUpload.fileName = fileData.FileName;
                filesToUpload.mimeType = fileData.FileType;
                filesToUpload.path = fileData.FileName;
                filesToUpload.fileTypeId = Convert.ToInt16(FileTypeEnum.PersonProfileImage);
                filesToUpload.base64StringImage = fileData.string64baseData;

                var resp = await userManagementSL.SavePersonProfilePicture(CommonAttribute.CustomeProfile.PersonId, filesToUpload);

            }
            catch (Exception ex)
            {

            }
            
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {

                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {

                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _PhoneCode;
        public string PhoneCode
        {
            get { return _PhoneCode; }
            set
            {

                _PhoneCode = value;
                OnPropertyChanged(nameof(PhoneCode));
            }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set
            {
                 
                _MobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        public Boolean _IsVisibleMobNo;
        public Boolean IsVisibleMobNo
        {
            get { return _IsVisibleMobNo; }
            set
            {
                _IsVisibleMobNo = value;
                OnPropertyChanged("IsVisibleMobNo");
            }
        }

        public string Photoaction { get; set; }
        public async Task<FileData> TakePhotoAsync()
        {
            try
            {
                GC.Collect();
                FileData fileData = new FileData();
                string action = await Application.Current.MainPage.DisplayActionSheet(AppResources.lblTakePhoto, AppResources.lblCancel, null, AppResources.lblTakePhoto, AppResources.lblGallery);
                FileResult photo = null;

                if (action!=null && action == AppResources.lblGallery)
                {
                    Photoaction = action;
                     photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions() {  });// CapturePhotoAsync();
                }
                else if (action != null && action == AppResources.lblTakePhoto)
                {
                    Photoaction = action;
                    if (!MediaPicker.IsCaptureSupported)
                    {
                        await ErrorDisplayAlert(AppResources.lblErrorCameranotsupported);
                        return null;
                    }

                    photo = await MediaPicker.CapturePhotoAsync();
                }
                
                if (photo != null)
                {
                    Application.Current.Properties["Photoaction"] = Photoaction;
                   await Application.Current.SavePropertiesAsync();
                    return fileData = await LoadPhotoAsync(photo);

                    // Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                }
                return fileData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                return null;
            }
        }
        async Task<FileData> LoadPhotoAsync(FileResult photo)
        {
            // canceled
            try
            {
                FileData fileData = new FileData();
             
                if (photo == null)
                {
                   // PhotoPath = null;
                    return null;
                }

                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                fileData.FileType = photo.ContentType;
                if (Device.RuntimePlatform == Device.Android)
                {
                    using (var stream = await photo.OpenReadAsync())
                    {
                       
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);


                        string string64base = Extensions.ConvertToBase64(stream);
                        fileData.string64baseData = string64base;
                    }
                }
                else
                {
                    using (var stream = await photo.OpenReadAsync())
                    {
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);

                        var originalImageByteArray = new Byte[(int)stream.Length];

                        stream.Seek(0, SeekOrigin.Begin);
                        stream.Read(originalImageByteArray, 0, (int)stream.Length);

                        var resizer = DependencyService.Get<IImageResizer>();
                        var resizedBytes = resizer.ResizeImage(originalImageByteArray, 400, 400);

                        string string64base = Convert.ToBase64String(resizedBytes);
                        fileData.string64baseData = string64base;
                    }




                }
                fileData.FileName = photo.FileName;

                return fileData;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
