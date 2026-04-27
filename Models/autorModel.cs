using System.Text.Json.Serialization;

namespace WebAPI8_Video.Models
{
    public class autorModel
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string Sobrenome { get; set; }
        [JsonIgnore]    
        public ICollection<LivroModel> Livros { get; set; }
    }
}
