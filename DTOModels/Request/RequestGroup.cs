using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMService.DTOModels.Request
{
    public class RequestGroup
    {
        [Required]
        [MaxLength(255)]
        [DefaultValue("Группа")]
        public string FullName { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Description { get; set; }
    }
}
