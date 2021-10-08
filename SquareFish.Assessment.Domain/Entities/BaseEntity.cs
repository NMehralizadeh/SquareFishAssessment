using System;
namespace SquareFish.Assessment.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreateAt = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}