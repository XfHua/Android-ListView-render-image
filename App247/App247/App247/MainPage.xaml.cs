using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App247
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Libreria> items = new ObservableCollection<Libreria>(new Libreria().GetLibrerie());

        int a = 0;

        public MainPage()
        {
            InitializeComponent();

            lstLibrerie.ItemsSource = items;
            //pickerLibrerie.ItemsSource = new Libreria().GetLibrerie();           

            Device.StartTimer(TimeSpan.FromSeconds(8), () =>
            {


                Libreria a = new Libreria();
                a.Icona = "image.jpg";
                Reload(a);


                return true;
            });
        }

        public void Reload(Libreria newLib)
        {

            items.Insert(0, newLib);

        }
    }

    public class Libreria : INotifyPropertyChanged
    {

        public string DataUltimaApertura { get; set; }
        string _label;
        string _icon;


        public Libreria()
        {
        }

        public string Label
        {
            set
            {
                if (_label != value)
                {
                    _label = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Label"));
                    }
                }
            }
            get
            {
                return _label;
            }
        }


        public string Icona
        {
            set
            {
                if (_icon != value)
                {
                    _icon = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Icona"));
                    }
                }
            }
            get
            {
                return _icon;
            }
        }


        internal List<Libreria> GetLibrerie()
        {

            List<Libreria> items = new List<Libreria>();
            items.Add(new Libreria());

            return items;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
