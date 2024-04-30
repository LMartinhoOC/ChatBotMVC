using System.ComponentModel.DataAnnotations;

namespace ChatBotMVC.Models
{
    public class ChaveAPIViewModel
    {
        [Required(ErrorMessage = "A Chave API é obrigatória!")]
        public string ChaveAPI {  get; set; }
    }
}
