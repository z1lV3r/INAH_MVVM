using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using INAH.Commands;
using INAH.Models;
using INAH.Services;
using INAH.Services.DataServices;
using Microsoft.Win32;

namespace INAH.ViewModels
{
    public class CollectionsViewModel : BaseWindowViewModel
    {
        public static Guid viewId;
        public static int userId;

        public override Guid ViewId => viewId;
        public int UserId { get => userId; set => userId = value; }
        public static ObservableCollection<CollectionsItemViewModel> Items { get; protected set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ExportCommand { get; set; }

        private PiecesDataService piecesDataService;
        private ExportService exportService;
        public CollectionsViewModel() { }

        public CollectionsViewModel(int userId)
        {
            this.UserId = userId;
            piecesDataService = new PiecesDataService();
            exportService = new ExportService();
            
            viewId = Guid.NewGuid();
            Title = "Colección";
            Items = new ObservableCollection<CollectionsItemViewModel>();
            foreach (var piece in piecesDataService.FindAll())
            {
                Items.Add(
                    new CollectionsItemViewModel(userId)
                    {
                        Id = piece.TempId,
                        Name = piece.Subject,
                        Image = GetPath(piece.TempId)
                });
            }
            AddCommand = new RelayCommand(AddCommandExec);
            CloseCommand = new RelayCommand(CloseCommandExec);
            ExportCommand = new RelayCommand(ExportCommandExec);
        }

        private string GetPath(int id)
        {
            var files = Directory.GetFiles(
                    Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"),
                    id.ToString() + "*")
                .Where(file =>
                    id.ToString().Equals(Path.GetFileNameWithoutExtension(file)) || Path.GetFileNameWithoutExtension(file).Contains("_")).ToArray();
            return files.Length > 0 ? files.First() : "/Resources/Images/notFound.png";
        }


        public void AddCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(viewId, default, userId);
        }

        public void CloseCommandExec(object args)
        {
            navigatorService.Close(viewId);
        }

        public void ExportCommandExec(object args)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "" +
                         "Inventory exported file" +
                         " (*.ief) |*.ief"
            };

            var result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                var path = dlg.FileName;
                exportService.Export(UserId, path);
            }
        }
    }
}
