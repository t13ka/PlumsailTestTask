namespace Models
{
    using System;

    using Core;

    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public string Value { get; set; }
    }
}