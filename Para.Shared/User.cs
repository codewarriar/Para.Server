using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Para.Shared
{
    public class User
    {

       
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual ICollection<Stories> Stories { get; set; }
    }
}
