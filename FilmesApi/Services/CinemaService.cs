using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaFilme(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);  
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();
            if (cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                        sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDto> readDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
            return readDto; 
        }

        public ReadCinemaDto RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }

        public Result AtualizaCinema(UpdateCinemaDto cinemaNovoDto, int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinemaNovoDto => cinemaNovoDto.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(cinemaNovoDto, cinema);
            _context.SaveChanges(); ;
            return Result.Ok();
        }

        internal Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Filme não encontrado"); ;
            }
            _context.Remove(cinema);
            _context.SaveChanges();            
            return Result.Ok();
        }
    }
}
