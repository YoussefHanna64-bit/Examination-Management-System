using C__Project.Answers;
using C__Project.Core;
using C__Project.Exams;
using C__Project.Questions;

namespace C__Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("=======================================");
			Console.WriteLine("   Examination Management System");
			Console.WriteLine("   ITI — Dr.Hany - C# Project");
			Console.WriteLine("=======================================");
			Console.ResetColor();

			var subject = new Subject("C# Programming");

			var student1 = new Student(1, "Youssef");
			var student2 = new Student(2, "Hanna");
			var student3 = new Student(3, "Anees");

			subject.Enroll(student1);
			subject.Enroll(student2);
			subject.Enroll(student3);

			var practiceQuestions = new QuestionList("practice_questions.log");
			var finalQuestions = new QuestionList("final_questions.log");

			practiceQuestions.Add(new TrueFalseQuestion(
				header: "Q1 – OOP",
				body: "Is C# a purely object-oriented language?",
				marks: 5,
				correctAnswer: false));

			var q2Answers = new AnswerList(4);
			q2Answers.Add(new Answer(1, "Java"));
			q2Answers.Add(new Answer(2, "Python"));
			q2Answers.Add(new Answer(3, "C#"));
			q2Answers.Add(new Answer(4, "Ruby"));

			practiceQuestions.Add(new ChooseOneQuestion(
				header: "Q2 – Languages",
				body: "Which language runs on the .NET runtime?",
				marks: 10,
				answers: q2Answers,
				correctAnswer: q2Answers.GetById(3)!));

			var q3Answers = new AnswerList(4);
			q3Answers.Add(new Answer(1, "Encapsulation"));
			q3Answers.Add(new Answer(2, "Compilation"));
			q3Answers.Add(new Answer(3, "Inheritance"));
			q3Answers.Add(new Answer(4, "Polymorphism"));

			AnswerList q3CorrectAnswers = new AnswerList();
			q3CorrectAnswers.Add(q3Answers.GetById(1)!);
			q3CorrectAnswers.Add(q3Answers.GetById(3)!);
			q3CorrectAnswers.Add(q3Answers.GetById(4)!);

			practiceQuestions.Add(new ChooseAllQuestion(
				header: "Q3 – OOP Pillars",
				body: "Select ALL pillars of Object-Oriented Programming:",
				marks: 15,
				answers: q3Answers,
				correctAnswers: q3CorrectAnswers));


			var q4Answers = new AnswerList(3);
			q4Answers.Add(new Answer(1, "Single Responsibility Principle"));
			q4Answers.Add(new Answer(2, "Simple Reuse Principle"));
			q4Answers.Add(new Answer(3, "Structured Runtime Principle"));

			finalQuestions.Add(new ChooseOneQuestion(
				header: "Q1 – SOLID",
				body: "What does the 'S' in SOLID stand for?",
				marks: 10,
				answers: q4Answers,
				correctAnswer: q4Answers.GetById(1)!));

			finalQuestions.Add(new TrueFalseQuestion(
				header: "Q2 – Events",
				body: "In C#, delegates are the foundation of the event system.",
				marks: 5,
				correctAnswer: true));

			string? again;
			do
			{
				Console.WriteLine();
				Console.WriteLine("==============================");
				Console.WriteLine("Select Exam Type:");
				Console.WriteLine("    1 - Practice Exam");
				Console.WriteLine("    2 - Final Exam");
				Console.WriteLine("==============================");

				string? choice;
				do
				{
					Console.Write("Your choice: ");
					choice = Console.ReadLine()?.Trim();

					if (choice != "1" && choice != "2")
					{
						Console.WriteLine("Invalid choice. Please enter 1 or 2");
					}

				} while (choice != "1" && choice != "2");

				Exam selectedExam;

				if (choice == "1")
				{
					PracticeExam practiceExam = new PracticeExam(time: 30, numberOfQuestions: 3, subject);
					practiceExam.LoadQuestions(practiceQuestions);
					selectedExam = practiceExam;
				}
				else
				{
					FinalExam finalExam = new FinalExam(time: 60, numberOfQuestions: 2, subject);
					finalExam.LoadQuestions(finalQuestions);
					selectedExam = finalExam;
				}

				selectedExam.Start();
				selectedExam.ShowExam();
				selectedExam.Finish();

				Console.WriteLine();
				Console.Write("Take another exam? (y/n): ");
				again = Console.ReadLine()?.Trim().ToLower();

			} while (again == "y");

			Console.WriteLine("");
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}


	}
}
