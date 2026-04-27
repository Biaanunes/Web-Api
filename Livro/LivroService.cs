using Microsoft.EntityFrameworkCore;
using WebAPI8_Video.Data;
using WebAPI8_Video.DTO.Autor;
using WebAPI8_Video.DTO.LivroDto;
using WebAPI8_Video.Models;

namespace WebAPI8_Video.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;
        public Task<responseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<responseModel<LivroModel>> BuscarLivroPorIdAutor(int idLivro)
        {
            throw new NotImplementedException();
        }
        
        public async Task<responseModel<List<LivroModel>>> Criarlivro(LivroCriacaoDto livroCriacaoDto)
        {
            responseModel<List<LivroModel>> resposta = new responseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.autor.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado.";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    autor =  autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.autor).ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        

        public async Task<responseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
             responseModel<List<LivroModel>> resposta = new responseModel<List<LivroModel>>();

            try
            {
                var Livro = await _context.Livros.Include(a => a.autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.autor.Id);
              
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado.";
                    return resposta;
                }

              
                if (Livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de livro localizado.";
                    return resposta;
                }

                Livro.Titulo = livroEdicaoDto.Titulo;
                Livro.autor = autor;

                _context.Update(Livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                return resposta;    


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<responseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            responseModel<List<LivroModel>> resposta = new responseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado.";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";

                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<responseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }
    }
}
