using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Shared
{
    public  class UserStory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Stories Story { get; set; }
        public int StoryId { get; set; }
    }
}
