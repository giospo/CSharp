using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ArmasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Arma> lista = await _dataContext.Armas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Arma p = await _dataContext.Armas
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("O Dano não pode ser maior que 100! ");
                }
                await _dataContext.Armas.AddAsync(novaArma);
                await _dataContext.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                {
                    throw new Exception("O Dano não pode ser 0");
                }

                Personagem personagem = await _dataContext.Personagens
                                        .FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);
                if (personagem == null)
                    throw new System.Exception("Seu usuário não contém personagens com o Id do Personagem informado.");                       

                Arma buscaArma = await _dataContext.Armas
                    .FirstOrDefaultAsync(a => a.PersonagemId == novaArma.PersonagemId);
                if (buscaArma != null) 
                    throw new System.Exception("O Personage, selecionado já contém uma arma atribuida a ele.");                    
                
                await _dataContext.Armas.AddAsync(novaArma);
                await _dataContext.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("Danos não pode ser maior que 100!");
                }
                _dataContext.Armas.Update(novaArma);
                int linhasAfetadas = await _dataContext.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Arma pRemover = await _dataContext.Armas
                .FirstOrDefaultAsync(p => p.Id == id);

                _dataContext.Armas.Remove(pRemover);
                int linhasAfetadas = await _dataContext.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}