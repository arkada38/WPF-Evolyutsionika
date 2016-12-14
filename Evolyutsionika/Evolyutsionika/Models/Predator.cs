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
                Rectangle.Fill = brush;

                RaisePropertyChanged(nameof(FillColour));
            }
        }

        int _Health;
        public int Health
        {
            get { return _Health; }
            set
            {
                if (_Health == value) return;
                _Health = Math.Max(0, Math.Min(value, 100));

                Rectangle.Opacity = Health / 100.0;
                TextBlock.Text = _Health.ToString();

                RaisePropertyChanged(nameof(Health));
            }
        }

        Grid _Body;
        public Grid Body
        {
            get
            {
                if (_Body == null)
                {
                    _Body = new Grid();
                    _Body.Children.Add(Rectangle);
                    _Body.Children.Add(TextBlock);
                }
                return _Body;
            }
            set
            {
                if (value == _Body) return;
                _Body = value;
                RaisePropertyChanged(nameof(Body));
            }
        }

        Rectangle _Rectangle;
        private Rectangle Rectangle
        {
            get
            {
                if (_Rectangle == null)
                {
                    var brush = new SolidColorBrush();
                    brush.Color = Colors.DarkRed;

                    _Rectangle = new Rectangle();
                    _Rectangle.StrokeThickness = 4;
                    _Rectangle.Stroke = brush;

                    _Rectangle.RadiusX = 8;
                    _Rectangle.RadiusY = 8;
                }
                return _Rectangle;
            }
            set
            {
                if (value == _Rectangle) return;
                _Rectangle = value;
                RaisePropertyChanged(nameof(Rectangle));
            }
        }

        TextBlock _TextBlock;
        private TextBlock TextBlock
        {
            get
            {
                if (_TextBlock == null)
                {
                    _TextBlock = new TextBlock();
                    _TextBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    _TextBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                }
                return _TextBlock;
            }
            set
            {
                if (value == _TextBlock) return;
                _TextBlock = value;
                RaisePropertyChanged(nameof(TextBlock));
            }
        }
        #endregion
    }
}