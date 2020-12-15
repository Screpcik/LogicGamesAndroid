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
    public partial class DzialaniaMatematycznePage : ContentPage
    {
        int FirstNumber;
        int SecondNumber;
        int wynikPunktowy;
        int wynik;
        Random rnd = new Random();
        Stopwatch stopwatch = new Stopwatch();
        public DzialaniaMatematycznePage()
        {
            InitializeComponent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            randomize();
            stopwatch.Start();
            answerButton.IsEnabled = true;
            StartButton.IsEnabled = false;
        }

        private void answerButton_Clicked(object sender, EventArgs e)
        {
            if (int.Parse(AnswerEntry.Text) == wynik)
            {
                AnswerEntry.Text = "";
                wynikPunktowy++;
                wynikLabel.Text = "Posiadasz " + wynikPunktowy.ToString() + "pkt.";
                randomize();
                answerLabel.Text = "Brawo dobra odpowiedź.";
            }
            else answerLabel.Text = "Niestety spróbuj ponownie.";
        }
        void randomize()
        {
            if (stopwatch.ElapsedMilliseconds < 45000)
            {
                FirstNumber = rnd.Next(0, 100);
                SecondNumber = rnd.Next(0, 100);
                wynik = FirstNumber + SecondNumber;
                DzialanieLabel.Text = FirstNumber.ToString() + " + " + SecondNumber.ToString();
            }
            else
            {
                stopwatch.Stop();
                wynikLabel.Text = "Koniec Gry. Uzyskałeś " + wynikPunktowy + " punktów.";
                wynik = 0;
                FirstNumber = -123;
                SecondNumber = -122;
                answerButton.IsEnabled = false;
                StartButton.IsEnabled = true;
                User user = new User();
                user.updateDateBase(wynikPunktowy, "Dzialania Matematyczne");
            }
        }
    }
}