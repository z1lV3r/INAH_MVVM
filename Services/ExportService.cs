using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO.Compression;
using INAH.Models;
using INAH.Services.DataServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace INAH.Services
{
    public class ExportService
    {
        private PiecesDataService piecesDataService;
        private PieceDetailsDataService pieceDetailsDataService;
        private MeasuresDataService measuresDataService;
        private IdentifiersDataService identifiersDataService;
        public ExportService()
        {
            piecesDataService = new PiecesDataService();
            pieceDetailsDataService = new PieceDetailsDataService();
            measuresDataService = new MeasuresDataService();
            identifiersDataService = new IdentifiersDataService();
        }
        public void Export(int UserId)
        {
            string serializedDatabase;

            using (TempDataEntities entities = new TempDataEntities())
            {
                var pieces = entities.Pieces.ToList();

                serializedDatabase = JsonConvert.SerializeObject(pieces, Formatting.Indented,
                    new JsonSerializerSettings
                    { 
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CustomContractResolver()
                    });
            }

            //TODO: create file  with JSON

            //TODO: copy images

            //TODO: create zip
            ZipFile.CreateFromDirectory("", "");

            //TODO: copy in route with other extension

        }

        private class CustomContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var properties = base.CreateProperties(type, memberSerialization);

                if(Application.Current.FindResource("ColumnsExcluded") is IList<string> exclusion)
                    properties = properties.Where(p => !exclusion.Contains(p.PropertyName)).ToList();

                return properties;
            }
        }
    }

}