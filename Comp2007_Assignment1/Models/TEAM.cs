namespace Comp2007_Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEAMS")]
    public partial class TEAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEAM()
        {
            PLAYERS = new HashSet<PLAYER>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TEAM_ID { get; set; }

        [StringLength(100)]
        public string TEAM_NAME { get; set; }

        [StringLength(100)]
        public string TEAM_CITY { get; set; }

        [StringLength(100)]
        public string TEAM_SPONSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAYER> PLAYERS { get; set; }
    }
}
