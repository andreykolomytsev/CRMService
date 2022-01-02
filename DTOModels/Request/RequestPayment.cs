using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRMService.DTOModels.Request
{
    public class RequestPayment
    {
        [MaxLength(255)]
        [DefaultValue("")]
        public string BankName { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string BankBIC { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string BankBill { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string BankAddress { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string KBill { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string RBill { get; set; }

        [DefaultValue(false)]
        public bool IsDefault { get; set; }
    }
}
