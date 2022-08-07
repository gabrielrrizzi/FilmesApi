using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesApi.FilmeProfile
{
    public class FilmeProfile:Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto,Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }

    }
}
