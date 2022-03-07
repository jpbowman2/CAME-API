using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CAME_API.Entities
{
    public class Work
    {
        [Key] public int MinistryWorksID { get; set; }
        [Required] public int MinistryID { get; set; }
        public string FormPeopleName { get; set; }
        public string FormLanguage { get; set; }
        public string FormLocation { get; set; }
        public string Status { get; set; }

    }
}
