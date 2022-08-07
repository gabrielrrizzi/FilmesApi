using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Bairro { get; set; }
        [StringLength(10000, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Numero { get; set; }
    }
}
