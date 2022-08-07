using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.GerenteDto;
using FilmesApi.Models;
using FluentResults;
using System;
using System.Linq;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerentedto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerentedto;
            }
            return null;
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado!");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
