using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Answers
{
	public class Answer : IComparable<Answer>
	{
		private int _id;
		private string _text = string.Empty;

		public int Id
		{
			get => _id;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Answer Id cannot be negative");
				}

				_id = value;
			}
		}

		public string Text
		{
			get => _text;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Answer text cannot be null or empty");
				}
				_text = value;
			}
		}

		public Answer(int id, string text)
		{
			Id = id;
			Text = text;
		}

		public override bool Equals(object? obj)
		{
			if (obj is Answer other)
			{
				return Id == other.Id && Text == other.Text;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Text);
		}
		
		public int CompareTo(Answer? other)
		{
			if (other == null)
			{
				return 1;
			}
			return Id.CompareTo(other.Id);
		}

		public override string ToString()
		{
			return $"{Id}. {Text}";
		}
	}
}
