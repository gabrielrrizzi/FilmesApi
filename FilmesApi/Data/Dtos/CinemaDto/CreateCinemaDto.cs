using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateCinemaDto
    {
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
