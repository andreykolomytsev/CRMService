using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CRMService.Entities;

namespace CRMService.DTOModels.Request
{
    public class RequestContractor
    {
        [Required]
        public ContractorType.Type Type { get; set; }

        [Required]
        [MaxLength(255)]
        [DefaultValue("Контрагент")]
        public string FullName { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Phone { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string EMail { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string SiteLink { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string ActualAddress { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string Description { get; set; }

        public int GroupId { get; set; }

        #region Реквизиты
        [MaxLength(255)]
        [DefaultValue("")]
        public string LegalTitle { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string LegalAddress { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string INN { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string OGRN { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string KPP { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string OKPO { get; set; }

        [MaxLength(255)]
        [DefaultValue("")]
        public string CertificateNumber { get; set; }

        [DefaultValue(null)]
        public DateTime? CertificateDate { get; set; }
        #endregion

        public List<RequestContact> Contacts { get; set; }

        public List<RequestPayment> Payments { get; set; }
    }
}
