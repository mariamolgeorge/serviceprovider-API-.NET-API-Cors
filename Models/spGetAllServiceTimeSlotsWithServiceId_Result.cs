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
    
    public partial class spGetAllServiceTimeSlotsWithServiceId_Result
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Systime { get; set; }
        public string StartTimeString { get; set; }
    }
}
