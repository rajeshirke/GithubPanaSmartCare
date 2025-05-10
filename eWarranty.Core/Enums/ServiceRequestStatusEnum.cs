

namespace eWarranty.Core.Enums
{
    public enum ServiceRequestStatusEnum
    {
       
        New = 1,//--- service requested  by customer

       
        Assigned = 2,//--- service Assigned to technician by Supervisor
                     //-- AcceptedByTechnician,

        PendingforRequestConfirmation = 3,//-- for inprogress job

       
        EstimationConfirmationPending = 4,//-- FromCustomer

    
        RequestSchedulledComfirmed = 5,//-- FromCustomer

       
        RepairInprogress = 6,//-- By technician

     
        PendingForParts = 7,//-- By technician

       
        RepairCompletion = 8,//-- By technician

     
        PendingForPayment = 9,//-- By technician

       
        JobClosedWithoutRepair = 10,//-- By technician

        
        JobClosed = 11,//-- By technician 11 completed job


        DeliveredPaymentCollection = 12, //-- By technician


        Cancelled = 13,
        //JobClosedBySupervisor,//-- By Supervisor


        EstimationConfirmed = 14 //EstimationConfirmed 

    }
}
