using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMService.DTOModels.Request
{
    public class RequestContact
    {
        [MaxLength(255)]
        [DefaultValue("")]
        public string Name { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Position { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Email { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Phone { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsDefault { get; set; }
    }
}
