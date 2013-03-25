using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Nokta.Models
{
    public class User
    {
        public int Id { get; set; }
        public int FBId { get; set; }
        public string Name { get; set; }
        public string ProfPic { get; set; }
        public string Profile { get; set; }
        public ICollection<Nokat> UserNokats { get; set; }
        public ICollection<Comments> UserComments { get; set; }
    }
}