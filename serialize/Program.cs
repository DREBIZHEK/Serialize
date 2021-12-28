using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
	class Human
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}

	class Student:Human
	{
		public int Year { get; set; }
	}

	class Worker:Human
	{
		public int Salary { get; set; }
	}

	class Child : Human
	{
		public int Height { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			var student = new Student { Age = 20, Name = "Александр", Year = 3 };
			var worker = new Worker { Age = 32, Name = "Петр", Salary = 20000 };
			var child = new Child { Age = 6, Name = "Владислав", Height = 120 };
			List<Human> humans = new List<Human>();
			humans.Add(student);
			humans.Add(worker);
			humans.Add(child);
			using (StreamWriter sw = new StreamWriter("Text.json"))
			{
				sw.WriteLine(JsonConvert.SerializeObject(humans));
				Console.WriteLine("Запись выполнена");
			}
			using (StreamReader sr = new StreamReader("Text.json"))
			{
				List<Human> restoredStudent = JsonConvert.DeserializeObject<List<Human>>(sr.ReadToEnd());
				foreach (var item in restoredStudent)
				{
					Console.WriteLine(item.Name);
				}
			}
			
		}

	}
}
