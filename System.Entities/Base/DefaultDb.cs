﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Entities.Base
{
    public class DefaultDb
    {

        [Key]
        public int Id { get; set; }

        public Guid UniqueId { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public DateTime LastUpdate { get; set; } = DateTime.MinValue;
        public DateTime DeleteDate { get; set; } = DateTime.MinValue;

        public virtual bool Validate()
        {

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this, null, null);

            bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            return isValid;

        }
    }
}
