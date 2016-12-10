using GalaSoft.MvvmLight;

namespace Evolyutsionika.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields and Properties
        string _SomeString;
        public string SomeString
        {
            get { return _SomeString; }
            set
            {
                if (value == _SomeString) return;
                _SomeString = value;
                RaisePropertyChanged(nameof(SomeString));
            }
        }
        #endregion

        public MainViewModel()
        {
            
        }
    }
}