using GalaSoft.MvvmLight;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Evolyutsionika.Models
{
    public class Predator : ViewModelBase
    {
        #region Fields and Properties
        int _Row;
        public int Row
        {
            get { return _Row; }
            set
            {
                if (value == _Row) return;
                _Row = value;
                Grid.SetRow(Body, value);
                RaisePropertyChanged(nameof(Row));
            }
        }

        int _Column;
        public int Column
        {
            get { return _Column; }
            set
            {
                if (value == _Column) return;
                _Column = value;
                Grid.SetColumn(Body, value);
                RaisePropertyChanged(nameof(Column));
            }
        }

        Color _FillColour;
        public Color FillColour
        {
            get { return _FillColour; }
            set
            {
                if (value == _FillColour) return;
                _FillColour = value;

                var brush = new SolidColorBrush();
                brush.Color = value;
                Body.Fill = brush;

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
                _Health = Math.Max(0, Math.Min(value, 100));
                Body.Opacity = Health / 100.0;
                RaisePropertyChanged(nameof(Health));
            }
        }

        Rectangle _Body;
        public Rectangle Body
        {
            get { return _Body ?? (_Body = new Rectangle()); }
            set
            {
                if (value == _Body) return;
                _Body = value;
                RaisePropertyChanged(nameof(Body));
            }
        }
        #endregion
    }
}