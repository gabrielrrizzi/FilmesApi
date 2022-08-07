using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.GerenteDto;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }
        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto dto)
        {
            ReadGerenteDto readGerenteDto = _gerenteService.AdicionaGerente(dto);          
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = readGerenteDto.Id }, readGerenteDto);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readGerenteDtos = _gerenteService.RecuperaGerentesPorId(id);
            if (readGerenteDtos != null)
            {                
                return Ok(readGerenteDtos);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _gerenteService.DeletaGerente(id);
            if(result.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
