using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace novelconvert.Models
{
    public class UserDBModel
    {
        //register user by username and password
        public UserModel UserRegister(string username, string password)
        {
            string connectionString = "server=localhost;userid=root;password=123456;database=novel";
            if (!UserExisting(username, password))
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        string insertData = "insert into user_infor(UserName,Password,Date_of_birth,Image_profile," +
                                            "Coin, Level, Experience, Type, Power, Nick_name) values "
                                            + "(@UserName, @Password, @Date_of_birth, @Image_profile, @Coin, @Level, @Experience, @Type, @Power, @Nick_name)";
                        MySqlCommand command = new MySqlCommand(insertData, connection);

                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Date_of_birth", "1993-11-11");
                        command.Parameters.AddWithValue("@Image_profile", "#");
                        command.Parameters.AddWithValue("@Coin", 100);
                        command.Parameters.AddWithValue("@Level", 1);
                        command.Parameters.AddWithValue("@Experience", 100);
                        command.Parameters.AddWithValue("@Type", "normal");
                        command.Parameters.AddWithValue("@Power", 100);
                        command.Parameters.AddWithValue("@Nick_name", "Lee");

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }

            return UserLogin(username, password);
        }
        //checking by username and password
        public bool UserExisting(string username, string password)
        {
            return UserLogin(username, password).fUsername == username; //true for exist user
        }
        //checking by only username
        public bool UserNameExistChecking(string username)
        {
            return UserLogin(username) != null; //true for exist username
        }
        //get user by username and password
        public UserModel UserLogin(string username, string password)
        {
            string query = "SELECT * FROM `user_infor` WHERE UserName ='" + username + "' and Password ='" + password + "'";
            MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=novel");

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            var reader = cmd.ExecuteReader();

            UserModel userNovel = new UserModel();
            if (reader.Read())
            {

                userNovel.fID = reader.GetString(0);
                userNovel.fUsername = reader.GetString(1);
                userNovel.fPassword = reader.GetString(2);
                userNovel.fDate_of_birth = reader.GetString(3);
                userNovel.fImage_profile = reader.GetString(4);

                userNovel.fCoin = Int32.Parse(reader.GetString(5));
                userNovel.fLevel = Int32.Parse(reader.GetString(6));
                userNovel.fExperience = Int32.Parse(reader.GetString(7));
                userNovel.fType = reader.GetString(8);
                userNovel.fPower = Int32.Parse(reader.GetString(9));
                userNovel.fNick_name = reader.GetString(4);
            }

            conn.Close();
            return userNovel;
        }
        //get user by username
        public UserModel UserLogin(string username)
        {
            string query = "SELECT * FROM `user_infor` WHERE UserName ='" + username + "'";
            MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=novel");

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            var reader = cmd.ExecuteReader();

            UserModel userNovel = new UserModel();
            if (reader.Read())
            {
                userNovel.fID = reader.GetString(0);
                userNovel.fUsername = reader.GetString(1);
                userNovel.fPassword = reader.GetString(2);
                userNovel.fDate_of_birth = reader.GetString(3);
                userNovel.fImage_profile = reader.GetString(4);

                userNovel.fCoin = Int32.Parse(reader.GetString(5));
                userNovel.fLevel = Int32.Parse(reader.GetString(6));
                userNovel.fExperience = Int32.Parse(reader.GetString(7));
                userNovel.fType = reader.GetString(8);
                userNovel.fPower = Int32.Parse(reader.GetString(9));
                userNovel.fNick_name = reader.GetString(4);
            }

            conn.Close();
            return userNovel;
        }
    }
}