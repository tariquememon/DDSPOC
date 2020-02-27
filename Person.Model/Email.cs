using System.ComponentModel.DataAnnotations;

namespace App.Model
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
