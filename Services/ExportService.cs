using System;
using System.Collections.Generic;
using System.IO;
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
        public void Export(int UserId, string path)
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

            var exportedDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exported");
            Directory.CreateDirectory(exportedDir);

            File.WriteAllText(Path.Combine(exportedDir, "data.json"), serializedDatabase);

            File.WriteAllText(Path.Combine(exportedDir, "CollectionTypes.json"), @"{""0"":""Arqueológico"",""1"":""Histórico"",""2"":""Paleontológico"",""3"":""Etnográfico"",""4"":""Contemporáneo""}");

            File.WriteAllText(Path.Combine(exportedDir, "ConservationTypes.json"), @"{""0"":""No requiere intervencion"",""1"":""Requiere intervencion"",""2"":""Requiere intervencion urgente"",""3"":""En riesgo""}");

            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images"), "*.*");

            var p = piecesDataService.FindAll();
            
            foreach (var file in files)
            {
                var name = new FileInfo(file).Name.Split('.')[0];
                if (p.Where(piece => name.Equals(piece.TempId.ToString())).ToList().Count > 0)
                {
                    var exported = Path.Combine(exportedDir, new FileInfo(file).Name);
                    File.Copy(file, exported, true);
                }
            }

            ZipFile.CreateFromDirectory(exportedDir, path);

            Directory.Delete(exportedDir, true);
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