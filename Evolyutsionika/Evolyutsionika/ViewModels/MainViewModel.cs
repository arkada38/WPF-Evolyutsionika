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
        private static readonly Random R = new Random(1);

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
                Field.SizeChanged += FieldSizeChanged;
            }
        }

        int _Rows = 100;
        public int Rows
        {
            get { return _Rows; }
            set
            {
                if (value == _Rows) return;
                _Rows = value;
                RaisePropertyChanged(nameof(Rows));
            }
        }

        int _Columns = 100;
        public int Columns
        {
            get { return _Columns; }
            set
            {
                if (value == _Columns) return;
                _Columns = value;
                RaisePropertyChanged(nameof(Columns));
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
        #endregion

        public MainViewModel()
        {
            Predators = new ObservableCollection<Predator>
            {
                new Predator { Row = R.Next(0, Rows), Column = R.Next(0, Columns), Health = 100, FillColour = Colors.Green },
                new Predator { Row = R.Next(0, Rows), Column = R.Next(0, Columns), Health = 50, FillColour = Colors.Green },
                new Predator { Row = R.Next(0, Rows), Column = R.Next(0, Columns), Health = 70, FillColour = Colors.Green },
                new Predator { Row = R.Next(0, Rows), Column = R.Next(0, Columns), Health = 30, FillColour = Colors.Green }
            };
        }

        #region Methods
        private void CreateField()
        {
            // Create Rows
            for (var i = 0; i < Rows; i++)
                Field.RowDefinitions.Add(new RowDefinition());

            // Create Columns
            for (var i = 0; i < Columns; i++)
                Field.ColumnDefinitions.Add(new ColumnDefinition());

            // Draw Predators
            foreach (var predator in Predators)
            {
                Field.Children.Add(predator.Body);
            }

            var timer = new Timer();

            timer.Elapsed += OnTimedEvent;
            timer.Interval = 500;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new Action(() =>
                    {
                        var predator = Predators[R.Next(0, Predators.Count)];
                        predator.Row = R.Next(0, Rows);
                        predator.Column = R.Next(0, Columns);
                    }
                    ));
        }

        private int GetCellIndex(int row, int column)
        {
            while (row >= Rows)
                row -= Rows;
            while (row < 0)
                row += Rows;

            while (column >= Rows)
                column -= Rows;
            while (column < 0)
                column += Rows;

            return column * Rows + row;
        }

        private void FieldSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Rows = (int)Field.ActualHeight / 20;
            Field.RowDefinitions.Clear();

            Columns = (int)Field.ActualWidth / 20;
            Field.ColumnDefinitions.Clear();
            
            // Create Rows
            for (var i = 0; i < Rows; i++)
                Field.RowDefinitions.Add(new RowDefinition());

            // Create Columns
            for (var i = 0; i < Columns; i++)
                Field.ColumnDefinitions.Add(new ColumnDefinition());

            // TODO: Переместить хищников
        }
        #endregion
    }
}