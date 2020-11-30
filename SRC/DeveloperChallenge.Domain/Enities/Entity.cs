using System;

namespace DeveloperChallenge.Domain.Enities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public DateTime CreatedAt { get; }
    }
}