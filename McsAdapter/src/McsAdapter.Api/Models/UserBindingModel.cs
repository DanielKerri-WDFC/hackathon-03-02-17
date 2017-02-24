using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace McsAdapter.Api.Models
{
    public class UserBindingModel
    {
        [Required]
        public Name Name { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}
