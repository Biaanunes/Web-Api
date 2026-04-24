namespace WebAPI8_Video.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required autorModel autor { get; set; }

    }
}
