using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Model.Record
{
    public class RecordPostRequest
    {

       
        public String? EntryDate { get; set; }
        
        public String? LeaveEntryDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
