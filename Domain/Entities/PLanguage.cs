﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class PLanguage : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<SoftwareTech> SoftwareTeches { get; set; }

        public PLanguage()
        {
        }

        public PLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}