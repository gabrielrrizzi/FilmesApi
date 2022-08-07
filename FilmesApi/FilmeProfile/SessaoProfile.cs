using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using System;

namespace FilmesApi.FilmeProfile
{
    public class SessaoProfile  : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao,ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorariodeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }

    }
}
