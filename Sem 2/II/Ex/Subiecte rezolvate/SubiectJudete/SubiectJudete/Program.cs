using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading;

namespace SubiectJudete
{
    static class Program
    {
        static void Main()
        {
            Afisare();
            Console.ReadKey();
        }

        static void CreateDB() 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\Cursuri + Laburi\\II\\Subiecte rezolvate\\SubiectJudete\\SubiectJudete\\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand()
            {
                Connection = connection
            };

            try
            {
                connection.Open();
                cmd.CommandText = "CREATE DATABASE Romania";
                cmd.ExecuteNonQuery();

                Console.WriteLine("The database has been created!");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                connection.ChangeDatabase("Romania");
                cmd.CommandText = "CREATE TABLE [dbo].[Judete]([id] [int] PRIMARY KEY, [Denumire] [text] NOT NULL, [Suprafata] [int] NOT NULL )";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tabelul Judete a fost creat!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                cmd.CommandText = "CREATE TABLE [dbo].[Localitati]([id] [int] PRIMARY KEY, [Denumire] [text] NOT NULL, [Judete_FK] [int] NOT NULL)";
                cmd.ExecuteNonQuery();
             
                Console.WriteLine("Tabelul Localitati a fost creat!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                cmd.CommandText = "ALTER TABLE [dbo].[Localitati] ADD CONSTRAINT [FK_Judete_Localitati] FOREIGN KEY([Judete_FK]) REFERENCES [dbo].[Judete]([id]) ON DELETE CASCADE";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Relatie creata!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            connection.Close();
        }

        static void PopulareJudete()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\Cursuri + Laburi\\II\\Subiecte rezolvate\\SubiectJudete\\SubiectJudete\\Database1.mdf;Integrated Security=True";

            Judete[] jud = new Judete[5];

            SqlCommand cmd = new SqlCommand()
            {
                Connection = connection
            };

            connection.Open();

            for (int i = 0; i < jud.Length; i++)
            {
                Console.WriteLine("Id-ul judetului " + i + " : "); 
                int id = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Denumirea judetului " + i + " : "); 
                string denumire = Console.ReadLine();
                
                Console.WriteLine("Suprafata judetului " + i + " : "); 
                float suprafata = float.Parse(Console.ReadLine());
                
                Console.WriteLine("Densitatea judetului " + i + " : "); 
                float densitate = float.Parse(Console.ReadLine());
                
                jud[i] = new Judete(id, denumire, suprafata, densitate);

                cmd.CommandText = "INSERT INTO Judete(id,Denumire,Suprafata) VALUES('" + jud[i].ID + "','" + jud[i].Denumire + "','" + jud[i].Suprafata + "','" + jud[i].Densitatea + "')";
                cmd.ExecuteNonQuery();

            }
            
            Console.WriteLine("Tabelul judete a fost populat!");
            connection.Close();
        }

        static void PopulareLocalitati()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\Cursuri + Laburi\\II\\Subiecte rezolvate\\SubiectJudete\\SubiectJudete\\Database1.mdf;Integrated Security=True";

            Localitati[] loc = new Localitati[5];
            SqlCommand cmd = new SqlCommand()
            {
                Connection = connection
            };
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT id FROM Judete ", connection);
            DataSet ds = new DataSet();

            da.Fill(ds, "Jud");

            for (int i = 0; i < loc.Length; i++)
            {
                Console.WriteLine("id-ul localitatii " + i + " : ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Denumirea localitatii " + i + " : ");
                string denumire = Console.ReadLine();

                Console.WriteLine("Latitudinea localitatii " + i + " : ");
                float latitudine = float.Parse(Console.ReadLine());

                Console.WriteLine("Longitudinea localitatii " + i + " : ");
                float longitudine = float.Parse(Console.ReadLine());

                Console.WriteLine("Id-ul judetului " + i + " : ");
                int jud_fk = int.Parse(Console.ReadLine());

                Console.WriteLine("Suprafata localitatii " + i + " : ");
                float suprafata = float.Parse(Console.ReadLine());

                Console.WriteLine("Densitatea localitatii " + i + " : ");
                float densitate = float.Parse(Console.ReadLine());

                loc[i] = new Localitati(id, denumire, latitudine, longitudine, jud_fk, suprafata, densitate);

                bool match_id = false;
                foreach (DataRow row in ds.Tables["Jud"].Rows)

                    if ((int)row["id"] == loc[i].Judete_FK)
                        match_id = true;
                if (match_id == true)
                {
                    cmd.CommandText = "INSERT INTO Localitati(id,Denumire,Judete_FK) VALUES('" + loc[i].Id + "','" + loc[i].Denumire + "','" + loc[i].Latitudine + "','" + loc[i].Longitudine + "','" + loc[i].Judete_FK + "','" + loc[i].Suprafata + "','" + loc[i].Densitate + "')";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("EROARE! Localitatile trebuie sa apartina de un judet existent!");
                }
            }
            Console.WriteLine("Tabelul judete a fost populat!");

            connection.Close();
        }

        static void StergereJudete()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\Cursuri + Laburi\\II\\Subiecte rezolvate\\SubiectJudete\\SubiectJudete\\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand
            {
                Connection = connection
            };

            connection.Open();

            Console.WriteLine("Dati id-ul judetului: ");
            int idJudet = int.Parse(Console.ReadLine());

            string numeJudet = "";
            SqlDataAdapter da = new SqlDataAdapter("SELECT id, Denumire FROM Judete ", connection);
            DataSet ds = new DataSet();

            da.Fill(ds, "Jud");

            bool match = false;
            foreach (DataRow row in ds.Tables["Jud"].Rows)
            {
                if (idJudet == (int)row["id"])
                { 
                    match = true; 
                    numeJudet = row["Denumire"].ToString(); 
                }
            }

            if (match == true)
            {
                cmd.CommandText = "Delete FROM Judete WHERE id=" + idJudet + "";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Judetul " + numeJudet + " a fost sters");
            }
            else
            {
                Console.WriteLine("Judetul nu a fost gasit!");
            }

            connection.Close();
        }

        static void Afisare()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\Cursuri + Laburi\\II\\Subiecte rezolvate\\SubiectJudete\\SubiectJudete\\Database1.mdf;Integrated Security=True";

            SqlCommand cmd = new SqlCommand()
            { 
                Connection = connection
            };

            connection.Open();

            Console.WriteLine("Dati numele judetului: ");
            string numeJudet = Console.ReadLine();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Judete.Denumire, Localitati.Denumire AS Den FROM Judete,Localitati WHERE Judete.id=Localitati.Judete_FK  AND  Judete.Denumire LIKE" + "'" + numeJudet + "'" + "", connection);
            DataSet ds = new DataSet();

            da.Fill(ds, "tab");

            Console.WriteLine("Localitatile din judetul " + numeJudet + " sunt: ");

            foreach (DataRow row in ds.Tables["tab"].Rows)
                Console.WriteLine(row["Den"].ToString());
        }
    }
}