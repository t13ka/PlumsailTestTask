namespace Api.Dto.Response
{
    using System;

    using Core;

    public class EntityResponse : IEntity
    {
        public Guid Id { get; set; }

        public string Value { get; set; }
    }
}