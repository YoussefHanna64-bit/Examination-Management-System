using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;

namespace C__Project.Questions
{
	public class ChooseOneQuestion : Question
	{
		public ChooseOneQuestion(string header, string body, int marks, AnswerList answers, Answer correctAnswer)
			: base(header, body, marks, answers, correctAnswer)
		{
			if (answers is null || answers.Count < 2)
			{
				throw new ArgumentException("ChooseOneQuestion must have at least 2 answers");
			}


			if (correctAnswer is null || !answers.Contains(correctAnswer))
			{
				throw new ArgumentException("Correct answer must be one of the answers");
			}
		}

		public override void Display()
		{
			PrintQuestion();
			Console.Write("Enter your answer (enter the answer number): ");
		}

		public override bool CheckAnswer(Answer studentAnswer)
		{
			return studentAnswer is not null && studentAnswer.Equals(CorrectAnswer);
		}
	}
}
