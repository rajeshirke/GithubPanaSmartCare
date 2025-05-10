using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ExtraModels
{
    public class CustomSelectChkList
    {

        //Value of checkbox   
        public int Value
        {
            get;
            set;
        }
        //description of checkbox   
        public string Text
        {
            get;
            set;
        }
        //whether the checkbox is selected or not   
        public bool IsChecked
        {
            get;
            set;
        }
    }
}
