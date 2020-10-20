using System;
using System.Collections.Generic;

namespace LegoMaster.Models
{
    public partial class Sickleave
    {
        public int Sickid { get; set; }
        public DateTime DateReceivedAltin { get; set; }
        public DateTime? SapUpdated { get; set; }
        public int? EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public int? OrgNumber { get; set; }
        public string Period { get; set; }
        public int? PercentSickleave { get; set; }
        public int? TotalDays { get; set; }
        public string SapCodeIt2001 { get; set; }
        public bool? ToManualHandlling { get; set; }
        public string ReasonManualHandling { get; set; }
        public bool? OffshoreSickleave { get; set; }
        public bool? LandSickleave { get; set; }
        public string SapCadeIt00281 { get; set; }
        public string SapCodeIt00282 { get; set; }
        public bool? ExceptionPregRequested { get; set; }
        public bool? RefundDemand { get; set; }
        public string ApplicationSickleavePayRecieved { get; set; }
        public bool? IncomeReportSent { get; set; }
        public bool? CompleteSettlement { get; set; }
        public DateTime? SysUpdated { get; set; }
        public string Comments { get; set; }
    }
}
