using System;
using eWarranty.Hepler;
using Xamarin.Forms;

namespace eWarranty.Models
{
    public class FollowUpUIModel
    {
        public string MessageContent { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public long FollowUpId { get; set; }
        public long FromPersonId { get; set; }
        public long ToPersonId { get; set; }

        public string FromName { get {

                if (FromPersonId == CommonAttribute.CustomeProfile.PersonId)
                    return "You";
                else
                    return "Service Center";
            } }

        public Thickness Margin
        {
            get
            {
                if (FromPersonId == CommonAttribute.CustomeProfile.PersonId)
                    return new Thickness(60, 5, 0, 2);
                else
                    return new Thickness(0, 2, 70, 5);

            }
        }

        //public int Margin
        //{
        //    get
        //    {
        //        if (FromPersonId == CommonAttribute.CustomeProfile.PersonId)
        //            return 50;
        //        else
        //            return 60;
        //    }
        //}


        public Color ChatColor
        {
            get
            {

                if (FromPersonId == CommonAttribute.CustomeProfile.PersonId)
                    return Color.FromHex("#d3f8e2");
                else
                    return Color.FromHex("#dfe7fd");
            }
        }

        public Color DescTextColor
        {
            get
            {

                if (FromPersonId == CommonAttribute.CustomeProfile.PersonId)
                    return Color.Blue;
                else
                    return Color.FromHex("#EA1D24");
            }
        }

    }
}
