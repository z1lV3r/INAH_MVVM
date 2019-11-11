using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class MeasuresDataService
    {
        public string GetMeasure(int id, string type)
        {
            using (var entities = new TempDataEntities())
            {
                var measures = entities.Measures.FirstOrDefault(measure => measure.TempId == id && measure.Type == type);
                return measures?.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void Upsert(int id, string type, float? value)
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
                measure.Value = (float) (value ?? 0F);
                entities.SaveChanges();
            }
        }
    }
}
