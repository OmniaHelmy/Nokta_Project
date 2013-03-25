using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class Nokat
    {
        [Key]
        public int NoktaId { get; set; }

        public int UserId { get; set; }
                [ForeignKey("UserId")]
        
        public virtual User NoktaOwner{ get; set; }
        [StringLength(200)]
        public string NoktaPost { get; set; }
        

    }
}