//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InIT.API.GMMEP.Models
{
    using System;
    
    public partial class spGetAllCallAssignDetailsWithServiceBookingId_Result
    {
        public int Id { get; set; }
        public Nullable<int> ServiceBookingId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> TechnicianId { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string TechnicianRemarks { get; set; }
        public System.DateTime ServiceStartTime { get; set; }
        public System.DateTime ServiceEndTime { get; set; }
        public System.DateTime AssignedTime { get; set; }
        public string StartLocation { get; set; }
        public double Amount { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> SysTime { get; set; }
        public string TechnicianName { get; set; }
        public string ServiceStatus { get; set; }
        public Nullable<int> ServiceHours { get; set; }
        public string StartImageUrl { get; set; }
        public string StopImageUrl { get; set; }
    }
}
