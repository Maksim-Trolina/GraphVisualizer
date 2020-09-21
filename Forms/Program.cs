using Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using CraphModel;

// подключаем FileStream 
using System.IO;
namespace StartForm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawForm());

            /*

            // создаём DataContractJsonSerializer:

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Graph));

            // создаёт поток:

            using (FileStream fs = new FileStream("d://1.json", FileMode.OpenOrCreate))
            {
                // сериализация (сохранение объекта в поток) 
                formatter.WriteObject(fs, object);
            }

            // открываем поток (json файл):

            using (FileStream fs = new FileStream("d://1.json", FileMode.OpenOrCreate))
            {
                // десериализация (создание объекта из потока):

                Book book2 = (Book)formatter.ReadObject(fs);

             
            }
            
             */
        }
    }
}
