using System;
using System.Collections.Generic;

#nullable disable

namespace SocialMediaApp.DataDB
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
