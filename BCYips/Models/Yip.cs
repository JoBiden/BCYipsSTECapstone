using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BCYips.Models
{
    public class Yip
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int YipperID { get; set; }
        [Required, ForeignKey("YipperID")]
        public virtual Yipper Yipper { get; set; }

        public Yip ReYip { get; set; }

        public Yip ReplyTo { get; set; }

        [StringLength(140)]
        public string Content { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }
    }
}