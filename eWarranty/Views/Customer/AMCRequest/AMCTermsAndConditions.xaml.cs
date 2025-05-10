using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eWarranty.Views.Customer.AMCRequest
{
    public partial class AMCTermsAndConditions : ContentPage
    {
        public AMCTermsAndConditions(string TermsandConditions)
        {
            InitializeComponent();
            if(TermsandConditions!=null && TermsandConditions!=string.Empty && TermsandConditions!="")
            {
                lblAMCTerms.Text = TermsandConditions;
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
