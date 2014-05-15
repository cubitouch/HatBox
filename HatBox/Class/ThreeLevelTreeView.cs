using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace HatBox.Class
{
    public class Database : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        private bool _selectable;
        public bool Selectable
        {
            get
            {
                return _selectable;
            }
            set
            {
                _selectable = value;
                RaisePropertyChanged("Selectable");
                RaisePropertyChanged("CheckVisible");
            }
        }
        public Visibility CheckVisible
        {
            get
            {
                if (Selectable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public ObservableCollection<Table> Tables { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public class Table : INotifyPropertyChanged
    {
        public Table()
        {
            Selectable = true;
        }

        public string Name { get; set; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        private bool _selectable;
        public bool Selectable
        {
            get
            {
                return _selectable;
            }
            set
            {
                _selectable = value;
                RaisePropertyChanged("Selectable");
                RaisePropertyChanged("CheckVisible");
            }
        }
        public Visibility CheckVisible
        {
            get
            {
                if (Selectable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public Database ParentDatabase;
        public ObservableCollection<Column> Columns { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public class Column : INotifyPropertyChanged
    {
        public Column()
        {
            Selectable = true;
        }

        public string Name { get; set; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        private bool _selectable;
        public bool Selectable
        {
            get
            {
                return _selectable;
            }
            set
            {
                _selectable = value;
                RaisePropertyChanged("Selectable");
            }
        }
        public Visibility CheckVisible
        {
            get
            {
                if (Selectable)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }

        public Table ParentTable;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
