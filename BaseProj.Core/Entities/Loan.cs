using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProj.Core.Entities
{
    public class Loan : GenericEntity
    {
        public Loan()
        {
            RegisterDate = DateTime.Now;
        }

        public int Status { get; set; }
        public int Modality { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? LoanDate { get; set; }
        public decimal? DebtorBalance { get; set; }
        public int? DebtorBalanceQtdPart { get; set; }
        public decimal LoanValue { get; set; }
        public int? InstallmentAmount { get; set; }
        public decimal? InstallmentValue { get; set; }
        public decimal? TotalPayable { get; set; }
        public int BankId { get; set; }
        public string Observation { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
    }
}
