using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseProj.Core.Entities
{
    public class Client : GenericEntity
    {
        public Client()
        {
            RegisterDate = DateTime.Now;
        }

        [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
        public string Name { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Registration { get; set; }
        public string PortalPassword { get; set; }
        public int Type { get; set; }
        public decimal Margin { get; set; }
        public DateTime? MarginDate { get; set; }
        public string BenefitNumber { get; set; }
        public string SIAPNumber { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string Op { get; set; }
        public string Observation { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
