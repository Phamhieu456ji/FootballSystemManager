using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FastConnectFootballSystem.Fields
{
    public class Field : Entity<Guid>
    {
        public string FieldName { get; set; }
        public string FieldStatus { get; set; }

        private Field() { }

        public static Field Create(string name, string status)
        {
            return new Field
            {
                Id = Guid.NewGuid(),
                FieldName = name,
                FieldStatus = status
            };
        }

        public void Update(string name, string status)
        {
            FieldName = name;
            FieldStatus = status;
        }
    }
}
