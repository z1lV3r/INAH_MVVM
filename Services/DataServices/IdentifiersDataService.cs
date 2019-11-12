using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class IdentifiersDataService
    {
        public string GetIdentifier(int id, string type)
        {
            using (var entities = new TempDataEntities())
            {
                return entities.Identifiers.FirstOrDefault(identifier => identifier.TempId == id && identifier.Type == type)?.Value;
            }
        }

        public void Upsert(int id, string type, string value)
        {
            using (var entities = new TempDataEntities())
            {
                var identifier = entities.Identifiers.FirstOrDefault(i => i.TempId == id && i.Type == type);
                if (identifier == default)
                {
                    identifier = new Identifiers();
                    entities.Identifiers.Add(identifier);
                }
                identifier.TempId = id;
                identifier.Type = type;
                identifier.Value = value;
                entities.SaveChanges();
            }
        }

        public void Delete(int id, string type)
        {
            using (var entities = new TempDataEntities())
            {
                var identifiers = entities.Identifiers;
                var identifier = identifiers.FirstOrDefault(i => i.Type.Equals(type) && i.TempId.Equals(id));
                if (identifier != default)
                {
                    identifiers.Remove(identifier);
                    entities.SaveChanges();
                }
            }
        }
    }
}
