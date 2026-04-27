using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8_Video.DTO.Autor;
using WebAPI8_Video.DTO.LivroDto;
using WebAPI8_Video.Models;
using WebAPI8_Video.Services.Autor;
using WebAPI8_Video.Services.Livro;

namespace WebAPI8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

        public class LivroController : ControllerBase
        {
            private readonly ILivroInterface _livroInterface;
            public LivroController(ILivroInterface livroInterface)
            {
                _livroInterface = livroInterface;
            }

            [HttpGet("ListarLivros")]
            public async Task<ActionResult<responseModel<List<LivroModel>>>> ListarLivros()
            {
                var livros = await _livroInterface.ListarLivros();
                return Ok(livros);

            }

            [HttpGet("BuscarLivroPorId/{idLivro}")]
            public async Task<ActionResult<responseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
            {
                var livro = await _livroInterface.BuscarLivroPorId(idLivro);
                return Ok(livro);

            }

            [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
            public async Task<ActionResult<responseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
            {
                var livro = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
                return Ok(livro);

            }

            [HttpPost("Criarlivro")]

            public async Task<ActionResult<responseModel<List<LivroModel>>>> Criarlivro(LivroCriacaoDto livroCriacaoDto)
            {
                var livros = await _livroInterface.Criarlivro(livroCriacaoDto); 
                return Ok(livros);

            }

            [HttpPut("EditarLivro")]
            public async Task<ActionResult<responseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
            {
                var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
                return Ok(livros);

            }

            [HttpDelete("ExcluirLivro")]
            public async Task<ActionResult<responseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
            {
                var livros = await _livroInterface.ExcluirLivro(idLivro);
                return Ok(livros);

            }

        };
    }
