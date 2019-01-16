using System;
using System.ComponentModel.DataAnnotations;

namespace BaseProj.Core.Entities
{
    public class User : GenericEntity
    {
        public User()
        {
            RegisterDate = DateTime.Now;
        }

        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
