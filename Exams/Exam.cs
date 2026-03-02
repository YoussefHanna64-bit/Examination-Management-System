using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;
using C__Project.Core;
using C__Project.Enum;
using C__Project.Questions;

namespace C__Project.Exams
{
	public abstract class Exam : ICloneable, IComparable<Exam>
	{
		private int _time;
		private int _numberOfQuestions;

		public int Time
		{
			get => _time;
			protected set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Time must be positive");
				}

				_time = value;
			}
		}

		public int NumberOfQuestions
		{
			get => _numberOfQuestions;
			protected set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Number of questions must be positive");
				}

				_numberOfQuestions = value;
			}
		}

		protected Question[] Questions { get; set; }
		protected Dictionary<Question, Answer?> QuestionAnswerDictionary { get; set; }
		public Subject Subject { get; protected set; }
		public ExamMode Mode { get; protected set; }

		protected Exam(int time, int numberOfQuestions, Subject subject)
		{
			Time = time;
			NumberOfQuestions = numberOfQuestions;
			Subject = subject ?? throw new ArgumentNullException("Subject cannot be null");
			Questions = new Question[numberOfQuestions];
			QuestionAnswerDictionary = new Dictionary<Question, Answer?>();
			Mode = ExamMode.Queued;
		}


		public virtual void Start()
		{
			Mode = ExamMode.Starting;
			Console.Clear();
			string message = $"Exam is starting - Subject: {Subject.Name} - Duration: {Time} min";
			Subject.NotifyStudents(message);

            Console.WriteLine("");
			Console.WriteLine("Press any key to start the exam");
			Console.ReadKey();
		}

		public virtual void Finish()
		{
			Mode = ExamMode.Finished;
			Console.WriteLine("Exam is Finished");
		}

		public int CorrectExam()
		{
			int total = 0;
			foreach (var kvp in QuestionAnswerDictionary)
			{
				bool correct = kvp.Key.CheckAnswer(kvp.Value!);
				if (correct)
				{
					total += kvp.Key.Marks;
				}

			}
			return total;
		}

		public abstract void ShowExam();

		protected Answer? GetStudentAnswer(Question question)
		{
			Answer? studentAnswer = null;

			do
			{
				string? input = Console.ReadLine()?.Trim();

				studentAnswer = question.ParseStudentInput(input);

				if (studentAnswer is null)
                {
                    Console.Write("Invalid choice. Try again: ");
                }	

			} while (studentAnswer is null);

			return studentAnswer;
		}

        protected void PrintQuestions()
        {
            foreach (Question q in Questions)
			{
				if (q is null)
				{
					continue;
				}

				q.Display();
				Answer? studentAnswer = GetStudentAnswer(q);
				QuestionAnswerDictionary[q] = studentAnswer;
			}
        }

		public void LoadQuestions(QuestionList questionList)
		{
			int count = Math.Min(questionList.Count, NumberOfQuestions);
			for (int i = 0; i < count; i++)
			{
				Questions[i] = questionList[i];
			}
		}

		protected void PersistToFile(string content)
		{
			string fileName = $"{Subject.Name}_Results.txt";
            
			try
			{
				using StreamWriter writer = new StreamWriter(fileName, append: true);
				writer.WriteLine(content);
				Console.WriteLine($"Results saved to: {fileName}");
			}
			catch (IOException ex)
			{
				Console.Error.WriteLine($"Failed to save results: {ex.Message}");
			}
		}

		public abstract object Clone();

		public int CompareTo(Exam? other)
		{
			if (other is null)
			{
				return 1;
			}

			if (Time.CompareTo(other.Time) != 0)
			{
				return Time.CompareTo(other.Time);
			}

			return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
		}

		public override bool Equals(object? obj)
		{
			if (obj is Exam other)
			{
				return Time == other.Time && NumberOfQuestions == other.NumberOfQuestions &&
					Subject.Equals(other.Subject);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Time, NumberOfQuestions, Subject);
		}
		
		public override string ToString()
		{
			return $"Exam: Subject: {Subject.Name}, Time: {Time} min, Questions: {NumberOfQuestions}, Mode: {Mode}";
		}
	}
}
