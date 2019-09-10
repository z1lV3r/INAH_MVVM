using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using INAH.Commands;
using INAH.Models;
using INAH.Services.DataServices;

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

        private PiecesDataService piecesDataService;
        public CollectionsViewModel() { }

        public CollectionsViewModel(int userId)
        {
            this.UserId = userId;
            piecesDataService = new PiecesDataService();
            
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
        }

        private string GetPath(int id)
        {
            var files = Directory.GetFiles(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"), id.ToString() + "*");
            return files.Length > 0 ? files.First() : "/Resources/Images/notFound.png";
        }


        public void AddCommandExec(object args)
        {
            navigatorService.NavigateToItemEdit(viewId, default, userId);
        }
    }
}
