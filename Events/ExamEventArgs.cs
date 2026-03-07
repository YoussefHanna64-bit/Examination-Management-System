using System;
using System.Collections.Generic;
using System.Text;
using C__Project.Core;
using C__Project.Exams;

namespace C__Project.Events
{
	public class ExamEventArgs : EventArgs
	{
		public Subject Subject { get; }
		public Exam Exam { get; }

		public ExamEventArgs(Subject subject, Exam exam)
		{
			Subject = subject ?? throw new ArgumentNullException("Subject cannot be null");
			Exam = exam ?? throw new ArgumentNullException("Exam cannot be null");
		}

	}

    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
}
