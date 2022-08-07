using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Services;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
           _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);           
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
           List<ReadFilmeDto> readFilmeDto =  _filmeService.RecuperaFilmes(classificacaoEtaria);
           if(readFilmeDto != null)
            {
                return Ok(readFilmeDto);
            }
            return NotFound();
        }

        [HttpGet("{id}")] 
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperaFilmesPorId(id);
            if(readFilmeDto != null)
            {
                return Ok(readFilmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeNovoDto)
        {
            Result resultado = _filmeService.AtualizaFilme(filmeNovoDto,id);
            if(resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.DeletaFilme(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
