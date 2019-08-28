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
    }
}
