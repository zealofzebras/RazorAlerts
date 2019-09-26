using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAlerts
{
    public class Alert
    {
        public AlertTypeEnum Type { get; set; }
        public HtmlString Title { get; set; }
        public HtmlString Body { get; set; }
        public bool Dismissable { get; set; }
        public bool Shown { get; set; }

        
    }
}
