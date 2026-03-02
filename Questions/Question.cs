using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;

namespace C__Project.Questions
{
	public abstract class Question
	{
		private string _header = string.Empty;
		private string _body = string.Empty;
		private int _marks;

		public string Header
		{
			get => _header;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Header cannot be empty");
				}

				_header = value;
			}
		}

		public string Body
		{
			get => _body;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Body cannot be empty");

				}
				_body = value;
			}
		}

		public int Marks
		{
			get => _marks;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Marks must be bigger than zero");
				}

				_marks = value;
			}
		}

		public AnswerList Answers { get; protected set; }
		public Answer? CorrectAnswer { get; protected set; }

		protected Question(string header, string body, int marks, AnswerList answers, Answer? correctAnswer)
		{
			Header = header;
			Body = body;
			Marks = marks;
			Answers = answers ?? throw new ArgumentNullException("Answers cannot be null");
			CorrectAnswer = correctAnswer;
		}

		public abstract void Display();
		public abstract bool CheckAnswer(Answer studentAnswer);

		public virtual Answer? ParseStudentInput(string input)
		{
			if (int.TryParse(input.Trim(), out int id))
			{
				return Answers.GetById(id);
			}

			return null;
		}

		public virtual string GetCorrectAnswerDisplay()
		{
			return CorrectAnswer?.ToString() ?? "(none)";
		}

		protected void PrintQuestion()
		{
			Console.Clear();
			Console.WriteLine($"=== {Header} ===");
			Console.WriteLine($"{Body}  [Marks: {Marks}]");
			for (int i = 0; i < Answers.Count; i++)
			{
				Console.WriteLine($"  {Answers[i].Id}. {Answers[i].Text}");
			}

			Console.WriteLine("==============================");
		}

		public override bool Equals(object? obj)
		{
			if (obj is Question other)
			{
				return Header == other.Header && Body == other.Body && Marks == other.Marks
					&& object.Equals(CorrectAnswer, other.CorrectAnswer);
			}

			return false;
		}

		public override string ToString()
		{
			return $"Header: {Header}, Body: {Body}, Marks: {Marks}, Correct Answer: {GetCorrectAnswerDisplay()}";
		}
	}
}
