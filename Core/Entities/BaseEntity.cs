using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; } =
            Guid.NewGuid().ToString().Replace("-","");
    }
}