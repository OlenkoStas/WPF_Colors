using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace HomeWorkColorViewer
{
    internal sealed class ViewModel:INotifyPropertyChanged
    {
        private MyColor _myColor = new MyColor();
        public MyColor MyColor
        {
            get => _myColor;
            set
            {
                if (!value.Equals(_myColor))
                {
                    _myColor = value;
                    OnPropertyChanged(nameof(MyColor));
                }
            }
        }
        
        public ObservableCollection<MyColor> Colors { get; set; }

        public ViewModel()
        {
            Colors = new ObservableCollection<MyColor>
            {
                new MyColor(100,197,0,226),
                new MyColor(100,255,0,0),
                new MyColor(100,255,255,0),
                new MyColor(100,0,0,255),
                new MyColor(100,76,218,101)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        // команда добавления нового объекта
        private MyCommand addCommand;
        public MyCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new MyCommand(obj =>
                  {
                      Colors.Insert(0,new MyColor(_myColor.Alpha, _myColor.Red, _myColor.Green, _myColor.Blue));
                  },
                  (obj) =>
                  {
                      return Colors.FirstOrDefault(c => c.MyColorHex == _myColor.MyColorHex) == null ? true : false;
                  }
                  ));
            }
        }
        // команда удаления объекта из списка
        private MyCommand delCommand;
        public MyCommand DelCommand
        {
            get
            {
                return delCommand ??
                  (delCommand = new MyCommand(obj =>
                  {
                      var hex = obj as string;
                      Colors.Remove(Colors.First(i => i.MyColorHex == hex));
                  }
                  ));
            }
        }
    }
}
