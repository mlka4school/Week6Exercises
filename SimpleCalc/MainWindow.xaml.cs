using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCalc
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public string currentValue = "0";
		public string queueValue = "";
		public string queueOperation = "";
		public bool isError = false; // stop all actions if this is ever true.
		public MainWindow()
		{
			InitializeComponent();
			//LabelSum.Content = "This is a test";
		}

		private void Math0_Click(object sender, RoutedEventArgs e)
		{
			if (!isError){
				if (currentValue != "0"){
					currentValue += "0";
				}
			}
			UpdateWindow();
		}

		private void MathDec_Click(object sender, RoutedEventArgs e)
		{
			if (!isError){
				if (currentValue != "0"){
					currentValue = currentValue.Replace(".","");
					currentValue = currentValue+".";
				}
			}
			UpdateWindow();
		}

		private void Math1_Click(object sender, RoutedEventArgs e)
		{
			TryValue("1");
			UpdateWindow();
		}

		private void Math2_Click(object sender, RoutedEventArgs e)
		{
			TryValue("2");
			UpdateWindow();
		}

		private void Math3_Click(object sender, RoutedEventArgs e)
		{
			TryValue("3");
			UpdateWindow();
		}

		private void Math4_Click(object sender, RoutedEventArgs e)
		{
			TryValue("4");
			UpdateWindow();
		}

		private void Math5_Click(object sender, RoutedEventArgs e)
		{
			TryValue("5");
			UpdateWindow();
		}

		private void Math6_Click(object sender, RoutedEventArgs e)
		{
			TryValue("6");
			UpdateWindow();
		}

		private void Math7_Click(object sender, RoutedEventArgs e)
		{
			TryValue("7");
			UpdateWindow();
		}

		private void Math8_Click(object sender, RoutedEventArgs e)
		{
			TryValue("8");
			UpdateWindow();
		}

		private void Math9_Click(object sender, RoutedEventArgs e)
		{
			TryValue("9");
			UpdateWindow();
		}
		

		private void MathCalc_Click(object sender, RoutedEventArgs e)
		{
			if (!isError){
				var final = queueValue+queueOperation+currentValue+" = ";
				currentValue = GetSum();
				queueValue = "";
				queueOperation = "";
				UpdateWindow();
				LabelSum.Content = final;
			}
		}

		private void MathPlus_Click(object sender, RoutedEventArgs e)
		{
			TryOperation("+");
		}

		private void MathSub_Click(object sender, RoutedEventArgs e)
		{
			TryOperation("-");
		}

		private void MathMult_Click(object sender, RoutedEventArgs e)
		{
			TryOperation("*");
		}

		private void MathDiv_Click(object sender, RoutedEventArgs e)
		{
			TryOperation("/");
		}

		private void MathC_Click(object sender, RoutedEventArgs e)
		{
			currentValue = "0";
			queueValue = "";
			queueOperation = "";
			isError = false;
			LabelSum.Content = "";
			UpdateWindow();
		}

		private void MathCE_Click(object sender, RoutedEventArgs e)
		{
			if (!isError){
				currentValue = "0";
			}
			UpdateWindow();
		}

		private void MathRev_Click(object sender, RoutedEventArgs e)
		{
			if (!isError){
				if (currentValue != "0"){
					if (currentValue[0].ToString() == "-"){
						currentValue = currentValue.Remove(0,1);
					}else{
						currentValue = "-"+currentValue;
					}
				}
			}
			UpdateWindow();
		}

		public void TryOperation(string op){
			if (!isError){
				if (queueOperation != ""){
					// do that first
					queueValue = GetSum();
				}else{
					queueValue = currentValue;
				}
				// now continue. clear the currentValue and prepare for a new one
				currentValue = "0";
				queueOperation = op;
				LabelSum.Content = queueValue+queueOperation;
			}
			UpdateWindow();
		}

		public string GetSum(){
			if (queueValue != ""){
				var val1 = Convert.ToDouble(queueValue);
				var val2 = Convert.ToDouble(currentValue);
				var sum = 0D;
				switch (queueOperation){
					case "+":
						sum = val1+val2;
					break;
					case "-":
						sum = val1-val2;
					break;
					case "*":
						sum = val1*val2;
					break;
					case "/":
						// surprisingly div by 0 does not crash. so we'll just cause an error if val2 is 0
						sum = val1/val2;
						if (val2 == 0){
							isError = true;
						}
					break;
				}

				return sum.ToString();
			}else{
				return currentValue;
			}
		}

		public void TryValue(string val){
			if (!isError){
				if (currentValue == "0"){
					currentValue = val;
				}else{
					currentValue += val;
				}
			}
		}

		public void UpdateWindow(){
			LabelCalc.Content = currentValue;
		}
	}
}
