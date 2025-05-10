using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.DependencyServices;
using eWarranty.Hepler;
using eWarranty.Models;
using eWarranty.Resx;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eWarranty.ViewModels.Technician.SupportViews
{
    public class ServiceCenterChatViewModel : BaseViewModel
    {
        public event EventHandler UpdateItem;
        public ServiceCenterChatViewModel(INavigation navigation) : base(navigation)
        {

            //TechnicianManagementSL
            Device.BeginInvokeOnMainThread(async () => {
                await BindingData();
                IsBusy = false;
            });
           
            
            OutGoingText = null;

        }
        public async Task BindingData()
        {
            Messages = new ObservableCollection<MessageViewModel>();
            TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
            List<ChatResponse> chatResponses= await  technicianManagementSL.GetTechChatsByFromPersonId(CommonAttribute.CustomeProfile.PersonId);
            foreach (var item in chatResponses.OrderBy(o=>o.ChatDate))
            {
                MessageViewModel messageView = new MessageViewModel();
                messageView.id = item.ChatId;
                messageView.Text = item.Message;
                messageView.MessagDateTime = item.ChatDate;
                if (!string.IsNullOrEmpty(item.FileName))
                  messageView.AttachementUrl =CommonAttribute.ImageBaseUrl+item.FileName;
                if (item.FromPersonId != CommonAttribute.CustomeProfile.PersonId)
                    messageView.IsIncoming = true;
                else
                    messageView.IsIncoming = false;
                messageView.Personid = item.FromPersonId;
                Messages.Add(messageView);
            }
            MessagingCenter.Send<ServiceCenterChatViewModel, string>(this, "Updatechat", OutGoingText);
            //Messages = new ObservableCollection<MessageViewModel>
            //{
            //    new MessageViewModel { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-25)},
            //    new MessageViewModel { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-24)},
            //    new MessageViewModel { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
            //    new MessageViewModel { Text = "You will love it. Don't miss.", IsIncoming = true, MessagDateTime = DateTime.Now.AddMinutes(-23)},
            //    new MessageViewModel { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},

            //    new MessageViewModel { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessagDateTime = DateTime.Now.AddMinutes(-23)},


            //};
        }
        private ObservableCollection<MessageViewModel> messagesList;

        public ObservableCollection<MessageViewModel> Messages
        {
            get { return messagesList; }
            set { messagesList = value; OnPropertyChanged("Messages"); }
        }

        private string outgoingText;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { outgoingText = value; OnPropertyChanged("OutGoingText"); }
        }
       

        
        public Command SendCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (!string.IsNullOrEmpty(OutGoingText))
                    {

                        Messages.Add(new MessageViewModel { Text = OutGoingText, IsIncoming = false, MessagDateTime = DateTime.Now });
                        MessagingCenter.Send<ServiceCenterChatViewModel, string>(this, "Updatechat", OutGoingText);
                        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                        ChatRequest chatRequest = new ChatRequest();
                        chatRequest.FromPersonId = CommonAttribute.CustomeProfile.PersonId;
                        chatRequest.Message = OutGoingText;
                        
                      await  technicianManagementSL.TechPostChat(chatRequest);

                        OutGoingText = null;
                    }
                });
            }
        }
        public Command FileCommand
        {
            get
            {
                return new Command(async () =>
                {
                    FileData fileData=  await TakePhotoAsync();
                    if (fileData != null && !string.IsNullOrEmpty(fileData.FilePath))
                    {
                        Messages.Add(new MessageViewModel { AttachementUrl = fileData.FilePath, Text = OutGoingText, IsIncoming = false, MessagDateTime = DateTime.Now });
                        MessagingCenter.Send<ServiceCenterChatViewModel,string>(this, "Updatechat", OutGoingText);
                        TechnicianManagementSL technicianManagementSL = new TechnicianManagementSL();
                        ChatRequest chatRequest = new ChatRequest();
                        chatRequest.FromPersonId = CommonAttribute.CustomeProfile.PersonId;
                        FilesToUpload filesToUpload = new FilesToUpload();

                        filesToUpload.fileName = fileData.FileName;
                        filesToUpload.mimeType = fileData.FileType;
                        filesToUpload.path = fileData.FileName;
                        filesToUpload.fileTypeId = Convert.ToInt16(FileTypeEnum.ChatImage);
                        filesToUpload.base64StringImage = fileData.string64baseData;
                        chatRequest.File = filesToUpload;

                        await technicianManagementSL.TechPostChat(chatRequest);
                    }
                        OutGoingText = null;
                });
            }
        }
        public FileResult photo { get; set; }
        async Task<FileData> TakePhotoAsync()
        {
            try
            {
                GC.Collect();
                photo = null;
                FileData fileData = new FileData();
                string action = await Application.Current.MainPage.DisplayActionSheet(AppResources.lblTakePhoto, AppResources.lblCancel, null, AppResources.lblTakePhoto, AppResources.lblGallery);

                if (action == AppResources.lblGallery)
                {
                    photo = await MediaPicker.PickPhotoAsync();// CapturePhotoAsync();
                }
                else if (action == AppResources.lblTakePhoto)
                {
                    if (!MediaPicker.IsCaptureSupported)
                    {
                        await ErrorDisplayAlert(AppResources.lblErrorCameranotsupported);
                        return null;
                    }
                    MediaPickerOptions mediaPicker = new MediaPickerOptions();

                    photo = await MediaPicker.CapturePhotoAsync();
                }

                if (photo != null)
                {
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
        public string PhotoPath { get; set; }
        async Task<FileData> LoadPhotoAsync(FileResult photo)
        {
            // canceled
            try
            {
                FileData fileData = new FileData();

                if (photo == null)
                {
                    PhotoPath = null;
                    return null;
                }

                // save the file into local storage
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                fileData.FilePath = newFile;
                fileData.FileType = photo.ContentType;
                if (Device.RuntimePlatform == Device.Android)
                {
                    using (var stream = await photo.OpenReadAsync())
                    {
                        using (var newStream = File.OpenWrite(newFile))
                            await stream.CopyToAsync(newStream);


                        string string64base = eWarranty.Hepler.Extensions.ConvertToBase64(stream);
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

        //FileCommand

    }
}
