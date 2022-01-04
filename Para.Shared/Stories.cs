using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Shared
{
    public class Stories
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string InvestigationType { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
