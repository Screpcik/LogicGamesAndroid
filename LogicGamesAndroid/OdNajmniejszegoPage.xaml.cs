using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogicGamesAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OdNajmniejszegoPage : ContentPage
    {
        int liczba;
        int licznik = 0;
        Random rnd = new Random();
        List<int> liczby = new List<int>();
        Stopwatch stopwatch = new Stopwatch();
        public OdNajmniejszegoPage()
        {
            InitializeComponent();
        }
        void randomize()
        {
            for (int i = 0; i < 15; i++)
            {
                liczba = rnd.Next(0, 100);
                liczby.Add(liczba);
                numbersLabel.Text += liczba.ToString() + ", ";
                liczby.Sort();
            }
        }

        private void startButton_Clicked(object sender, EventArgs e)
        {
            randomize();
            sprawdzButton.IsEnabled = true;
            startButton.IsEnabled = false;
            stopwatch.Start();
        }

        private void sprawdzButton_Clicked(object sender, EventArgs e)
        {
            check();
            answerEntry.Text = "";
        }
        public bool check()
        {
            if (answerEntry.Text == liczby[licznik].ToString())
            {
                JustLabel.Text = "najs " + licznik;
                licznik++;
                if (licznik == 15)
                {
                    stopwatch.Stop();
                    long TimeElapsed = stopwatch.ElapsedMilliseconds;
                    JustLabel.Text = "Brawo wygrałeś zajęło Ci to:";
                    int wynik = (int)TimeElapsed / 1000;
                    numbersLabel.Text = wynik + " sekundy.";
                    liczby.Clear();
                    licznik = 0;
                    sprawdzButton.IsEnabled = false;
                    startButton.IsEnabled = true;
                    User user = new User();
                    user.updateDateBase(wynik, "Od Najmniejszego");
                }
                return true;
            }
            else
            {
                JustLabel.Text = "Wprowadziles zla liczbe";
                return false;
            }
        }
    }
}