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
    public partial class ByloNieByloPage : ContentPage
    {
        string wylosowane = "";
        int pkt = 0;
        int x;
        Random rnd = new Random();
        List<string> WylosowaneSlowa = new List<string>();
        List<string> Slowa = new List<string>();
        bool bylo = false;
        public ByloNieByloPage()
        {
            InitializeComponent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {

            Slowa.Add("szaławiła");
            Slowa.Add("ladaco");
            Slowa.Add("wykidajło");
            Slowa.Add("basałyk");
            Slowa.Add("urwipołeć");
            Slowa.Add("melepeta");
            Slowa.Add("koafiura");
            Slowa.Add("wiktuały");
            Slowa.Add("ramota");
            Slowa.Add("humbug");
            Slowa.Add("monidło");
            Slowa.Add("blurb");
            Slowa.Add("prodiż");
            Slowa.Add("wszeteczeństwo");
            Slowa.Add("frymuśny");
            Slowa.Add("buńczuczny");
            Slowa.Add("ciekawy");
            Slowa.Add("ciekawski");
            Slowa.Add("ciekawostka");
            Slowa.Add("mały");
            Slowa.Add("mniejszy");
            Slowa.Add("malutki");
            Slowa.Add("małostkowy");
            Slowa.Add("klik");
            Slowa.Add("klikać");
            Slowa.Add("klikanie");
            Slowa.Add("klikał");
            Slowa.Add("nacisnął");
            Slowa.Add("długi");
            Slowa.Add("długa");
            Slowa.Add("długe");
            Slowa.Add("miasto");
            Slowa.Add("miasteczko");
            Slowa.Add("mieszczanin");
            Slowa.Add("wieś");
            Slowa.Add("buda");
            losuj();
            ByloButton.IsEnabled = true;
            NieByloButton.IsEnabled = true;
            StartButton.IsEnabled = false;
        }
        void losuj()
        {
            x = rnd.Next(0, Slowa.Count - 1);
            wordLabel.Text = Slowa[x];
            wylosowane = Slowa[x];
        }
        void check()
        {
            for (int i = 0; i < WylosowaneSlowa.Count; i++)
            {
                if (WylosowaneSlowa[i].Contains(wylosowane))
                {
                    bylo = true;
                }
            }
            if (!WylosowaneSlowa.Contains(Slowa[x]))
            {
                WylosowaneSlowa.Add(Slowa[x]);
            }
        }

        private void NieByloButton_Clicked(object sender, EventArgs e)
        {
            check();
            if (!bylo)
            {
                pkt++;
                losuj();
            }
            else
            {
                endgame();
            }
            bylo = false;
        }

        private void ByloButton_Clicked(object sender, EventArgs e)
        {
            check();
            if (bylo)
            {
                pkt++;
                losuj();
            }
            else
            {
                endgame();
            }
            bylo = false;
        }
        void endgame()
        {
            bylo = false;
            ByloButton.IsEnabled = false;
            NieByloButton.IsEnabled = false;
            StartButton.IsEnabled = true;
            wordLabel.Text = "przegrales " + pkt + " pkt.";
            WylosowaneSlowa.Clear();
            pkt = 0;
            User user = new User();
            user.updateDateBase(pkt, "Bylo Nie Bylo");
        }
    }
}