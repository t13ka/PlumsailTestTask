namespace Api.Dto.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Core;

    using Newtonsoft.Json;

    public class CreateEntityRequest : IEntity
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}