using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
			StudentList.Items.Add(new Student(100001,"Jane","Doe"));
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

		private Student GetSelectedStudent(){
			var selStudent = (Student)StudentList.SelectedItem;
			return selStudent;
		}
		
		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			var win = new ChangeWindow();
			win.modifyMode = false;
			win.Show();
		}

		private void UpdButton_Click(object sender, RoutedEventArgs e)
		{
			if (StudentList.Items.Count > 0){
				if (StudentList.SelectedItems.Count > 0){
					var selection = GetSelectedStudent();
					var win = new ChangeWindow();
					win.modifyMode = true;
					win.IDTBox.Text = selection.StudentID.ToString();
					win.BoxInit();
					win.Show();
				}
			}
		}

		private void RmvButton_Click(object sender, RoutedEventArgs e)
		{
			if (StudentList.Items.Count > 0){
				if (StudentList.SelectedItems.Count > 0){
					var selection = GetSelectedStudent();
					StudentList.Items.Remove(selection);
				}
			}
		}

		public string AddStudent(string newFirst,string newLast,int newID){
			// index thing first
			var stuList = new List<Student>();
			foreach (Student student in StudentList.Items){
				stuList.Add(student);
			}
			var stuQuery = from student in stuList where student.StudentID == newID select student;
			if (stuQuery.Count<Student>() == 0){
				StudentList.Items.Add(new Student(newID,newFirst,newLast));
				return "-1";
			}else{
				return "Already existing ID";
			}
		}

		public void UpdateStudent(string newFirst, string newLast,int existID){
			// find the item
			foreach (Student student in StudentList.Items){
				if (student.StudentID == existID){
					student.FirstName = newFirst;
					student.LastName = newLast;
					break;
				}
			}
			// coool
			StudentList.Items.Refresh(); // fix the layout
		}
	}
}
