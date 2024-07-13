using System.Text.Json.Serialization;

namespace Login_Parol.Models
{
    public class User
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
