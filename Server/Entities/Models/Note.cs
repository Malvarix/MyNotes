using Entities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Note
    {
        [Key, Required]
        public int Id { get; set; }
        [MinLength(0,ErrorMessage = "Field is empty!"), MaxLength(250, ErrorMessage = "Maximum length of note is 250 characters"), Required]
        public string Description { get; set; }
        [Required]
        public Priority Priority { get; set; }
    }
}