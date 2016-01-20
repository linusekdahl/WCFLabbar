using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EcUtbildning.generatestuff
{
    //[ServiceContract(Namespace = "http://EcUtbildning.generatestuff")]
    //public interface IString
    //{
    //    [OperationContract]
    //    string mystuff(string stuff);
    //}

    [ServiceContract(Namespace = "http://EcUtbildning.generatestuff")]
    public interface IBMI
    {
        [OperationContract]
        int BMI(int a, int b);
    }

    //public class WriteThings : IString
    //{
    //    public string mystuff(string stuff)
    //    {
    //        Console.WriteLine("Writing things, i do that.");
    //        return stuff;
    //    }
    //}

    public class CalculateBMI : IBMI
    {
        public int BMI(int a, int b)
        {
            float height = a / 100f;
            float weight = b;

            float bmi = weight / (height * height);
            return (int)bmi;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Uri baseAdress = new Uri("http://localhost:8080/EcUtbildning.generatestuff");

            ServiceHost myServiceHost = new ServiceHost(typeof(CalculateBMI), baseAdress);

            try
            {
                //Endpoint
                myServiceHost.AddServiceEndpoint
                    (typeof(IBMI), //Contract hur vi ska prata med personen på andra sidan.
                    new BasicHttpBinding(), //Binding hur vi kopplar oss dit.
                    "generatestuff"); //Adress, hur vi hittar dit.

                //Metadata för att kunna hitta servicen via WSDL-document
                ServiceMetadataBehavior smbBehavior = new ServiceMetadataBehavior();
                smbBehavior.HttpGetEnabled = true; //här säger vi att metadata får hämtas av HTTP.
                myServiceHost.Description.Behaviors.Add(smbBehavior); //och här hämtar vi metadatan.

                //Starta hosten
                myServiceHost.Open();
                Console.WriteLine("Tjänsten är öppen!");

                //Håll den vid liv
                Console.WriteLine("Tryck på enter för att avsluta.");
                Console.ReadLine(); // håller projektet vid liv tills clienten trycker enter.
            }
            catch (Exception ex)
            {

                Console.WriteLine("It crashed (T_T) " + ex.Message);
                myServiceHost.Close();
                Console.ReadLine();
                throw;
            }
        }
    }
}
