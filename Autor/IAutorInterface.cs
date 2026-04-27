using WebAPI8_Video.DTO.Autor;
using WebAPI8_Video.Models;

namespace WebAPI8_Video.Services.Autor
{
    public interface IAutorInterface
    {
        Task<responseModel<List<autorModel>>> ListarAutores();
        Task<responseModel<autorModel>> BuscarAutorPorId(int idAutor);
        Task<responseModel<autorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<responseModel<List<autorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<responseModel<List<autorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<responseModel<List<autorModel>>> ExcluirAutor(int idAutor);
       
    }
}
