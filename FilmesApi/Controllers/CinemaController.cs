using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost] 
        public IActionResult AdicionaFilme([FromBody] CreateCinemaDto CinemaDto)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.AdicionaFilme(CinemaDto);            
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readCinemaDto.Id }, readCinemaDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readCinemaDtos = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if (readCinemaDtos != null)
            {
                return Ok(readCinemaDtos);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDto readCinemaDto = _cinemaService.RecuperaCinemaPorId(id);
            if (readCinemaDto != null)
            {
                return Ok(readCinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaNovoDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(cinemaNovoDto, id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
