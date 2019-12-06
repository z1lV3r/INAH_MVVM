using INAH.Commands;
using INAH.Services;
using INAH.ViewModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INAH.ViewModels
{
    public class ItemDetailViewModel : BaseItemOpWindowViewModel
    {
        public static Guid viewId;
        public override Guid ViewId => viewId;
        private bool hasPrevious;
        public bool HasPrevious
        {
            get => hasPrevious;
            set { hasPrevious = value; NotifyPropertyChanged(); }
        }
        private bool hasNext;
        public bool HasNext
        {
            get => hasNext;
            set { hasNext = value; NotifyPropertyChanged(); }
        }

        private int actualListIndex;

        public RelayCommand PreviousItem { get; private set; }
        public RelayCommand NextItem { get; private set; }
        public ItemDetailViewModel() { }
        public ItemDetailViewModel(int id, int userId) : base(id, userId)
        {
            viewId = Guid.NewGuid();
            Title = "Detalle de elemento";
            PreviousItem = new RelayCommand(PreviousItemExec);
            NextItem = new RelayCommand(NextItemExec);
            actualListIndex =
                CollectionsViewModel.Items.IndexOf(
                    CollectionsViewModel.Items.First(item => item.Id.Equals(StockNumber)));
            HasPrevious = actualListIndex > 0;
            HasNext = actualListIndex < CollectionsViewModel.Items.Count - 1;
        }

        private void PreviousItemExec(object obj)
        {
            actualListIndex--;
            HasPrevious = actualListIndex > 0;
            HasNext = true;
            LoadData(CollectionsViewModel.Items[actualListIndex].Id);
        }

        private void NextItemExec(object obj)
        {
            actualListIndex++;
            HasPrevious = true;
            HasNext = actualListIndex < CollectionsViewModel.Items.Count - 1;
            LoadData(CollectionsViewModel.Items[actualListIndex].Id);
        }
    }
}
