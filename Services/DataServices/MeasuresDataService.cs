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
    }
}
