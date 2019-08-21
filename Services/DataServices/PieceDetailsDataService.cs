using System.Linq;
using INAH.Models;

namespace INAH.Services.DataServices
{
    public class PieceDetailsDataService
    {
        public Piece_Details Find(int id)
        {
            using (var entities = new TempDataEntities())
            {
                return entities.Piece_Details.FirstOrDefault(detail => detail.TempId == id) ?? new Piece_Details();
            }
        }

        public void Upsert(Piece_Details pieceDetails)
        {
            using (var dataEntities = new TempDataEntities())
            {
                var newDetail = dataEntities.Piece_Details.FirstOrDefault(detail => detail.TempId == pieceDetails.TempId) ?? new Piece_Details();
                //TODO: map properties
                if (newDetail.TempId == default) dataEntities.Piece_Details.Add(newDetail);
                dataEntities.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
