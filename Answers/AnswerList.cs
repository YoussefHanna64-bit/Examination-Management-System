using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Answers
{
	public class AnswerList
	{
		//private Answer[] _answers;
		//private int _count;
        private List<Answer> _answers;

		public AnswerList(int capacity = 10)
		{
			if (capacity <= 0)
			{
				throw new ArgumentException("Capacity must be positive");
			}

			//_answers = new Answer[capacity];
			//_count = 0;

			_answers = new List<Answer>(capacity);
		}

		public void Add(Answer answer)
		{
			if (answer is null)
			{
				throw new ArgumentNullException("Answer cannot be null");
			}

			// if (_count >= _answers.Length)
			// {
			// 	Array.Resize(ref _answers, _answers.Length * 2);
			// }

			// _answers[_count++] = answer;

			 _answers.Add(answer);
		}

		public bool Contains(Answer answer)
		{
			if (answer is null)
			{
				return false;
			}

			for (int i = 0; i < _answers.Count; i++)
			{
				if (_answers[i].Equals(answer))
				{
					return true;
				}
			}

			return false;
		}

		public Answer? GetById(int id)
		{
			for (int i = 0; i < _answers.Count; i++)
			{
				if (_answers[i].Id == id)
				{
					return _answers[i];
				}
			}

			return null;
		}

		public Answer this[int index]
		{
			get
			{
				if (index < 0 || index >= _answers.Count)
				{
					throw new IndexOutOfRangeException($"Index {index} is out of range AnswerList has {_answers.Count} ans");
				}

				return _answers[index];
			}
			set
			{
				if (index < 0 || index >= _answers.Count)
				{
					throw new IndexOutOfRangeException($"Index {index} is out of range AnswerList has {_answers.Count} ans");
				}

				_answers[index] = value ?? throw new ArgumentNullException("Answer cannot be null.");
			}
		}

		public int Count
		{
			get
			{
				return _answers.Count;
			}
		}
	}
}
