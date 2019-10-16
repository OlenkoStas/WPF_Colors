using System;
using System.ComponentModel;
using System.Windows.Media;

namespace HomeWorkColorViewer
{
    internal sealed class MyColor: INotifyPropertyChanged
    {
        private byte _alpha;
        private byte _red;
        private byte _green;
        private byte _blue;
        private string _colorHex;
        //Конструктор по умолчанию
        public MyColor(byte alpha = 100, byte red = 0, byte green = 0, byte blue = 0)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
            GetColorHex();
        }

        public byte Alpha
        {
            get => _alpha;
            set
            {
                if (value !=_alpha )
                {
                    _alpha = value;
                    GetColorHex();
                    OnPropertyChanged(nameof(Alpha));
                }
            }
        }
        public byte Red
        {
            get => _red;
            set
            {
                if (value != _red)
                {
                    _red = value;
                    GetColorHex();
                    OnPropertyChanged(nameof(Red));
                }
            }
        }
        public byte Green
        {
            get => _green;
            set
            {
                if (value != _green)
                {
                    _green = value;
                    GetColorHex();
                    OnPropertyChanged(nameof(Green));
                }
            }
        }
        public byte Blue
        {
            get => _blue;
            set
            {
                if (value != _blue)
                {
                    _blue = value;
                    GetColorHex();
                    OnPropertyChanged(nameof(Blue));
                }
            }
        }
        public string MyColorHex
        {
            get => _colorHex;
            set
            {
                if (!value.Equals(_colorHex))
                {
                    _colorHex = value;
                    OnPropertyChanged(nameof(MyColorHex));
                }
            }
        }
        /// <summary>
        /// Создает Hex фрмат цвета
        /// </summary>
        private void GetColorHex()
        {
            MyColorHex = Color.FromArgb(((byte)Math.Round(Alpha * 2.55)), Red, Green, Blue).ToString();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
