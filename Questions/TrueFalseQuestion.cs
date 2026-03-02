using System;
using System.Collections.Generic;
using System.Text;

using C__Project.Answers;

namespace C__Project.Questions
{
	public class TrueFalseQuestion : Question
	{
		public TrueFalseQuestion(string header, string body, int marks, bool correctAnswer)
			: base(header, body, marks, new AnswerList(2), null)
		{
			Answers.Add(new Answer(1, "True"));
			Answers.Add(new Answer(2, "False"));
			CorrectAnswer = correctAnswer ? Answers.GetById(1) : Answers.GetById(2);
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
