﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BaseProj.Core.Entities
{
    public class Client : GenericEntity
    {
        [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
        public string Name { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string PortalRegistration { get; set; }
        public string PortalPassword { get; set; }
        public string BenefitNumber { get; set; }
        public string CounterCheckPassword { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string Op { get; set; }
    }
}