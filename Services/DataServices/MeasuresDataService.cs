using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class MeasuresDataService
    {
        public float GetMeasure(int id, string type)
        {
            using (var entities = new TempDataEntities())
            {
                return entities.Measures.FirstOrDefault(measure => measure.TempId == id && measure.Type == type)?.Value ?? default;
            }
        }

        public void Upsert(int id, string type, float value)
        {
            using (var entities = new TempDataEntities())
            {
                var measure = entities.Measures.FirstOrDefault(m => m.TempId == id && m.Type == type);
                if (measure == default)
                {
                    measure = new Measures();
                    entities.Measures.Add(measure);
                }
                measure.TempId = id;
                measure.Type = type;
                measure.Value = value;
                entities.SaveChanges();
            }
        }
    }
}
