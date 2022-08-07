using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(object filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context
                    .Filmes.Where(filme => filme.classificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }
            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {            
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return filmeDto;
            }
            return null;
        }
        public Result AtualizaFilme(UpdateFilmeDto filmeNovoDto,int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmeNovoDto => filmeNovoDto.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(filmeNovoDto, filme);
            _context.SaveChanges();          ;
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado"); ;
            }
            _context.Remove(filme);
            _context.SaveChanges();            
            return Result.Ok(); 
        }
    }
}
