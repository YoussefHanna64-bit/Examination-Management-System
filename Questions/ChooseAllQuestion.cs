using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Answers;

namespace C__Project.Questions
{
	public class ChooseAllQuestion : Question
	{
		private AnswerList _correctAnswers;

		public ChooseAllQuestion(string header, string body, int marks, AnswerList answers, AnswerList correctAnswers)
			: base(header, body, marks, answers, null)
		{
			if (answers is null || answers.Count < 2)
			{
				throw new ArgumentException("ChooseAllQuestion requires at least 2 answers");
			}

			if (correctAnswers is null || correctAnswers.Count == 0)
			{
				throw new ArgumentException("At least one correct answer must be provided");
			}

			for (int i = 0; i < correctAnswers.Count; i++)
			{
				if (!answers.Contains(correctAnswers[i]))
				{
					throw new ArgumentException($"{correctAnswers[i]} is not in the answer list");
				}

			}

			_correctAnswers = correctAnswers;
		}

		public override void Display()
		{
			PrintQuestion();
			Console.Write("Enter your answers (enter numbers separated by comma like 1,3): ");
		}

		public override bool CheckAnswer(Answer studentAnswer)
		{
			if (studentAnswer is null || string.IsNullOrWhiteSpace(studentAnswer.Text))
			{
				return false;
			}

			string[] stdAnswers = studentAnswer.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

			if (stdAnswers.Length != _correctAnswers.Count)
			{
				return false;
			}

			bool[] matched = new bool[_correctAnswers.Count];

			for (int i = 0; i < stdAnswers.Length; i++)
			{
				if (!int.TryParse(stdAnswers[i], out int id))
				{
					return false;
				}

				bool found = false;
				for (int j = 0; j < _correctAnswers.Count; j++)
				{
					if (!matched[j] && _correctAnswers[j].Id == id)
					{
						matched[j] = true;
						found = true;
						break;
					}
				}

				if (!found)
				{
					return false;
				}

			}

			return true;
		}

		public override Answer? ParseStudentInput(string input)
		{
			string[] stdAnswer = input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

			for (int i = 0; i < stdAnswer.Length; i++)
			{
				if (!int.TryParse(stdAnswer[i], out int id) || Answers.GetById(id) is null)
				{
					return null;
				}	
			}

			return new Answer(0, input);
		}

		public override string GetCorrectAnswerDisplay()
		{
			string result = "";
			for (int i = 0; i < _correctAnswers.Count; i++)
			{
				if (i > 0)
				{
					result += ", ";
				}
				result += _correctAnswers[i].ToString();
			}
			return result;
		}
	}
}
