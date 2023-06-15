using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            creareDB();
            creareTabele();
            Console.WriteLine("Introduceti 5 judete: ");
            int id_jud, rec2_jud, rec7_jud, sup_jud, dens_jud, id_loc, lat_loc, long_loc, jud_fk_loc, sup_loc, dens_loc;
            string den_jud, den_loc;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ID: ");
                id_jud = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Denumire: ");
                den_jud = Console.ReadLine().ToString();
                Console.WriteLine("Rec2002: ");
                rec2_jud = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Rec2007: ");
                rec7_jud = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Suprafata: ");
                sup_jud = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Densitate: ");
                dens_jud = Convert.ToInt32(Console.ReadLine());
                String mesaj = inserareTabel_Judet(id_jud, den_jud, rec2_jud, rec7_jud, sup_jud, dens_jud);
                if (mesaj == "1")
                {
                    Console.WriteLine("Judet inserat cu succes! Mai adaugati inca " + (4 - i) + " judete!");
                }
                else
                {
                    Console.WriteLine("Nu s-a putut insera! Mai incercati odata!");
                    i--;
                }
            }
            Console.WriteLine("Introduceti 5 localitati: ");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ID: ");
                id_loc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Denumire: ");
                den_loc = Console.ReadLine().ToString();
                Console.WriteLine("Latitudine: ");
                lat_loc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Longitudine: ");
                long_loc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Judet: ");
                jud_fk_loc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Suprafata: ");
                sup_loc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Densitate: ");
                dens_loc = Convert.ToInt32(Console.ReadLine());
                String mesaj = inserareTabel_Localitate(id_loc, den_loc, lat_loc, long_loc, jud_fk_loc, sup_loc, dens_loc);
                if (mesaj == "1")
                {
                    Console.WriteLine("Localitate inserata cu succes! Mai adaugati inca " + (4 - i) + " localitati!");
                }
                else if (mesaj == "error")
                {
                    Console.WriteLine("Trebuie introdusa o localitate existenta. Mai incercati!");
                    i--;
                }
                else
                {
                    Console.WriteLine("Nu s-a putut insera! Mai incercati odata!");
                    i--;
                }
            }
            
            Console.WriteLine("Introduceti ID-ul Judetului de sters: ");
            int id_jud_sters = Convert.ToInt32(Console.ReadLine());
            String message = stergereJudet(id_jud_sters);
            if (message == "1")
            {
                Console.WriteLine("S-a sters cu succes!");
            }
            else
            {
                Console.WriteLine("Eroare la stergere!");
            }

            Console.WriteLine("Introduceti numele judetului: ");
            String nume_jud = Console.ReadLine().ToString();
            Console.WriteLine("Localitatile din judetul " + nume_jud + " sunt:");
            afisareLocatitati(nume_jud);
            Console.ReadLine();

        }
        public static void creareDB()
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog= ";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myCon;
            cmd.CommandText = "CREATE DATABASE Romania";
            try
            {
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void creareTabele()
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Romania";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            try
            {
                myCon.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = myCon;
                com.CommandText = "CREATE TABLE[dbo].[Judete]([id] INT PRIMARY KEY, [denumire] CHAR(20) NOT NULL, [Rec2002] INT NOT NULL, [Rec2007] INT NOT NULL, [Suprafata] INT NOT NULL, [Densitate] INT NOT NULL)";
                com.ExecuteNonQuery();
                com.CommandText = "CREATE TABLE[dbo].[Localitati]([id] INT IDENTITY (1, 1) NOT NULL, [denumire] CHAR(20) NOT NULL, [latitudine] INT NOT NULL, [longitudine] INT NOT NULL, [Judete_fk] INT NOT NULL, [suprafata] INT NOT NULL, [densitate] INT NOT NULL, PRIMARY KEY CLUSTERED ([id] ASC))";
                com.ExecuteNonQuery();
                com.CommandText = "SET IDENTITY_INSERT Localitati ON";
                com.ExecuteNonQuery();
                com.CommandText = "ALTER TABLE [dbo].[Judete] ADD CONSTRAINT [FK_Judete_Localitati] FOREIGN KEY([id]) REFERENCES [dbo].[Localitati]([Judete_fk] ON DELETE CASCADE)";
                myCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static String inserareTabel_Judet(int id, String denumire, int Rec2002, int Rec2007, int Suprafata, int Densitate)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Romania";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            myCon.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = myCon;

            com.CommandText = "INSERT INTO Judete(id,denumire,Rec2002,Rec2007,Suprafata,Densitate) VALUES(@id,@denumire,@Rec2002,@Rec2007,@Suprafata,@Densitate)";
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@denumire", denumire);
            com.Parameters.AddWithValue("@Rec2002", Rec2002);
            com.Parameters.AddWithValue("@Rec2007", Rec2007);
            com.Parameters.AddWithValue("@Suprafata", Suprafata);
            com.Parameters.AddWithValue("@Densitate", Densitate);
            return com.ExecuteNonQuery().ToString();

        }
        public static String inserareTabel_Localitate(int id, String denumire, int latitudine, int longitudine, int Judete_fk, int suprafata, int densitate)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Romania";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            myCon.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = myCon;

            DataSet dsJudete = new DataSet();
            SqlDataAdapter daJudete = new SqlDataAdapter("SELECT id FROM Judete", myCon);
            daJudete.Fill(dsJudete, "Judete");
            bool judExists = false;

            foreach (DataRow dr in dsJudete.Tables["Judete"].Rows)
            {
                if (Convert.ToInt32(dr.ItemArray.GetValue(0)) == Judete_fk)
                {
                    judExists = true;
                }
            }
            if (judExists == true)
            {

                com.CommandText = "INSERT INTO Localitati(denumire,latitudine, longitudine, Judete_fk, suprafata, densitate) VALUES (@denumire,@latitudine, @longitudine, @Judete_fk, @suprafata, @densitate)";
                com.Parameters.AddWithValue("@denumire", denumire);
                com.Parameters.AddWithValue("@latitudine", latitudine);
                com.Parameters.AddWithValue("@longitudine", longitudine);
                com.Parameters.AddWithValue("@Judete_fk", Judete_fk);
                com.Parameters.AddWithValue("@suprafata", suprafata);
                com.Parameters.AddWithValue("@densitate", densitate);

                return com.ExecuteNonQuery().ToString();
            }
            else return "error";


        }
        public static String stergereJudet(int id)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Romania";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            myCon.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = myCon;
            com.CommandText = "DELETE FROM Judete WHERE id = @id";
            com.Parameters.AddWithValue("@id", id);

            SqlCommand comm = new SqlCommand();
            comm.Connection = myCon;
            comm.CommandText = "DELETE FROM Localitati WHERE Judete_fk = @jud_fk";
            comm.Parameters.AddWithValue("@jud_fk", id);

            //Console.WriteLine(com.ExecuteNonQuery().ToString() + comm.ExecuteNonQuery().ToString());

            if (Convert.ToInt32(com.ExecuteNonQuery()) >=0  && Convert.ToInt32(comm.ExecuteNonQuery().ToString()) >= 0)
                return "1";
            else return "0";
        }
        public static void afisareLocatitati(String nume_jud)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Romania";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            myCon.Open();

            DataSet dsLocalitati = new DataSet();
            SqlDataAdapter daLocalitati = new SqlDataAdapter("SELECT denumire FROM Localitati WHERE Judete_fk = " + nume_jud, myCon);
            daLocalitati.Fill(dsLocalitati, "Localitati");
            bool locExistst = false;

            foreach (DataRow dr in dsLocalitati.Tables["Localitati"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString().Length > 0)
                {
                    Console.WriteLine(dr.ItemArray.GetValue(0).ToString());

                    locExistst = true;
                }
            }
            if (locExistst == false)
            {
                Console.WriteLine("Nu exista localitati in acest judet!");
            }
        }
    }
}
