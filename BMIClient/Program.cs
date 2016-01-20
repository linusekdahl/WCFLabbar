using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace BMIClientz
{
    class Program
    {
        static void Main(string[] args)
        {
            BMIClient host = new BMIClient(); // proxy översätter 
            //så att jag tror att min klass TextFormatClient är i mitt projekt

            //Interfacet -> vårt projekt via proxy
            Console.WriteLine("Vad väger du?");
            int weight = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Hur lång är du?");
            int height = Int32.Parse(Console.ReadLine());


            int bmi = host.BMI(height, weight);
            Console.WriteLine("Ditt BMI är {0}", bmi);
            Console.ReadLine();
        }
    }
}
