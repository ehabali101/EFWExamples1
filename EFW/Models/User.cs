using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFW.Models
{
    class User
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }
    }
}
