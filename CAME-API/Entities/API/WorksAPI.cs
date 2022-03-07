using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper; 

namespace CAME_API.Entities {
    public class NewWork
        {
        [Required] public int MinistryID { get; set; }
        [Required] public string FormPeopleName { get; set; }
        public string FormLanguage { get; set; }
        public string FormLocation { get; set; }
        public string Status { get; set; }
    }

}
