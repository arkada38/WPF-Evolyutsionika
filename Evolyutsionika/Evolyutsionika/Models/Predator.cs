using GalaSoft.MvvmLight;

namespace Evolyutsionika.Models
{
    public class Predator : ViewModelBase
    {
        #region Fields and Properties
        double _Left;
        public double Left
        {
            get { return _Left; }
            set
            {
                if (value == _Left) return;
                _Left = value;
                RaisePropertyChanged(nameof(Left));
            }
        }

        double _Top;
        public double Top
        {
            get { return _Top; }
            set
            {
                if (value == _Top) return;
                _Top = value;
                RaisePropertyChanged(nameof(Top));
            }
        }

        string _FillColour;
        public string FillColour
        {
            get { return _FillColour; }
            set
            {
                if (value == _FillColour) return;
                _FillColour = value;
                RaisePropertyChanged(nameof(FillColour));
            }
        }

        int _Health;
        public int Health
        {
            get { return _Health; }
            set
            {
                if (value == _Health) return;
                _Health = value;
                RaisePropertyChanged(nameof(Health));
            }
        }
        #endregion
    }
}
