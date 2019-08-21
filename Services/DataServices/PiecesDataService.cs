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
                var newPiece = dataEntities.Pieces.FirstOrDefault(piece => piece.TempId == pieces.TempId) ?? new Pieces();
                //TODO: map properties
                if (newPiece.TempId == default) dataEntities.Pieces.Add(newPiece);
                dataEntities.SaveChanges();
            }
        }

        public Pieces Find(int id)
        {
            using (var dataEntities = new TempDataEntities())
            {
                return dataEntities.Pieces.FirstOrDefault(piece => piece.TempId == id);
            }
        }
    }
}
