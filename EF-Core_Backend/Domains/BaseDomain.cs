using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Backend.Domains
{
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void setId(Guid id)
        {
            this.Id = id;
        }

    }
}