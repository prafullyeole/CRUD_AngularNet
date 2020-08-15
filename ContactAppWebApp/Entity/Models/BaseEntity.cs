using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
