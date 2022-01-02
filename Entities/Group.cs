using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMService.Entities
{
    /// <summary>
    /// Группы контрагентов
    /// </summary>
    [Table("Groups", Schema = "Contractor")]
    public class GroupModel : CoreEntity
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public virtual ICollection<ContractorModel> Contractors { get; set; }
    }
}
