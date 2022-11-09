using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Tag { get; set; }
        public string Comments { get; set; }
        public bool DisplayOnWeb { get; set; }
        public int SortOrder { get; set; }
        public string IpAddress { get; set; }
        public bool IsPublished { get; set; }
        public string PublishedBy { get; set; }
        public DateTime DatePublished { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string UpDateBy { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DateDeleted { get; set; }

    }
}
