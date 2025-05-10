using System;
namespace eWarranty.Models
{
    //public class DropDownModel<T>
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public T Item { get; set; }
    //}
    public class DropDownModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Desc { get; set; }

    }

    public class DropDownModelTimeSlot
    {
        public DateTime  AvailableTimeSlot { get; set; }      
    }
}
