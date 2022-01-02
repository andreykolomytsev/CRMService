using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMService.Entities
{
    /// <summary>
    /// Методы оплаты
    /// </summary>
    [Table("Payments", Schema = "Contractor")]
    public class PaymentModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string BankName { get; set; }

        [MaxLength(255)]
        public string BankBIC { get; set; }

        [MaxLength(255)]
        public string BankBill { get; set; }

        [MaxLength(255)]
        public string BankAddress { get; set; }

        [MaxLength(255)]
        public string KBill { get; set; }

        [MaxLength(255)]
        public string RBill { get; set; }

        public bool IsDefault { get; set; }

        public int ContractorId { get; set; }
        public virtual ContractorModel Contractor { get; set; }
    }
}
