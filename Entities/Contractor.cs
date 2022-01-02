using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMService.Entities
{
    /// <summary>
    /// Список контрагентов
    /// </summary>
    [Table("Contractors", Schema = "Contractor")]
    public class ContractorModel : CoreEntity
    {
        [Required]
        public ContractorType.Type Type { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string EMail { get; set; }

        [MaxLength(255)]
        public string SiteLink { get; set; }

        [MaxLength(255)]
        public string ActualAddress { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int GroupId { get; set; }
        public virtual GroupModel Group { get; set; }

        #region Реквизиты
        [MaxLength(255)]
        public string LegalTitle { get; set; }

        [MaxLength(255)]
        public string LegalAddress { get; set; }

        [MaxLength(255)]
        public string INN { get; set; }

        [MaxLength(255)]
        public string OGRN { get; set; }

        [MaxLength(255)]
        public string KPP { get; set; }

        [MaxLength(255)]
        public string OKPO { get; set; }

        [MaxLength(255)]
        public string CertificateNumber { get; set; }

        public DateTime? CertificateDate { get; set; }
        #endregion

        /// <summary>
        /// Внешний ключи на таблицу с контактами
        /// </summary>
        public virtual ICollection<ContactModel> Contacts { get; set; }

        /// <summary>
        /// Внешний ключ на таблицу с методами оплаты
        /// </summary>
        public virtual ICollection<PaymentModel> Payments { get; set; }
    }
}
