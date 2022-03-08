using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*Задание
Необходимо написать программу в классе Program со следующим функционалом:

Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
Имя;
Фамилия;
Возраст;
Наличие питомца;
Если питомец есть, то запросить количество питомцев;
Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
Запросить количество любимых цветов;
Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
Корректный ввод: ввод числа типа int больше 0.
Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
Вызов методов из метода Main.*/
class MainClass
{
	public static void Main(string[] args)
	{

		(string Name, string LastName, int Age, bool Animals, int collors) NewUser = GetValues();
		pravilnostvvoda(ref NewUser.Name, ref NewUser.LastName, ref NewUser.Age, ref NewUser.Animals, ref NewUser.collors);
		string[] collorsmas = ShowColor(NewUser.collors);
		if (NewUser.Animals == false)
		{
			vivod(NewUser.Name, NewUser.LastName, NewUser.Age, collorsmas);
		}
		if (NewUser.Animals == true)
		{
			string[] nameAnimals = AnimalName(NewUser.Animals);
			vivod(NewUser.Name, NewUser.LastName, NewUser.Age, nameAnimals, collorsmas);
		}
	}



	public static (string Name, string LastName, int Age, bool Animals, int collors) GetValues()
	{
		(string Name, string LastName, int Age, bool Animals, int collors) User = ("", "", 0, false, 0);//Почему без инициализации не работает??
		Console.WriteLine("Введите имя:");
		User.Name = Console.ReadLine();
		Console.WriteLine("Введите фамилию:");
		User.LastName = Console.ReadLine();
		int intage;
		int asage = 3;
		Console.WriteLine("Введите возраст:");
		do
		{
			string age = Console.ReadLine();
			bool success = int.TryParse(age, out intage);
			if (success == true)
			{
				User.Age = intage;
				asage = intage;
			}
			else
			{
				Console.WriteLine("Введите возраст корректно:");

			}
		} while (!(User.Age == asage));

		Console.WriteLine("Есть ли у вас питомец да или нет?");
		string fd = "value";
		do
		{
			string ter = Console.ReadLine();
			if (ter == "Да" || ter == "да" || ter == "ДА")
			{
				User.Animals = true;
				fd = ter;
			}
			else if (ter == "нет" || ter == "Нет" || ter == "НЕТ" || ter == "НЕт")
			{
				User.Animals = false;
				fd = ter;
			}
			else
			{
				Console.WriteLine("Некорректный ответ введите занова ответ на вопрос есть ли у вас питомец да или нет?");
			}
		}
		while (!(fd == "Да" || fd == "да" || fd == "ДА" || fd == "нет" || fd == "Нет" || fd == "НЕТ" || fd == "НЕт"));


		int intcollorsq;
		int intfsk = 3;
		Console.WriteLine("Введите колличество любимых цветов:");

		do
		{
			string collorsq;
			collorsq = Console.ReadLine();
			bool successq = int.TryParse(collorsq, out intcollorsq);
			if (successq == true)
			{
				User.collors = intcollorsq;
				intfsk = intcollorsq;
			}
			else
			{
				Console.WriteLine("Введите колличество любимых цветов корректно:");
			}
		}
		while (!(intfsk == intcollorsq));

		return User;
	}

	public static string[] AnimalName(bool Animals)
	{
		int collicestvo;
		int intfsk = 3;
		Console.WriteLine("Введите колличество животных цифрами:");
		do
		{

			string collicestvoq;
			collicestvoq = Console.ReadLine();
			bool successq = int.TryParse(collicestvoq, out collicestvo);
			if (successq == true)
			{
				intfsk = collicestvo;
			}
			else
			{
				Console.WriteLine("Введите колличество животных корректно:");
			}
		} while (!(intfsk == collicestvo));

		string[] coll = new string[collicestvo];
		for (int i = 0; i < collicestvo; i++)
		{
			int j = i + 1;
			Console.WriteLine("Введите кличку {0} животного", j);
			coll[i] = Console.ReadLine();
		}
		return coll;
	}
	static string[] ShowColor(int collors)
	{
		string[] collorshow = new string[collors];
		for (int i = 0; i < collors; i++)
		{
			int j = i + 1;
			Console.WriteLine("Напишите свой любимый {0} цвет на английском с маленькой буквы", j);
			collorshow[i] = Console.ReadLine();
		}
		return collorshow;

	}
	static void pravilnostvvoda(ref string Name, ref string LastName, ref int Age, ref bool Animals, ref int collors)
	{
		do
		{
			if (Name == "")
			{
				Console.WriteLine("Введите корректное имя");
				Name = Console.ReadLine();
			}
		} while (Name == "");

		/*int Namenum;
		int Nsdas = 3;
		do
		{
			bool success = int.TryParse(Name, out Namenum);
			if (success == true)
			{
				Console.WriteLine("Введите имя корректно:");
				Name = Console.ReadLine();
			}
			else
            {
				break;
            }
		} while (true);*/
		do
		{
			if (LastName == "")
			{
				Console.WriteLine("Введите корректную фамилию");
				LastName = Console.ReadLine();
			}
		} while (LastName == "");


		if (Age <= 0)
		{
			int asage = 3;
			Console.WriteLine("Введите еще раз возраст:");
			do
			{
				string age = Console.ReadLine();
				bool success = int.TryParse(age, out Age);

				if (success == true && Age > 0)
				{
					asage = Age;
				}
				else
				{
					Console.WriteLine("Введите возраст корректно:");
				}
			} while (!(Age == asage));
		}
		if (collors <= 0)
		{
			int intcollorse = 3;
			Console.WriteLine("Введите еще раз колличество цветов:");
			do
			{
				string collorsw = Console.ReadLine();
				bool success = int.TryParse(collorsw, out collors);
				if (success == true && (collors > 0))
				{
					intcollorse = collors;

				}
				else
				{
					Console.WriteLine("Введите колличество цветов корректно:");
				}
			} while (!(collors == intcollorse));
		}

	}
	public static void vivod(string Name, string LastName, int Age, string[] collors)
	{
		Console.WriteLine(Name);
		Console.WriteLine(LastName);
		Console.WriteLine(Age);
		Console.WriteLine("У вас нет животных");
		foreach (string element in collors)
		{
			switch (element)
			{
				case "red":
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is red!");
					break;

				case "green":
					Console.BackgroundColor = ConsoleColor.Green;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is green!");
					break;
				case "cyan":
					Console.BackgroundColor = ConsoleColor.Cyan;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is cyan!");
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Yellow;
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Your color is yellow!");
					break;
			}
		}
	}
	public static void vivod(string Name, string LastName, int Age, String[] animals, string[] collors)
	{

		Console.WriteLine("Ваше имя {0}", Name);
		Console.WriteLine("Ваше фамилия {0}", LastName);
		Console.WriteLine("Ваше возраст {0}", Age);
		for (int i = 0; i < animals.Length; i++)
		{
			int j = i + 1;
			Console.WriteLine($"кличка вашего {j} животного {animals[i]} ");
		}
		foreach (string element in collors)
		{
			switch (element)
			{
				case "red":
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is red!");
					break;

				case "green":
					Console.BackgroundColor = ConsoleColor.Green;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is green!");
					break;
				case "cyan":
					Console.BackgroundColor = ConsoleColor.Cyan;
					Console.ForegroundColor = ConsoleColor.Black;

					Console.WriteLine("Your color is cyan!");
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Yellow;
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("Your color is yellow!");
					break;
			}
		}
	}
}






