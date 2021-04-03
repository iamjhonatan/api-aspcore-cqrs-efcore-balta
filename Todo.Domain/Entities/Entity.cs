using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        // Método para comparação de entidades
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
