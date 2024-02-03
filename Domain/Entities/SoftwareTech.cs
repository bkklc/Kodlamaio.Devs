using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SoftwareTech : Entity
    {
        public int PLanguageId { get; set; }
        public string Name { get; set; }        
        public PLanguage PLanguage { get; set; }

        public SoftwareTech()
        {
            
        }

        public SoftwareTech(int id,int pLanguageId, string name) : this()
        {
            Id = id;
            PLanguageId = pLanguageId;
            Name = name;
           
        }
    }
}
