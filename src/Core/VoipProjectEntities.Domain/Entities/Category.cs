using System;
using System.Collections.Generic;
using VoipProjectEntities.Domain.Common;

namespace VoipProjectEntities.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
