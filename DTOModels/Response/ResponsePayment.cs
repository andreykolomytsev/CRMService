namespace CRMService.DTOModels.Response
{
    public class ResponsePayment
    {
        public string BankName { get; set; }

        public string BankBIC { get; set; }

        public string BankBill { get; set; }

        public string BankAddress { get; set; }

        public string KBill { get; set; }

        public string RBill { get; set; }

        public bool IsDefault { get; set; }
    }
}
