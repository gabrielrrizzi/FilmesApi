using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
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
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readEnderecoDto = _enderecoService.AdicionaEndereco(enderecoDto);           
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readEnderecoDto.Id }, readEnderecoDto);
        }

        [HttpGet]
        public IActionResult RecuperaEndereco()
        {
            List<ReadEnderecoDto> readEnderecoDtos = _enderecoService.RecuperaEndereco(_enderecoService.Get_mapper());
            return Ok(readEnderecoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto enderecoDto = _enderecoService.RecuperaEnderecoPorId(id);
            if(!(enderecoDto == null))
            {
                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoNovoDto)
        {
            Result resultado = _enderecoService.AtualizaEndereco(id, enderecoNovoDto);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _enderecoService.DeletaFilme(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return Ok();          
        }

    }


}
