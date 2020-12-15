using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using System.Diagnostics;
namespace LogicGamesAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZapamietajNumerPage : ContentPage
    {
        string liczba;
        int pliczba;
        int wynik;
        Random rnd = new Random();
        Stopwatch timer = new Stopwatch();
        public ZapamietajNumerPage()
        {
            InitializeComponent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            Generate();
            StartButton.IsEnabled = false;
        }
        async void Generate()
        {

            timer.Start();
            AnswerEntry.Text = "";
            pliczba = rnd.Next(0, 10);
            liczba = liczba + pliczba.ToString();
            LiczbaLabel.Text = liczba;
            await Task.Delay(3000);
            AnswerEntry.IsEnabled = true;
            AnswerButton.IsEnabled = true;
            LiczbaLabel.Text = "Wpisz liczbę poniżej";      
        }

        private void AnswerButton_Clicked(object sender, EventArgs e)
        {
            AnswerEntry.IsEnabled = false;
            AnswerButton.IsEnabled = false;
            if (AnswerEntry.Text == liczba)
            {
                Generate();
            }
            else
            {
                wynik = liczba.Length;
                liczba = "";
                LiczbaLabel.Text = "Przegrałeś twój wynik to " + wynik;
                User user = new User();
                user.updateDateBase(wynik, "Zapamietaj Numer");
            }
        }
    }
}
