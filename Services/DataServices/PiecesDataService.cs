using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class PiecesDataService
    {
        public void Delete(int id)
        {
        }

        public List<Pieces> FindAll()
        {
            using (TempDataEntities entities = new TempDataEntities())
            {
                return entities.Pieces.ToList();
            }
        }

        public void Upsert(Pieces pieces)
        {
            using (var dataEntities = new TempDataEntities())
            {
                var newPiece = new Pieces
                {
                    Subject = pieces.Subject, CreatedBy = pieces.CreatedBy, TempId = pieces.TempId
                };

                dataEntities.Pieces.Add(newPiece);
                
                dataEntities.SaveChanges();
            }
        }

        public Pieces Find(int id)
        {
            using (var dataEntities = new TempDataEntities())
            {
                return dataEntities.Pieces.FirstOrDefault(piece => piece.TempId == id) ?? 
                       new Pieces()
                       {
                           TempId = dataEntities.Pieces.ToList().Count > 0 ? dataEntities.Pieces.Max(table => table.TempId) : 1
                       };
            }
        }
    }
}
