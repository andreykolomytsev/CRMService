using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMService.Entities
{
    /// <summary>
    /// Контактные лица
    /// </summary>
    [Table("Contacts", Schema = "Contractor")]
    public class ContactModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Position { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool IsDefault { get; set; }

        public int ContractorId { get; set; }
        public virtual ContractorModel Contractor { get; set; }
    }
}
