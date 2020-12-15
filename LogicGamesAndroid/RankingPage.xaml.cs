using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySqlConnector;
using System.Data;
using Xamarin.Forms.Xaml;
using MySqlConnector.Authentication;
namespace LogicGamesAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RankingPage : ContentPage
    {
        public RankingPage()
        {
            string connectionString = "server=logicgames.j.pl;uid=LogicGames;pwd=Log!cGame5;database=screpcik";
            string query = "SELECT * FROM ranking";
            MySqlDataAdapter da = new MySqlDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "ranking");
            InitializeComponent();
            dataGrid.ItemsSource = ds.Tables["ranking"].DefaultView;
            
            }
    }
    }