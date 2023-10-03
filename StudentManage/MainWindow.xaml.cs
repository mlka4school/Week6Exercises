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

namespace StudentManage
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//var win = new ChangeWindow();
			//win.Show();
			// very likely, we won't need to make a custom list. just use studentlist.
			StudentList.Items.Add(new Student(100000,"John","Doe")); // honestly, this made me LIVID
		}

		public class Student{
			public int StudentID {get; set;}
			public string FirstName {get; set;}
			public string LastName {get; set;}
			
			public Student(int newID, string newFirst, string newLast){
				StudentID = newID;
				
				FirstName = newFirst;
				LastName = newLast;
			}
		}
	}
}
