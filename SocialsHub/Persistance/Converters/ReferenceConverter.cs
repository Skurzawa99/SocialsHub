using Microsoft.CodeAnalysis.CSharp.Syntax;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Models.Dtos;

namespace SocialsHub.Persistance.Converters
{
    public static class ReferenceConverter
    {
        public static ReferenceDto ToDto(this Reference model)
        {
            return new ReferenceDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Link = model.Link,
                UserId = model.UserId,
                Enable = model.Enable,
                CreatedDate = model.CreatedDate
            };
        }

        public static IEnumerable<ReferenceDto> ToDtos(this IEnumerable<Reference> model)
        {
            if (model == null)
                return Enumerable.Empty<ReferenceDto>();

            return model.Select(x => x.ToDto());
        }

        public static Reference ToDao(this ReferenceDto model)
        {
            return new Reference
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Link = model.Link,
                UserId = model.UserId,
                Enable = model.Enable,
                CreatedDate = model.CreatedDate
            };
        }
    }
}
