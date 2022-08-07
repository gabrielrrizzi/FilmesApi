using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateEnderecoDto
    {
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string Bairro { get; set; }        
        public int Numero { get; set; }               
    }
}
