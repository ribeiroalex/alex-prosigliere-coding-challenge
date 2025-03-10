﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            return Id == other?.Id;
        }
    }
}
