using System.ComponentModel.DataAnnotations;

namespace Contact_Manager.Models
{
    public class ContactsModel
    {
        // GETTERS AND SETTERS 

        public int ContactID { get; set; }

        [Required]

        public string? ContactName { get; set; }

        [Required]
        public string? Telephone { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? DateAdded { get; set; }

    }
}
