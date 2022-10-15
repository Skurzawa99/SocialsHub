using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SocialsHub.Core.Models.Dtos
{
    public class ReferenceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [Display(Name = "Tytuł")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Url]
        [Required(ErrorMessage = "Link jest wymagany.")]
        public string Link { get; set; }
        public string UserId { get; set; }
        public bool Enable { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
