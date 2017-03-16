using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithWebSite.Models.ZenithModels
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }


        public int ActivityId { get; set; }
        public Activity ActivityDetails { get; set; }
        

    }
}
