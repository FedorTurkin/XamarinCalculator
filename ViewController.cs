using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace calculator
{
	public partial class ViewController : NSViewController
	{
		public int Counter = 0;
		public int EqualCounter = 0;
		public int CommaCounter = 0;
		calculations calculations = new calculations();
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Do any additional setup after loading the view.
		}

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

        partial void oneBtn(NSButton sender)
        {
			Console.WriteLine(-5 + 5);
			SetOutput("1");
        }
		partial void twoBtn(NSButton sender)
		{
			SetOutput("2");
		}
		partial void threeBtn(NSButton sender)
		{
			SetOutput("3");
		}
		partial void fourBtn(NSButton sender)
		{
			SetOutput("4");
		}
		partial void fiveBtn(NSButton sender)
		{
			SetOutput("5");
		}
		partial void sixBtn(NSButton sender)
		{
			SetOutput("6");
		}
		partial void sevenBtn(NSButton sender)
		{
			SetOutput("7");
		}
		partial void eightBtn(NSButton sender)
		{
			SetOutput("8");
		}
		partial void nineBtn(NSButton sender)
		{
			SetOutput("9");
		}
		partial void zeroBtn(NSButton sender)
		{
			SetOutput("0");
		}
        partial void commaBtn(NSButton sender)
        {
			string expr = Label.StringValue;
			if (expr != "" && ((FullExpression(expr) && CommaCounter==0) || (!FullExpression(expr) && !expr.Contains("."))))
			{
				SetOutput(".");
				CommaCounter++;
			}
        }
        partial void divideBtn(NSButton sender)
        {
			if (Label.StringValue != "")
			{
				CommaCounter = 0;
				string expr = Label.StringValue;
				if (!ContainSeparators(expr) && Counter < 1)
				{
					SetOutput("/");
					EqualCounter = 0;
					Counter++;
				}
				else if (Counter > 0  && FullExpression(expr))
				{
					Calculate();
					SetOutput("/");
					Counter++;
				}
			}

		}
        partial void minusBtn(NSButton sender)
        {
				CommaCounter = 0;
				string expr = Label.StringValue;
				if (!ContainSeparators(expr) && Counter < 2)
				{
					SetOutput("-");
					EqualCounter = 0;
					Counter++;
				}
				else if (Counter > 0 && Counter < 2 && FullExpression(expr))
				{
					Calculate();
					SetOutput("-");
					Counter++;
				}
			
		}
		partial void plusBtn(NSButton sender)
        {
			if (Label.StringValue != "")
			{
				CommaCounter = 0;
				string expr = Label.StringValue;
				if (!ContainSeparators(expr) && Counter < 2)
				{
					SetOutput("+");
					EqualCounter = 0;
					Counter++;
				}
				else if (Counter > 0 && Counter < 2 && FullExpression(expr))
				{
					Calculate();
					SetOutput("+");
					Counter++;
				}
			}
		}
        partial void multiplyBtn(NSButton sender)
        {
			if (Label.StringValue != "")
			{
				CommaCounter = 0;
				string expr = Label.StringValue;
				if (!ContainSeparators(expr) && Counter < 1)
				{
					SetOutput("x");
					EqualCounter = 0;
					Counter++;
				}
				else if (Counter > 0  && FullExpression(expr))
				{
					Calculate();
					SetOutput("x");
					Counter++;
				}
			}
		}
       
        partial void equalBtn(NSButton sender)
		{
			{
				string expr = Label.StringValue;
				
				if (FullExpression(expr))
				{
					if (EqualCounter == 0)
					{
						CommaCounter = 0;
						Calculate();
						EqualCounter++;
					}
				}
			}
		}
        partial void ACBtn(NSButton sender)
        {
			Counter = 0;
			CommaCounter = 0;
			Label.StringValue = "";
        }

        #region Methods

        private void SetOutput(string text)
		{
			Label.StringValue += text;
			string expr = Label.StringValue;
			OptimizeExpr(expr);
		}
		private string FindOperator(List<float> numbers, string expr)
		{
			string Operator = expr;
			int numbersCount = numbers.Count;
			for (int i = 0; i < numbers.Count; i++)
			{
				 Operator = SubStrDel(Operator, numbers[i].ToString());
			}
			return Operator;
		}
		private string SubStrDel(String str, string substr)
		{
			int n = str.IndexOf(substr);
			str = str.Remove(n, substr.Length);
			return str;
		}
		private void Calculate()
		{
			Counter = 0;
			string expr = Label.StringValue;
			List<float> numbers = SplitExpr(expr);
			string Operator = FindOperator(numbers, expr);
			if (Operator=="+")
				{
					Label.StringValue = "";
					SetOutput(calculations.add(numbers[0], numbers[1]));

				}
			if (Operator == "-")
				{
					Label.StringValue = "";
					SetOutput(calculations.subtract(numbers[0], numbers[1]));

				}
			if (Operator == "x")
				{
					Label.StringValue = "";
					SetOutput(calculations.multiply(numbers[0], numbers[1]));

				}
			if (Operator == "/")
				{
					Label.StringValue = "";
					SetOutput(calculations.divide(numbers[0], numbers[1]));
				}
			
		}
		private bool ContainSeparators(string expr)
		{
			if ( (FullExpression(expr) && (expr.Contains('+') || expr.Contains('-') || expr.Contains('/') || expr.Contains('x'))) && (FullExpression(expr) || (float.Parse(expr) < 0) ))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		private bool FullExpression(string expr)
		{
			List<float> numbers = SplitExpr(expr);
			if (numbers.Count == 2)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void OptimizeExpr(string expr)
		{
			if (expr.Contains("--"))
			{
				expr = expr.Replace("--", "+");
				Counter = 0;
			}
			if (expr.Contains("++"))
			{
				expr = expr.Replace("++", "+");
				Counter = 0;
			}
			if (expr.Contains("-+"))
			{
				expr = expr.Replace("-+", "-");
				Counter = 0;
			}
			if (expr.Contains("+-"))
			{
				expr = expr.Replace("+-", "-");
				Counter = 0;
			}
			if (expr != "")
			{
				char[] exprCharArray = expr.ToCharArray();
				if (exprCharArray[0] == '+')
				{
					expr = expr.Replace("+","");
					Counter = 0;
				}
			}
			Label.StringValue = expr;
		}
		private List<float> SplitExpr(string expr)
		{
			
			char[] exprCharArray = expr.ToCharArray();
			List<float> numbers = new List<float>();
			if (!string.IsNullOrEmpty(expr))
			{
				if (!(expr.Contains('+') || expr.Contains('-') || expr.Contains('x') || expr.Contains('/')))
				{

					numbers.Add(float.Parse(expr));
				}
				else
				{
					int length = exprCharArray.Length;
					List<char> number1 = new List<char>();
					List<char> number2 = new List<char>();
					int counter = 0;
					int number1Length = 0;
					if (exprCharArray[0] == '-' && length > 1)
					{
						number1Length = 1;
						number1.Add('-');
						for (int i = 1; counter == 0; i++)
						{
							if (number1Length < length && exprCharArray[i] != '+' && exprCharArray[i] != '-' && exprCharArray[i] != 'x' && exprCharArray[i] != '/' )
							{
								number1.Add(exprCharArray[i]);
								number1Length++;
							}
							else
							{
								counter++;
							}
						}
						numbers.Add(float.Parse(string.Join("", number1)));
						if (number1Length < length && char.IsDigit(exprCharArray[length-1]))
						{
							for (int i = number1Length + 1; i != length; i++)
							{
								number2.Add(exprCharArray[i]);
							}
							numbers.Add(float.Parse(string.Join("", number2)));
						}
					}
					else  if (length > 1)
					{
						for (int i = 0; counter == 0; i++)
						{
							if (number1Length < length && exprCharArray[i] != '+' && exprCharArray[i] != '-' && exprCharArray[i] != 'x' && exprCharArray[i] != '/')
							{
								number1.Add(exprCharArray[i]);
								number1Length++;
							}
							else
							{
								counter++;
							}
						}

						numbers.Add(float.Parse(string.Join("", number1)));
						
						if (number1Length < length && char.IsDigit(exprCharArray[length-1]))
						{
							for (int i = number1Length + 1; i != length; i++)
							{
								number2.Add(exprCharArray[i]);
							}
						numbers.Add(float.Parse(string.Join("", number2)));
						}
					}
					
				}
			}
			return numbers;

		}
        #endregion 

    }

}
