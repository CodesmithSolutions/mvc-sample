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
        [ForeignKey("CreatedBy")]
        public int CreatedByUserId { get; set; }
        [ForeignKey("AssignedTo")]
        public int? AssignedToUserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }

        public virtual UserEntity CreatedBy { get; set; }
        public virtual UserEntity AssignedTo { get; set; }
    }
}
