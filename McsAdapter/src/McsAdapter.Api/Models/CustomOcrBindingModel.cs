using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace McsAdapter.Api.Models
{
    public class CustomOcrBindingModel
    {
        [Required]
        [Url]
        public string Url { get; set; }

    }
}
