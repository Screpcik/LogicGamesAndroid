using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogicGamesAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : TabbedPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Opis Gier: \n\n",
                               "+ - Działania matematyczne:\n" +
                               "Rozwiąż poprawnie jak najwięcej działań w postaci sumy 2 liczb(0, 100) i uzyskaj jak najwięcej poprawnych odpowiedzi." +
                               "Po wpisaniu wyniku wciśnij enter.Wciśnij start by rozpocząć.\n\n" +

                               "Czas - Czas reakcji:\n" +
                               "Wciśnij przycisk na dole poczekaj od 3 do 5 sekund i po zaświeceniu się górnego przycisku na zielono naciśnij go najszybciej jak potrafisz " +
                               "i uzyskaj jak najniższy średni czas reakcji z 3 prób.Wciśnij dolny przycisk by rozpocząć.\n\n" +

                               "Myśl - Zapamiętaj numer:\n" +
                               "Zapamiętuj kolejne cyfry wyświetlane przez 3 sekundy i uzyskaj jak najdłuższą liczbę!Po wpisaniu liczby naciśnij enter. " +
                               "(Okno do wpisywania liczb jest nieaktywne podczas wyświetlania liczby) Wciśnij start by rozpocząć.\n\n" +

                               "123 - Od Najmniejszego:\n" +
                               "Ułóż liczby w kolejności od najmniejszej do największej w jak najkrótszym czasie!Po wpisaniu liczby naciśnij enter. " +
                               "Wciśnij start by rozpocząć.\n\n" +

                               "BNB - Bylo nie było:\n" +
                               "Zapamiętaj czy podane słowo już wystąpiło czy jeszcze nie i uzyskaj jak najwyższy wynik!Wciśnij start by rozpocząć.\n", 
                               "Rozumiem");
        }
    }
}