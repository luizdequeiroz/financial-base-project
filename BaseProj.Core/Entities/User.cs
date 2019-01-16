using System.ComponentModel.DataAnnotations;

namespace BaseProj.Core.Entities
{
    public class User : GenericEntity
    {
        [Required(ErrorMessage = "E-mail obrigatório.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
