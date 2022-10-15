using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace SocialsHub.Core.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            References = new Collection<Reference>();
        }

        public string Description { get; set; }
        public string Image { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string YouTube { get; set; }
        public string GitHub { get; set; }
        public string Linkedin { get; set; }

        public ICollection<Reference> References { get; set; }
    }
}
