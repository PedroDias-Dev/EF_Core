﻿using System;
using Microsoft.AspNetCore.Mvc;
using EF_Core_Backend.Domains;
using EF_Core_Backend.Interfaces;
using EF_Core_Backend.Repositories;

namespace EF_Core_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos
                var produtos = _produtoRepository.Listar();

                //Verifico se existe produto cadastrado
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e os produtos cadastrados
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                //Cadastra mensagem de erro no dominio logErro
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie um e-mail para email@email.com informando"
                });
            }
        }

        // GET api/produtos/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busco o produto pelo Id
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifico se o produto foi encontrado
                //Caso não exista retorno NotFounf
                if (produto == null)
                    return NotFound();

                //Caso exista retorno Ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno 400 (Bad Request)
                return BadRequest(ex.Message);
            }
        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um novo produto
                _produtoRepository.Adicionar(produto);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/produtos/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                //Edita o produto
                _produtoRepository.Editar(produto);

                //Retorna Ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/produtos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Busca o produto pelo ID
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se produto existe
                if (produto == null)
                    return NotFound();

                //Caso exista deleta
                _produtoRepository.Remover(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}