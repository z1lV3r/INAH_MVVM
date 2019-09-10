using System;
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
                newDetail.CoveredPieces = pieceDetails.CoveredPieces;
                newDetail.Type = pieceDetails.Type;
                newDetail.Author = pieceDetails.Author;
                newDetail.Period = pieceDetails.Period;
                newDetail.Culture = pieceDetails.Culture;
                newDetail.Origin = pieceDetails.Origin;
                newDetail.Shape = pieceDetails.Shape;
                newDetail.Inscriptions = pieceDetails.Inscriptions;
                newDetail.Description = pieceDetails.Description;
                newDetail.Remarks = pieceDetails.Remarks;
                newDetail.Collection = pieceDetails.Collection;
                newDetail.ConservationType = pieceDetails.ConservationType;
                newDetail.Valuation = pieceDetails.Valuation;
                newDetail.RawMaterial = pieceDetails.RawMaterial;
                newDetail.ManufacturingTechnique = pieceDetails.ManufacturingTechnique;
                newDetail.DecorativeTechnique = pieceDetails.DecorativeTechnique;
                newDetail.Provenance = pieceDetails.Provenance;
                newDetail.AcquisitionMethod = pieceDetails.AcquisitionMethod;
                newDetail.Location = pieceDetails.Location;
                if (newDetail.TempId == default)
                {
                    newDetail.TempId = pieceDetails.TempId;
                    dataEntities.Piece_Details.Add(newDetail);
                }
                dataEntities.SaveChanges();
            }

        }
    }
}
