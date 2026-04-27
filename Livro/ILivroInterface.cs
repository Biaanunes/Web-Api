using WebAPI8_Video.DTO.Autor;
using WebAPI8_Video.DTO.LivroDto;
using WebAPI8_Video.Models;

namespace WebAPI8_Video.Services.Livro
{
    public interface ILivroInterface
    {
        Task<responseModel<List<LivroModel>>> ListarLivros();
        Task<responseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<responseModel<LivroModel>> BuscarLivroPorIdAutor(int idLivro);
        Task<responseModel<List<LivroModel>>> Criarlivro(LivroCriacaoDto livroCriacaoDto);
        Task<responseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        Task<responseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
