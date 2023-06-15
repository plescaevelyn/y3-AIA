using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ex2
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
       static Coada c = new Coada();
       static Stiva s = new Stiva();
      

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int[] InsertCoada(int i)
        {
           // this.val = val + 1;
            
             int[] vec = new int[100];

            c.PUSH(i);
            Elem_lista ptr = new Elem_lista(0);
            ptr = c.cap;
             int  k = 0;

             vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul; 
                

            }
            
            return vec  ;
        }

        [WebMethod]
        public int[] InsertStiva(int i)
        {
            int[] vec = new int[100];

            s.PUSH(i);
            Elem_lista ptr = new Elem_lista(0);
            ptr = s.cap;
            int k = 0;

            vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul;


            }

            

            return vec;
        }

        [WebMethod]
        public int[] DeleteFromStiva()
        {
            int[] vec = new int[100];

            s.POP();
            Elem_lista ptr = new Elem_lista(0);
            ptr = s.cap;
            int k = 0;

            vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul;

            }
            return vec;
        }

        [WebMethod]
        public int[] DeleteFromCoada()
        {
            int[] vec = new int[100];

            c.POP();
            Elem_lista ptr = new Elem_lista(0);
            ptr = c.cap;
            int k = 0;

            vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul;

            }
            return vec;
        }

        [WebMethod]
        public int[] ShowCoada()
        {
            int[] vec = new int[100];

           // c.POP();
            Elem_lista ptr = new Elem_lista(0);
            ptr = c.cap;
            int k = 0;

            vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul;

            }
            return vec;
        }

        [WebMethod]
        public int[] ShowStiva()
        {
            int[] vec = new int[100];

            // c.POP();
            Elem_lista ptr = new Elem_lista(0);
            ptr = s.cap;
            int k = 0;

            vec[k] = ptr.val;
            while (ptr.urmatorul != null)
            {
                k = k + 1;
                vec[k] = ptr.urmatorul.val;
                ptr = ptr.urmatorul;

            }
            return vec;
        }

        [WebMethod]
        public int[] sortCoada(int[] vec)
        {
            Array.Sort(vec);
            return vec;
        }

        [WebMethod]
        public int[] sortStiva(int[] vec)
        {
            Array.Sort(vec);
            return vec;
        }
        

      /*  [WebMethod]
        public Stiva SortareStiva(Stiva myStack)
        {
            return Stiva;
        }

        [WebMethod]
        public Coada SortareCoada(Coada myQueue)
        {

           
        }
        */
    }
}