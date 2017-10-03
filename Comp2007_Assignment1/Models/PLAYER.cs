namespace Comp2007_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PLAYERS")]
    public partial class PLAYER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JERSEY_NUMBER { get; set; }

        [StringLength(100)]
        public string PLAYER_NAME { get; set; }

        public decimal? POINTS_PER_GAME { get; set; }

        public decimal? REBOUNDS_PER_GAME { get; set; }

        public decimal? ASSISTS_PER_GAME { get; set; }

        public int? TEAM_ID { get; set; }

        public virtual TEAM TEAM { get; set; }
    }
}
