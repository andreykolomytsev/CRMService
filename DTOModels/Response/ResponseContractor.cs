using System;
using System.Collections.Generic;
using CRMService.Entities;

namespace CRMService.DTOModels.Response
{
    public class ResponseContractor : CoreResponse
    {
        public ContractorType.Type Type { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string EMail { get; set; }

        public string SiteLink { get; set; }

        public string ActualAddress { get; set; }

        public string Description { get; set; }

        public ResponseGroup Group { get; set; }

        #region Реквизиты
        public string LegalTitle { get; set; }

        public string LegalAddress { get; set; }

        public string INN { get; set; }

        public string OGRN { get; set; }

        public string KPP { get; set; }

        public string OKPO { get; set; }

        public string CertificateNumber { get; set; }

        public DateTime? CertificateDate { get; set; }
        #endregion

        public List<ResponseContact> Contacts { get; set; }

        public List<ResponsePayment> Payments { get; set; }
    }
}
