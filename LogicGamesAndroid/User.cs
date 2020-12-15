using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace LogicGamesAndroid
{
    class User
    {
        string nazwa = "";
        int UserPoints;
        public void updateDateBase(int punkty, string gra)
        {
            GetUserPoints(nazwa, punkty, gra);
            string connectionString = "server=logicgames.j.pl;uid=LogicGames;pwd=Log!cGame5;database=screpcik";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM ranking WHERE (Nick = '" + nazwa + "' AND Gra = '" + gra + "')";
            int UserExist = Convert.ToInt32(cmd.ExecuteScalar());
            if (UserExist > 0 && punkty > UserPoints)
            {
                Console.WriteLine("Record exists");
                MySqlCommand updateUser = connection.CreateCommand();
                updateUser.CommandType = CommandType.Text;
                updateUser.CommandText = "UPDATE ranking " +
                                         "SET Punkty=" + punkty +
                                         " WHERE (Nick = '" + nazwa + "' AND Gra = '" + gra + "')";
                updateUser.ExecuteNonQuery();

            }
            else
            {
                Console.WriteLine("Record does not exist");
                MySqlCommand addUser = connection.CreateCommand();
                addUser.CommandType = CommandType.Text;
                addUser.CommandText = "INSERT INTO ranking " +
                                      "VALUES ('" + nazwa + "','" + punkty + "','" + gra + "')";
                addUser.ExecuteNonQuery();
            }
        }
        bool GetUserPoints(string nazwa, int punkty, string gra)
        {
            string connectionString = "server=logicgames.j.pl;uid=LogicGames;pwd=Log!cGame5;database=screpcik";
            MySqlConnection GETPKT = new MySqlConnection(connectionString);
            GETPKT.Open();
            MySqlCommand cmd = GETPKT.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Punkty FROM ranking WHERE (Nick = '" + nazwa + "' AND Gra = '" + gra + "')";
            UserPoints = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine(UserPoints);
            GETPKT.Close();
            return true;
        }
        public void CreateName(string nick)
        {
            nazwa = nick;   
        }
    }
}
