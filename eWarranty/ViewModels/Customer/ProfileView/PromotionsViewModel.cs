using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using eWarranty.Core.Hepler;
using eWarranty.Core.ResponseModels;
using eWarranty.Core.ServiceLayer;
using eWarranty.Hepler;
using eWarranty.Views.Customer.UserProfile;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace eWarranty.ViewModels.Customer.ProfileView
{
    public class PromotionsViewModel : BaseViewModel
    {
        public ICommand RefreshCommand { get; }

        public PromotionsViewModel(INavigation navigation) : base(navigation)
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingPromotionData();
                IsBusy = false;

            });
            RefreshCommand = new Command(ExecuteRefreshCommand);

        }

        public async Task BindingPromotionData()
        {
            try
            {
                CurrencyCode = CommonAttribute.CustomeProfile.CountryResponse?.CurrencyCode;

                UserManagementSL userManagementSL = new UserManagementSL();
                List<CampaignMasterResponses> campaignMasterResponses = await userManagementSL.GetAllPromoCodeForCustomer((long)CommonAttribute.CustomeProfile?.PersonId, (long)CommonAttribute.CustomeProfile?.CountryId, 0);
                if (campaignMasterResponses != null && campaignMasterResponses.Count > 0)
                {
                    lstCampaignMasterResponses = campaignMasterResponses;
                    lstCampaignMasterResponses.ForEach(h => h.Description = HTMLToText(h.Description));
                    lstCampaignMasterResponses.ForEach(c => c.CurrencyCode = CurrencyCode);
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command<CampaignMasterResponses>(async (obj) =>
                {
                    var PersonId = CommonAttribute.CustomeProfile?.PersonId;
                    var Link = ServiceEndPoints.PromotionUri + "claims/register?cid=" + PersonId + "&cgid=" + obj.CampaignMasterId;
                    await Navigation.PushAsync(new CampaignURLRedirectPage(Link));
                });
            }
        }


        public string HTMLToText(string HTMLCode)
        {
            // Remove new lines since they are not visible in HTML
            HTMLCode = HTMLCode.Replace("\n", " ");

            // Remove tab spaces
            HTMLCode = HTMLCode.Replace("\t", " ");

            // Remove multiple white spaces from HTML
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

            // Remove HEAD tag
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Remove any JavaScript
            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            // Replace special characters like &, <, >, " etc.
            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            // Note: There are many more special characters, these are just
            // most common. You can add new characters in this arrays if needed
            string[] OldWords = { "&nbsp;", "&amp;", "&quot;", "&lt;", "&gt;", "&reg;", "&copy;", "&bull;", "&trade;" };
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }

            // Check if there are line breaks (<br>) or paragraph (<p>)
            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");

            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }

        private List<CampaignMasterResponses> _campaignMasterResponses;
        public List<CampaignMasterResponses> lstCampaignMasterResponses
        {
            get { return _campaignMasterResponses; }
            set
            {
                _campaignMasterResponses = value;
                OnPropertyChanged(nameof(lstCampaignMasterResponses));
            }

        }


        public bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        void ExecuteRefreshCommand()
        {
            IsBusy = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await BindingPromotionData();
                IsBusy = false;

            });
            // Stop refreshing
            IsRefreshing = false;
        }
    }
}

//open link in app browser itselt
public class BrowserTest
{
    public async Task OpenBrowser(Uri uri)
    {
        try
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // An unexpected error occured. No browser may be installed on the device.
        }
    }
}