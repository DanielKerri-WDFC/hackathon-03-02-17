using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace McsAdapter.Api.Models
{
    public class Name
    {
        [Required]
        public string Given { get; set; }

        [Required]
        public string Family { get; set; }
    }
}
