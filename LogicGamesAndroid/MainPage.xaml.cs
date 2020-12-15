using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogicGamesAndroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isLoginNull = string.IsNullOrEmpty(Nick.Text);
            if (isLoginNull)
            {
                
            }
            else
            {
                User user = new User();
                user.CreateName(Nick.Text);
                Navigation.PushAsync(new MenuPage());
            }
        }
    }
}
