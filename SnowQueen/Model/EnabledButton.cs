using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnowQueen.Model
{
	static class EnabledButton
	{
		public static bool IsCorrectName { get; set; }
		public static bool IsCorrectPrice { get; set; }
		public static bool IsCorrectCount { get; set; }

		public static bool IsCorrect()
		{
			if (IsCorrectCount && IsCorrectName && IsCorrectPrice)
				return true;
			return false;
		}
	}
}