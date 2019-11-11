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
            using (var entities = new TempDataEntities())
            {
                entities.Pieces.Remove(entities.Pieces.First(p => p.TempId == id));
                entities.SaveChanges();
            }
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
            using (var entities = new TempDataEntities())
            {
                var piece = entities.Pieces.FirstOrDefault(p => p.TempId == pieces.TempId) ?? new Pieces();
                piece.Subject = pieces.Subject;

                if (piece.TempId == default)
                {
                    piece.TempId = pieces.TempId;
                    piece.CreatedBy = pieces.CreatedBy;
                    entities.Pieces.Add(piece);
                }

                entities.SaveChanges();
            }
        }

        public Pieces Find(int id)
        {
            using (var dataEntities = new TempDataEntities())
            {
                return dataEntities.Pieces.FirstOrDefault(piece => piece.TempId == id) ?? 
                       new Pieces()
                       {
                           TempId = dataEntities.Pieces.ToList().Count > 0 ? dataEntities.Pieces.Max(table => table.TempId) + 1: 1
                       };
            }
        }
    }
}
