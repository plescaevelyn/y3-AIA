using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace S4
{
    class Program
    {
        static string ds = @"Data Source=BENY-PC\SQLEXPRESS";
        static string db = "Initial Catalog=";
        static string ins = "Integrated Security=True";
        
        static void Main(string[] args)
        {
            CreareDB();
           // Fill_Jud();
            //Fill_Loc();
            Thread t = new Thread(DeleteJud);
            t.Start();
            Afis();
            Console.ReadKey();
        }

           static void CreareDB()
           {
            SqlConnection con = new SqlConnection(@ds + ";" + db + ";" + ins);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.CommandText = "CREATE DATABASE Romania2";
                cmd.ExecuteNonQuery();
                Console.WriteLine("Baza de date a fost creata!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                con.ChangeDatabase("Romania2");
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
                Console.WriteLine("Realatie creata!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            con.Close();

           }

           static void Fill_Jud()
           {
               SqlConnection con2 = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=Romania2; Integrated Security = True");
               Judete[] jud = new Judete[5];
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con2;
               con2.Open();

               for (int i = 0; i < jud.Length; i++)
               {
                   Console.WriteLine("id-ul judetului " + i + " : "); int id = int.Parse(Console.ReadLine());
                   Console.WriteLine("Denumirea judetului " + i + " : "); string den = Console.ReadLine();
                   Console.WriteLine("Suprafata judetului " + i + " : "); int supr = int.Parse(Console.ReadLine());

                   jud[i] = new Judete(id,den,supr);
                   cmd.CommandText = "INSERT INTO Judete(id,Denumire,Suprafata) VALUES('" + jud[i].id + "','" + jud[i].denumire + "','" + jud[i].suprafata + "')";
                   cmd.ExecuteNonQuery();
               }

               Console.WriteLine("Tabelul judete a fost populat!");
               con2.Close();
           }

           static void Fill_Loc()
           {
               SqlConnection con2 = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=Romania2; Integrated Security = True");
               Localitati[] loc = new Localitati[5];
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con2;
               con2.Open();

               SqlDataAdapter da = new SqlDataAdapter("SELECT id FROM Judete ", con2);
               DataSet ds = new DataSet();

               da.Fill(ds, "Jud");

               for (int i = 0; i < loc.Length; i++)
               {
                   Console.WriteLine("id-ul localitatii " + i + " : "); int id = int.Parse(Console.ReadLine());
                   Console.WriteLine("Denumirea localitatii " + i + " : "); string den = Console.ReadLine();
                   Console.WriteLine("Id-ul judetului " + i + " : "); int jud_fk = int.Parse(Console.ReadLine());

                   loc[i] = new Localitati(id, den, jud_fk);



                   bool match_id = false;
                   foreach (DataRow row in ds.Tables["Jud"].Rows)

                       if ((int)row["id"] == loc[i].Judete_FK)
                           match_id = true;
                   if (match_id == true)
                   {
                       cmd.CommandText = "INSERT INTO Localitati(id,Denumire,Judete_FK) VALUES('" + loc[i].id + "','" + loc[i].denumire + "','" + loc[i].Judete_FK + "')";
                       cmd.ExecuteNonQuery();
                   }
                   else Console.WriteLine("EROARE! Localitatile trebuie sa apartina de un judet existent!");
               }
               Console.WriteLine("Tabelul judete a fost populat!");
               con2.Close();



           }

           static void DeleteJud()
           {
               Console.WriteLine("Dati id-ul judetului: ");
               int idjud = int.Parse(Console.ReadLine());
               SqlConnection con2 = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=Romania2; Integrated Security = True");
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con2;
               con2.Open();
               string judname = "";
               SqlDataAdapter da = new SqlDataAdapter("SELECT id,Denumire FROM Judete ", con2);
               DataSet ds = new DataSet();

               da.Fill(ds, "Jud");
               bool match = false;
               foreach (DataRow row in ds.Tables["Jud"].Rows)

                   if (idjud == (int)row["id"])
                   { match = true; judname = row["Denumire"].ToString(); }

               if (match == true)
               {
                   cmd.CommandText = "Delete FROM Judete WHERE id=" + idjud + "";
                   cmd.ExecuteNonQuery();
                   Console.WriteLine("Judetul " + judname + " a fost sters");
               }

               else
                   Console.WriteLine("Judetul nu a fost gasit!");
               con2.Close();
           }

           static void Afis()
           {
               Console.WriteLine("Dati numele judetului: ");
               string namejud = Console.ReadLine();
               SqlConnection con2 = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=Romania2; Integrated Security = True");
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = con2;
               con2.Open();

               SqlDataAdapter da = new SqlDataAdapter("SELECT Judete.Denumire,Localitati.Denumire AS Den FROM Judete,Localitati WHERE Judete.id=Localitati.Judete_FK  AND  Judete.Denumire LIKE" + "'" + namejud + "'" + "", con2);
               DataSet ds = new DataSet();

               da.Fill(ds, "tab");

               Console.WriteLine("Localitatile din judetul " + namejud + " sunt: ");

               foreach (DataRow row in ds.Tables["tab"].Rows)

                   Console.WriteLine(row["Den"].ToString());
           }

       
    
    


    }
}
