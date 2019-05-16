using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Entity;

namespace novelconvert.Models
{
    public class DBModel
    {
        
        public DbSet<NovelModel> Novels { get; set; }

        public void DBConnection(MySqlConnection conn, string database_name)
        {
            conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=" + database_name);
            conn.Open();
            
        }

        public void DBCloseConnection(MySqlConnection conn)
        {
            conn.Close();
        }

        public NovelModel GetMaxVoting()
        {
            List<NovelModel> Novel_List = AllNovel();

            int lMaxIndex = 0;
            for (int i = 1; i < Novel_List.Count(); i++)
            {
                lMaxIndex = (Novel_List[i].Voting > Novel_List[lMaxIndex].Voting) ? i : lMaxIndex;
            }

            return Novel_List[lMaxIndex];
        }

        public NovelModel SelectOneNovel(string id)
        {
            string query = "SELECT * FROM `novel_infor` WHERE Id='" + id + "'";
            MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=novel");

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            var reader = cmd.ExecuteReader();

            NovelModel readNovel = new NovelModel();
            if (reader.Read())
            {
                readNovel.Id = reader.GetString(0);
                readNovel.Name = reader.GetString(1);
                readNovel.Link = reader.GetString(2);
                readNovel.Author = reader.GetString(3);
                readNovel.Chap_number = Int32.Parse(reader.GetString(4));
                readNovel.Rating = Int32.Parse(reader.GetString(5));
                readNovel.Viewer = Int32.Parse(reader.GetString(6));
                readNovel.Voting = Int32.Parse(reader.GetString(7));
                readNovel.Recommandation = Int32.Parse(reader.GetString(8));
            }


            conn.Close();

            return readNovel;
        }

        public bool AddNewNovel(NovelModel nv)
        {
            string connectionString = "server=localhost;userid=root;password=123456;database=novel";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        string insertData = "insert into novel_infor(Name,Link,Author,Chap_number," +
                                            "Rating, Viewer, Voting, Recommandation, image_link) values "
                                            + "(@Name, @Link, @Author, @Chap_number, @Rating, @Viewer, @Voting,"
                                            + "@Recommandation, @image_link)";
                        MySqlCommand command = new MySqlCommand(insertData, connection);

                        command.Parameters.AddWithValue("@Name", nv.Name);
                        command.Parameters.AddWithValue("@Link", nv.Link);
                        command.Parameters.AddWithValue("@Author", nv.Author);
                        command.Parameters.AddWithValue("@Chap_number", nv.Chap_number);
                        command.Parameters.AddWithValue("@Rating", 0);
                        command.Parameters.AddWithValue("@Viewer", 0);
                        command.Parameters.AddWithValue("@Voting", 0);
                        command.Parameters.AddWithValue("@Recommandation", 0);
                        command.Parameters.AddWithValue("@image_link", nv.Image_link);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
            }

            return true;
        }

        public List<NovelModel> AllNovel()
        {
            string query = "SELECT * FROM `novel_infor` WHERE 1";
            MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=123456;database=novel");

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();

            var reader = cmd.ExecuteReader();

            List<NovelModel> lresult = new List<NovelModel>();
            int i = 0;
            while(reader.Read())
            {
                    NovelModel readNovel = new NovelModel();
                    readNovel.Id = reader.GetString(0);
                    readNovel.Name = reader.GetString(1);
                    readNovel.Link = reader.GetString(2);
                    readNovel.Author = reader.GetString(3);
                    readNovel.Chap_number = Int32.Parse(reader.GetString(4));
                    readNovel.Rating = Int32.Parse(reader.GetString(5));
                    readNovel.Viewer = Int32.Parse(reader.GetString(6));
                    readNovel.Voting = Int32.Parse(reader.GetString(7));
                    readNovel.Recommandation = Int32.Parse(reader.GetString(8));
                    //readNovel.Image_link = reader.GetString(9);

                    lresult.Add(readNovel);
                i++;
            }

            DBCloseConnection(conn);
         
            return lresult;
        }

        public bool EditNovel(NovelModel nv, NovelModel newNv)
        {
            string connectionString = "server=localhost;userid=root;password=123456;database=novel";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string insertData = "UPDATE novel_infor SET `Name`=@Name,"
                        + "`Link`=@Link,`Author`=@Author,"
                        + "`image_link`=@image_link WHERE id=@idold";
                    MySqlCommand command = new MySqlCommand(insertData, connection);
                    //select old novel
                    command.Parameters.AddWithValue("@idold", nv.Id);
                    //data updated
                    string name = (newNv.Name != null) ? newNv.Name : nv.Name; //checking null
                    command.Parameters.AddWithValue("@Name", name);

                    string Link = (newNv.Link != null) ? newNv.Link : nv.Link;
                    command.Parameters.AddWithValue("@Link", Link);

                    string Author = (newNv.Author != null) ? newNv.Author : nv.Author;
                    command.Parameters.AddWithValue("@Author", Author);

                    string Image_link = (newNv.Image_link != null) ? newNv.Image_link : nv.Image_link;
                    command.Parameters.AddWithValue("@image_link", newNv.Image_link);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public bool RemoveNovelById(string id)
        {
            string connectionString = "server=localhost;userid=root;password=123456;database=novel";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string insertData = "DELETE FROM novel_infor WHERE id=@id";
                    MySqlCommand command = new MySqlCommand(insertData, connection);
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }
    }
}