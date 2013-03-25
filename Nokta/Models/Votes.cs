using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class Votes
    {
        [Key]
        public int VoteId { get; set; }
        public bool VoteValue { get; set; }

        
        
        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual User VotedUser { get; set; }

        
        public int NoktaId { get; set; }
        //[ForeignKey("NoktaId")]
        //public virtual Nokat CurrentNokta { get; set; }

    }
}