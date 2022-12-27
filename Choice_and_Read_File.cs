using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace PW_6
{
    internal class Choice_and_Read_File
    {
        public string Name;
        public string Parameter;
        public string Parameter2;
        static public List<Choice_and_Read_File> Data_Storage = new List<Choice_and_Read_File>();

        public Choice_and_Read_File(string Name, string Parameter, string Parameter2)
        {
            this.Name = Name;
            this.Parameter = Parameter;
            this.Parameter2 = Parameter2;
        }
        public Choice_and_Read_File()
        {
        }
        public static void GettingLink()
        {
            string b;
            Console.WriteLine("Введите путь вашего файла:\n");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("____________________________");
            Console.SetCursorPosition(0, 2);
            b = Console.ReadLine();
            Get_Data(b);
            Thread.Sleep(3000);
            Console.Clear();

        }
        static void Get_Data(string b)
        {
            if (b.Contains(".txt"))
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Формат вашего файла txt");
                Choice_and_Read_File storage_parameter_txt = new Choice_and_Read_File();
                string Name = File.ReadLines($"{b}").ElementAtOrDefault(0);
                storage_parameter_txt.Name = Name;
                Console.WriteLine(storage_parameter_txt.Name);

                string Parameter = File.ReadLines($"{b}").ElementAtOrDefault(1);
                storage_parameter_txt.Parameter = Parameter;
                Console.WriteLine(storage_parameter_txt.Parameter);

                string Parameter2 = File.ReadLines($"{b}").ElementAtOrDefault(2);
                storage_parameter_txt.Parameter2 = Parameter2;
                Console.WriteLine(storage_parameter_txt.Parameter2);
                Choice_and_Read_File.Data_Storage.Add(storage_parameter_txt);
                Thread.Sleep(2500);
            }
            else if (b.Contains(".json"))
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Формат вашего файла json");
                string storage_parameter_json = File.ReadAllText($"{b}");
                Data_Storage = JsonConvert.DeserializeObject<List<Choice_and_Read_File>>(storage_parameter_json);
                foreach (var item in Data_Storage)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Parameter);
                    Console.WriteLine(item.Parameter2);
                }
                Thread.Sleep(2500);
            }
            else if (b.Contains(".xml"))
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Формат вашего файла json");
                string storage_parameter_json = File.ReadAllText($"{b}");
                Data_Storage = JsonConvert.DeserializeObject<List<Choice_and_Read_File>>(storage_parameter_json);
                foreach (var item in Data_Storage)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Parameter);
                    Console.WriteLine(item.Parameter2);
                }
                Thread.Sleep(2500);
            }
        }
        public static void Read_File()
        {
            string file_path;
            Console.Clear();
            Console.WriteLine("Введите путь к вашему новому файлу");
            Console.SetCursorPosition(0, 3);
            file_path = Console.ReadLine();
            creating_addingInfo_about_pizza(file_path);
        }
        static void creating_addingInfo_about_pizza(string file_path)
        {
            File.Create($"{file_path}").Close();
            if (file_path.Contains(".txt"))
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Формат вашего нового файла -> txt");
                string file_txt = "";
                string enter__ = "\n";
                foreach (var item in Choice_and_Read_File.Data_Storage)
                {
                    file_txt += item.Name;
                    file_txt += enter__;
                    file_txt += item.Parameter;
                    file_txt += enter__;
                    file_txt += item.Parameter2;
                }
                File.WriteAllText($"{file_path}", file_txt);
                foreach (var item in Choice_and_Read_File.Data_Storage)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Parameter);
                    Console.WriteLine(item.Parameter2);
                }
                Thread.Sleep(2500);
            }
            else if (file_path.Contains(".json"))
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Формат вашего нового файла -> json");
                string file_json = JsonConvert.SerializeObject(Choice_and_Read_File.Data_Storage);
                File.AppendAllText($"{file_path}", file_json);
                Console.SetCursorPosition(0, 6);
                foreach (var item in Choice_and_Read_File.Data_Storage)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Parameter);
                    Console.WriteLine(item.Parameter2);
                }
                Thread.Sleep(2500);
            }
            else if (file_path.Contains(".xml"))
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Формат вашего нового файла -> xml");
                XmlSerializer file_xml = new XmlSerializer(typeof(List<Choice_and_Read_File>));
                using (FileStream file_stream = new FileStream($"{file_path}", FileMode.OpenOrCreate))
                {
                    file_xml.Serialize(file_stream, Choice_and_Read_File.Data_Storage);
                }
                foreach (var item in Choice_and_Read_File.Data_Storage)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Parameter);
                    Console.WriteLine(item.Parameter2);
                }
                Thread.Sleep(2500);
            }
        }
    }
}
