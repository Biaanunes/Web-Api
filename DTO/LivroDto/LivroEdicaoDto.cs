using WebAPI8_Video.Models;

namespace WebAPI8_Video.DTO.LivroDto
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public autorModel autor { get; set; }
    }
}
