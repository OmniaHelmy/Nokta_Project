using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }
        public int UserId{ get; set; }
        //public virtual User CommentOwner { get; set; }
        public int NoktaId { get; set; }
        //public virtual Nokat ParentNokta { get; set; }
        public string CommentPost { get; set; }

    }
}