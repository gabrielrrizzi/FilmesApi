using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using System;
using System.Linq;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessaoPorId(int Id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == Id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return sessaoDto;
            }
            return null;
        }
    }
}
