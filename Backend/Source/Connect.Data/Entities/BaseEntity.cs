using System;

namespace Connect.Data.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset? Created { get; set; }

        public DateTimeOffset? Modified { get; set; }
    }
}