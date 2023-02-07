using System.ComponentModel.DataAnnotations.Schema;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Enums;

namespace ProductTracking.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    [ForeignKey("EntryBy")]
    public Guid EntryById { get; set; }
    public User EntryBy { get; set; }
    public DateTime EntryDate { get; set; } = DateTime.Now;
    [ForeignKey("UpdatedBy")]
    public Guid? UpdatedById { get; set; }
    public User? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    public EnStatus Status { get; set; }
}
