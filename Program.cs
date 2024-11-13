using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Seminar_8;

public class Program
{
	//------------------------------------------------------------------------------------------------------
	// Task 1 and related functions implementation
	/*
	public static void WriteTo(string str, string path)
	{
		using (FileStream fs = new FileStream(path, FileMode.CreateNew))
		{
			using StreamWriter sw = new StreamWriter(fs);
			sw.Write(str);
		}
	}

	public static string ReadFrom(string path)
	{
		using StreamReader sr = new StreamReader(path);
		return sr.ReadToEnd();
	}

	public static void Task1(string[] args)
	{
		foreach (var arg in args)
		{
			Console.WriteLine(arg);
		}
		string str = ReadFrom(args[0]);
		WriteTo(str, args[1]);
	}
	*/
	// end of Task 1
	//------------------------------------------------------------------------------------------------------
	// Task 2 and related functions implementation
	/*
	private static List<string> SearchIn(string path, string name)
	{
		var list=new List<string>();
		DirectoryInfo dir=new DirectoryInfo(path);
		var dirs=dir.GetDirectories();
		var files=dir.GetFiles();
		foreach (var _file in files)
		{
			if (_file.Name.Contains(name))
				list.Add(_file.Name);
			if (_file.Extension.Contains(name))
				list.Add(_file.Name);
		}
		foreach(var _dir in dirs)
		{
			list.AddRange(SearchIn(_dir.FullName, name));
		}
		return list;
	}

	public static void Task2(string[] args)
	{
		foreach (string arg in args)
		{
			Console.WriteLine(arg);
		}
		List<string> list = SearchIn(path: args[0], name: args[1]);
		Console.WriteLine(String.Join("\n", list));
	}
	*/
	// end of Task 2
	//------------------------------------------------------------------------------------------------------
	// Task 3 and related functions implementation
	/*
	const string path = "Program.cs";
	const string word = "List";

	public static List<string> ReadFrom(string path)
	{
		List<string> result = new List<string>();
		using (StreamReader sr = new StreamReader(path))
		{
			while(!sr.EndOfStream)
			{
				var line=sr.ReadLine();
				result.Add(line);
				// Console.WriteLine(line);
			}
		}
		return result;
	}

	public static List<string> Filter(string word, List<string> text)
	{
		return text.Where(a => a.ToLower().Contains(word.ToLower())).Select(x => x.ToLower().Replace(word.ToLower(), word.ToUpper())).ToList();
	}

	public static void Task3(string[] args)
	{
		Console.WriteLine(word);
		var text = ReadFrom(path);
		var filter = Filter(word, text);
		Console.WriteLine(String.Join("\n", filter));
	}
	*/
	// end of Task 3
	//------------------------------------------------------------------------------------------------------
	// Home work #8

	// Объедините две предыдущих работы (практические работы 2 и 3): поиск файла и поиск текста в файле написав
	// утилиту которая ищет файлы определенного расширения с указанным текстом. Рекурсивно. Пример вызова утилиты:
	// utility.exe txt текст.

	public static void SearchFileTypeNWord(string sDir, string fileExt, string fileTxt)
	{
		List<string> rLines = new List<string>();

		DirectoryInfo dirInfo = new DirectoryInfo(sDir);
		var files=dirInfo.GetFiles();
		var dirs=dirInfo.GetDirectories();
		foreach (var item in files)
		{
			if (item.Extension.Contains(fileExt))
			{
				using (StreamReader sr = new StreamReader(item.FullName))
				{
					while (!sr.EndOfStream)
					{
						rLines.Add(sr.ReadLine().ToLower());
					}
				}
				foreach (string str in rLines)
				{
					if (str.Contains(fileTxt.ToLower()))
						Console.WriteLine($"{item.FullName} : {str}");
				}
			}
		}
		foreach(var item in dirs)
			SearchFileTypeNWord(item.FullName, fileExt, fileTxt);

	}

	public static void HomeWork_8(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		string fileExt = args[0];
		string fileTxt = args[1];
		var curDir = Directory.GetCurrentDirectory();
		SearchFileTypeNWord(curDir, fileExt, fileTxt);
	}

	// end of Home work #8
	static void Main(string[] args)
	{
		// Task1(args);
		// Task2(args);
		// Task3(args);
		HomeWork_8(args);
	}
}
