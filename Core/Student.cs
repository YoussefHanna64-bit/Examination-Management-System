using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Core
{
	public class Student
	{
		private int _id;
		private string _name = string.Empty;

		public int Id
		{
			get => _id;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Student Id must be positive");
				}
				_id = value;
			}
		}

		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Student name cannot be empty");
				}
				_name = value;
			}
		}

		public Student(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public void OnExamStarted(string message)
		{
			Console.WriteLine($"{Name} is notified");
		}

		public override bool Equals(object? obj)
		{
			if (obj is Student other)
			{
				return Id == other.Id && Name == other.Name;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name);
		}
		
		public override string ToString()
		{
			return $"Student Id: {Id}, Name: {Name}";
		}
	}
}
