using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;
using C__Project.Core;
using C__Project.Questions;

namespace C__Project.Exams
{
	public class PracticeExam : Exam
	{
		public PracticeExam(int time, int numberOfQuestions, Subject subject)
			: base(time, numberOfQuestions, subject) { }

		public override void ShowExam()
		{
			Console.WriteLine("============================================================");
			Console.WriteLine($"   {Subject.Name} PRACTICE practice exam |  Time: {Time} min");
			Console.WriteLine("============================================================");

			PrintQuestions();
		}

		public override void Finish()
		{
			base.Finish();

			Console.Clear();
			Console.WriteLine("==================");
			Console.WriteLine("  Exam Results");
			Console.WriteLine("==================");

			int totalPossible = 0;

			foreach (Question q in Questions)
			{
				if (q is null)
				{
					continue;
				}

				totalPossible += q.Marks;

				QuestionAnswerDictionary.TryGetValue(q, out Answer? studentAnswer);
				bool correct = studentAnswer is not null && q.CheckAnswer(studentAnswer);

				Console.WriteLine("");
				Console.WriteLine($"Q: {q.Body}");
				Console.WriteLine($"Your answer   : {studentAnswer?.ToString() ?? "(no answer)"}");
				Console.WriteLine($"Correct answer: {q.GetCorrectAnswerDisplay()}");
				Console.ForegroundColor = correct ? ConsoleColor.Green : ConsoleColor.Red;
				Console.WriteLine($"Result        : {(correct ? "Correct" : "Wrong")}  [{(correct ? q.Marks : 0)}/{q.Marks}]");
				Console.ResetColor();
			}

			int stdGrade = CorrectExam();
			Console.WriteLine("");
			Console.WriteLine("==============================");
			Console.WriteLine($"  Your grade: {stdGrade} / {totalPossible}");
			Console.WriteLine("==============================");

			PersistToFile($"[{DateTime.Now}] Practice Exam Results for {Subject.Name} - Grade: {stdGrade} / {totalPossible}");
		}

		public override object Clone()
		{
			return new PracticeExam(Time, NumberOfQuestions, Subject);
		}
	}
}
