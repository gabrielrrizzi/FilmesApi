using FilmesApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public Endereco Endereco { get; set; }        
        public Gerente Gerente { get; set;}
    }
}
