using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SocialsHub.Core.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileDto ProfileDto { get; set; }
        public ReferenceDto ReferenceDto { get; set; }
        public IEnumerable<ReferenceDto> References { get; set; }

        [Display(Name = "Zdjęcie")]
        [Required(ErrorMessage = "Zdjęcie jest wymagane.")]
        public IFormFile Image { get; set; }
    }
}
