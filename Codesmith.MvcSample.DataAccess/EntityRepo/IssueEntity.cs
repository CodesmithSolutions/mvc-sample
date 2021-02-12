using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    [Table("Issue")]
    class IssueEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IssueId { get; set; }
        [StringLength(20)]
        public string Type { get; set; }
        [StringLength(20)]
        public string Priority { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        
        public int CreatedByUserId { get; set; }

        public int? AssignedToUserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }

        [ForeignKey("CreatedByUserId")]
        [InverseProperty("CreatedBy")]
        public virtual UserEntity CreatedBy { get; set; }

        [ForeignKey("AssignedToUserId")]
        [InverseProperty("AssignedTo")]
        public virtual UserEntity AssignedTo { get; set; }
    }
}
