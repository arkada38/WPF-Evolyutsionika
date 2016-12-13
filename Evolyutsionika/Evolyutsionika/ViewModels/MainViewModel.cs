using Evolyutsionika.Models;
using Evolyutsionika.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Evolyutsionika.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields and Properties
        private static readonly Random R = new Random(DateTime.Now.Millisecond);

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

        MainView _View;
        public MainView View
        {
            get { return _View; }
            set
            {
                if (value == _View) return;
                _View = value;
                RaisePropertyChanged(nameof(View));
                Field = View.Field;
            }
        }

        Grid _Field;
        public Grid Field
        {
            get { return _Field; }
            set
            {
                if (value == _Field) return;
                _Field = value;
                CreateField();
                RaisePropertyChanged(nameof(Field));
            }
        }

        ObservableCollection<Predator> _Predators;
        public ObservableCollection<Predator> Predators
        {
            get { return _Predators; }
            set
            {
                if (value == _Predators) return;
                _Predators = value;
                RaisePropertyChanged(nameof(Predators));
            }
        }

        ObservableCollection<Ellipse> _Cells;
        public ObservableCollection<Ellipse> Cells
        {
            get { return _Cells; }
            set
            {
                if (value == _Cells) return;
                _Cells = value;
                RaisePropertyChanged(nameof(Cells));
            }
        }
        #endregion

        public MainViewModel()
        {
            Predators = new ObservableCollection<Predator>
            {
                new Predator
                {
                    Left = 100, Top = 100, Health = 100, FillColour = "Green"
                },
                new Predator
                {
                    Left = 150, Top = 150, Health = 100, FillColour = "Red"
                }
            };
        }

        private void CreateField()
        {
            var n = 150;

            // Create Rows
            for (var i = 0; i < n; i++)
                Field.RowDefinitions.Add(new RowDefinition());

            // Create Columns
            for (var i = 0; i < n; i++)
                Field.ColumnDefinitions.Add(new ColumnDefinition());

            // Create Cells
            Cells = new ObservableCollection<Ellipse>();
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var blueBrush = new SolidColorBrush();
                    blueBrush.Color = Colors.LightBlue;

                    var ellipse = new Ellipse();
                    ellipse.Fill = blueBrush;
                    Grid.SetRow(ellipse, i);
                    Grid.SetColumn(ellipse, j);
                    Field.Children.Add(ellipse);
                    Cells.Add(ellipse);
                }
            }

            var timer = new Timer();

            timer.Elapsed += OnTimedEvent;
            timer.Interval = 10;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new Action(() =>
                    Cells[R.Next(0, Cells.Count)].Fill = new SolidColorBrush(Color.FromArgb(255, GetRandomByte(), GetRandomByte(), GetRandomByte()))
                    ));
        }

        private static byte GetRandomByte()
        {
            return (byte)R.Next(0, 256);
        }
    }
}