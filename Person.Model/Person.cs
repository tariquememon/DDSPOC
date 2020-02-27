using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<Email> Emails { get; set; }
    }
}
