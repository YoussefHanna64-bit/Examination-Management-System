using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Core
{
	public class Subject
	{
		private List<Student> _students = new List<Student>();

		public string Name { get; }
		public Student[] EnrolledStudents => _students.ToArray();

		public Subject(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Subject name cannot be empty");
			}

			Name = name;
		}

		public void Enroll(Student student)
		{
			if (student is null)
			{
				throw new ArgumentNullException("Student cannot be null");
			}

			_students.Add(student);
		}

		public void NotifyStudents(string message)
		{
			Console.WriteLine($"Notifying students");
			Console.WriteLine($"{message}");

			foreach (Student s in _students)
			{
				s.OnExamStarted(message);
			}

		}

		public override bool Equals(object? obj)
		{
			if (obj is Subject other)
			{
				return Name == other.Name;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name);
		}
		
		public override string ToString()
		{
			return $"Subject Name: {Name}, Students: {_students.Count}]";
		}
	}
}
