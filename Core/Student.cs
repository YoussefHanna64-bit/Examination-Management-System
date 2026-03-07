using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Events;

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

		public void OnExamStarted(object sender, ExamEventArgs e)
		{
			Console.WriteLine($"{Name} is notified that the exam for {e.Subject.Name} has started");
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
