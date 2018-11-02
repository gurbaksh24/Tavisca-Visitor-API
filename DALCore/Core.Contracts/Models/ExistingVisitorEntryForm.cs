using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class ExistingVisitorEntryForm
    {
        public int VisitorId { get; set; }
        public string ComingFrom { get; set; }
        public string WhomToMeet { get; set; }
        public string PurposeOfVisit { get; set; }
        public string GuardId { get; set; }
    }
}
