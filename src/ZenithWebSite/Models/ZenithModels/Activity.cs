using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithWebSite.Models.ZenithModels
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        List <Event> Events { get; set; } 

    }
}
