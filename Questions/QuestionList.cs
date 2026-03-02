using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Questions
{
	public class QuestionList : List<Question>
	{
		private string _logFilePath;

		public QuestionList(string logFilePath)
		{
			if (string.IsNullOrWhiteSpace(logFilePath))
			{
				throw new ArgumentException("Log file path cannot be empty");
			}

			_logFilePath = logFilePath;
		}

		public new void Add(Question question)
		{
			if (question is null)
			{
				throw new ArgumentNullException("Question cannot be null");
			}

			base.Add(question);
			LogToFile(question);
		}

		private void LogToFile(Question question)
		{
			try
			{
				using StreamWriter writer = new StreamWriter(_logFilePath, append: true);
				writer.WriteLine($"[{DateTime.Now}]");
				writer.WriteLine(question.ToString());
				writer.WriteLine("==============================");
			}
			catch (IOException ex)
			{
				Console.Error.WriteLine($"QuestionList failed to write in log file: {ex.Message}");
			}
		}
	}
}
