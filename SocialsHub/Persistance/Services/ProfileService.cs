using Microsoft.Extensions.Hosting;
using SocialsHub.Core;
using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Services;

namespace SocialsHub.Persistance.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfileService(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IQueryable<ApplicationUser> GetAll(string searchString)
        {
            return _unitOfWork.Profile.GetAll(searchString);
        }

        public ApplicationUser Get(string id)
        {
            return _unitOfWork.Profile.Get(id);
        }

        public void UpdateDesc(ApplicationUser profileDao, string userId)
        {
            _unitOfWork.Profile.UpdateDesc(profileDao, userId);
            _unitOfWork.Complete();
        }
        public void UpdateIcon(ApplicationUser iconDao, string userId)
        {
            _unitOfWork.Profile.UpdateIcon(iconDao, userId);
            _unitOfWork.Complete();
        }

        public void UpdateImage(string image, string userId)
        {
            _unitOfWork.Profile.UpdateImage(image, userId);
            _unitOfWork.Complete();
        }

        public string UploadFile(IFormFile image)
        {
            string fileName = null;

            string folderName = "Images";
            string folderPath = @"wwwroot\" + folderName;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (image != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, folderName);
                fileName = Guid.NewGuid().ToString() + "-" + image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return fileName;
        }

    }
}
