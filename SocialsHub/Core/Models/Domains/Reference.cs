


using System.ComponentModel.DataAnnotations;


namespace SocialsHub.Core.Models.Domains
{
    public class Reference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Aktywny")]
        public bool Enable { get; set; }
        public DateTime CreatedDate { get; set; }

        public ApplicationUser User { get; set; }
    }
}
