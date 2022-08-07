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
    public class EnderecoService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public IMapper Get_mapper()
        {
            return _mapper;
        }

        public List<ReadEnderecoDto> RecuperaEndereco(IMapper _mapper)
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            List<ReadEnderecoDto> readDto = _mapper.Map<List<ReadEnderecoDto>>(enderecos);
            return readDto;
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoNovoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _mapper.Map(enderecoNovoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
