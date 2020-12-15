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
    public partial class CzasReakcjiPage : ContentPage
    {
        List<long> timesTested = new List<long>();
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        public CzasReakcjiPage()
        {
            InitializeComponent();
        }

        private async void ReactionButton_Clicked(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                timesTested.Add(stopwatch.ElapsedMilliseconds);
                ReactionButton.BackgroundColor = Color.Red;
                ReactionButton.Text = string.Format("Twój czas to {0} millisekund",
                                                       timesTested[timesTested.Count - 1]);
                if (timesTested.Count == 3)
                {
                    int suma = Convert.ToInt32(timesTested[0]) + Convert.ToInt32(timesTested[1]) + Convert.ToInt32(timesTested[2]);
                    int wynik = suma / 3;
                    await DisplayAlert("Osiągnąłeś czasy: " + String.Join(", ", timesTested.ToArray()),"Nieźle","OK");
                    User user = new User();
                    user.updateDateBase(wynik, "Czas Reakcji");
                }
            }
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            stopwatch.Reset();
            for (int i = 4; i > 0; --i)
            {
                ReactionButton.Text = i.ToString();
                Task.Delay(500).Wait();
                ReactionButton.IsEnabled = true;
            }
            ReactionButton.Text = "Wcisnij jak najszybciej gdy zrobi sie zielony";
            Task.Delay(random.Next(3000, 5000)).Wait();
            ReactionButton.BackgroundColor = Color.Green;
            ReactionButton.Text = "WCISNIJ TERAZ";
            stopwatch.Start();
        }
    }
}