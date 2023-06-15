using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Subiect11
{
    public interface FiguriGeometrice
    {
        double Arie();
        double Perim();
    }
    [Serializable]
    public class dreptunghi : FiguriGeometrice
    {
        public int lungime1,lungime2;
        public dreptunghi(int lungime1,int lungime2)
        {
            this.lungime1 = lungime1;
            this.lungime2 = lungime2;
        }
        public dreptunghi(int lungime)
        {
            this.lungime1 = lungime;
            this.lungime2 = lungime;
        }
        public double Arie()
        {
            return lungime1*lungime2;
        }
        public double Perim()
        {
            return 2 * lungime1 + 2 * lungime2;
        }
    }
    [Serializable]
    public class cerc : FiguriGeometrice
    {
        double raza;
        int lungime;
        public cerc(double raza)
        {
            this.raza = raza;
            this.lungime = 0;
        }
        public cerc(int lungime)
        {
            this.lungime = lungime;
            this.raza = 0;
        }
        public double getRadius()
        {
            if (lungime != 0)
                return lungime / 2 / 3.14;
            return raza;
        }
        public double Arie()
        {
            return 3.14 * getRadius() * getRadius();
        }
        public double Perim()
        {
            return lungime;
        }
    }
    [Serializable]
    public class Program
    {
        public void sortCircles(cerc[] cerc)
        {
            for(int i=0;i<cerc.Length-1;i++)
                for(int j=i+1;j<cerc.Length;j++)
                {
                    if(cerc[i].getRadius()>cerc[j].getRadius())
                    {
                        cerc aux = cerc[i];
                        cerc[i] = cerc[j];
                        cerc[j] = aux;
                    }
                }

        }
        public static void Main(String[] args)
        {
            dreptunghi[] dr = new dreptunghi[10];
            cerc[] cr= new cerc[10];
            dr[0]=new dreptunghi(2, 3);
            dr[1]=new dreptunghi(3, 3);
            dr[2]=new dreptunghi(5, 3);
            dr[3]=new dreptunghi(1, 4);
            dr[4]=new dreptunghi(6, 10);
            dr[5]=new dreptunghi(3);
            dr[6]=new dreptunghi(6);
            dr[7]=new dreptunghi(1);
            dr[8]=new dreptunghi(10);
            dr[9]=new dreptunghi(8);

            cr[0]=new cerc(2.0);
            cr[1]=new cerc(7.4);
            cr[2]=new cerc(1.0);
            cr[3]=new cerc(3.5);
            cr[4]=new cerc(2.1);
            cr[5]=new cerc(5);
            cr[6]=new cerc(1);
            cr[7]=new cerc(3);
            cr[8]=new cerc(9);
            cr[9]=new cerc(2);
            Program program = new Program();
            program.sortCircles(cr);
            for(int i=0;i<10;i++)
            Console.WriteLine("cerc"+" "+i+" "+cr[i].getRadius());
            FileStream fs = new FileStream("C:\\Users\\hp f2v65ea\\Desktop\\Subiecte_rezolvate\\Subiect11\\fisier.txt", FileMode.Create);
            Hashtable lista = new Hashtable();
            for (int i=0;i<10;i++)
            {
                lista.Add(i,cr[i]);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, lista);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw e;
            }
            finally
            {
                fs.Close();
            }

            FileStream fs1 = new FileStream("C:\\Users\\hp f2v65ea\\Desktop\\Subiecte_rezolvate\\Subiect11\\fisier.txt", FileMode.Open);
            try
            {
                BinaryFormatter formatter1 = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                lista = (Hashtable)formatter1.Deserialize(fs1);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs1.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            foreach (DictionaryEntry de in lista)
            {
                Console.WriteLine("{0} lives at {1}.{0}", de.Key, de.Value);
            }
            Console.ReadKey();
        }
    }
}
