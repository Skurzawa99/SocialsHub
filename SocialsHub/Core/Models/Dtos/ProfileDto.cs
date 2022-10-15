namespace SocialsHub.Core.Models.Dtos
{
    public class ProfileDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string YouTube { get; set; }
        public string GitHub { get; set; }
        public string Linkedin { get; set; }
    }
}
