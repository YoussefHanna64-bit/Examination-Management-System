using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;
using C__Project.Core;
using C__Project.Questions;

namespace C__Project.Exams
{
	public class FinalExam : Exam
	{
		public FinalExam(int time, int numberOfQuestions, Subject subject)
			: base(time, numberOfQuestions, subject) { }

		public override void ShowExam()
		{
			Console.WriteLine("============================================================");
			Console.WriteLine($"   {Subject.Name} final exam |  Time: {Time} min");
			Console.WriteLine("============================================================");

			PrintQuestions();
		}

		public override void Finish()
		{
			base.Finish();

			Console.Clear();
			Console.WriteLine("==================");
			Console.WriteLine("  Your Answers");
			Console.WriteLine("==================");

			int totalPossible = 0;

			foreach (Question q in Questions)
			{
				if (q is null)
				{
					continue;
				}

				totalPossible += q.Marks;
				Answer? studentAnswer = QuestionAnswerDictionary[q];
				bool correct = studentAnswer is not null && q.CheckAnswer(studentAnswer);

				Console.WriteLine("");
				Console.WriteLine($"Q: {q.Body}");
				Console.WriteLine($"Your answer: {studentAnswer?.ToString() ?? "(no answer)"}");
			}

			int stdGrade = CorrectExam();
			Console.WriteLine("");
			Console.WriteLine("==============================");
			Console.WriteLine("  Your exam has been submitted");
			Console.WriteLine("==============================");

			PersistToFile($"[{DateTime.Now}] Final Exam Results for {Subject.Name} - Grade: {stdGrade} / {totalPossible}");
		}

		public override object Clone()
		{
			return new FinalExam(Time, NumberOfQuestions, Subject);
		}
	}
}
