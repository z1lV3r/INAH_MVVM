namespace INAH.ViewModels
{
    public class CollectionsViewModel : ViewModelBase
    {
        public string User { get; set; }

        public CollectionsViewModel(string user)
        {
            User = user;
        }
    }
}
