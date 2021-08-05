using System;

namespace Demo.Entities
{
    public abstract class Base
    {
        protected Base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}