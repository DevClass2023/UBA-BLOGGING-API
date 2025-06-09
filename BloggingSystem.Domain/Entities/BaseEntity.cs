using System;

namespace BloggingSystem.Domain.Entities;

// Base class for common entity properties
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}