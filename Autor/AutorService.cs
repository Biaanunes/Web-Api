using Microsoft.EntityFrameworkCore;
using WebAPI8_Video.Data;
using WebAPI8_Video.DTO.Autor;
using WebAPI8_Video.Models;

namespace WebAPI8_Video.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context; 
        public AutorService(AppDbContext context)
        {

        }

        public async Task<responseModel<List<autorModel>>> ListarAutores()
        {
            throw new NotImplementedException();
        }

        public async Task<responseModel<autorModel>> BuscarAutorPorId(int idAutor)
        {
          
            responseModel<autorModel> resposta = new responseModel<autorModel>();
            try
            {
               var autor  = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "nenhum registro localisado.";
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor Locazado";
                return resposta;
            }

            catch(Exception ex) 
             {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;


            }
        }

        public async Task<responseModel<autorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            responseModel<autorModel> resposta = new responseModel<autorModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.autor).FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado.";
                    return resposta;
                }

                resposta.Dados = livro.autor;
                resposta.Mensagem = "Autor Localizado.";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<responseModel<List<autorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            responseModel<List<autorModel>> resposta = new responseModel<List<autorModel>>();

            try
            {
                var autor = new autorModel()
                {
                    nome = autorCriacaoDto.nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor Criado com successo!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<responseModel<List<autorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            responseModel<List<autorModel>> resposta = new responseModel<List<autorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado.";
                    return resposta;
                }

                autor.nome = autorEdicaoDto.nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso!";

                return resposta;
                 

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<responseModel<List<autorModel>>> ExcluirAutor(int idAutor)
        {
            responseModel<List<autorModel>> resposta = new responseModel<List<autorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id ==  idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado.";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso!";

                return resposta;


            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

       
    }
}
