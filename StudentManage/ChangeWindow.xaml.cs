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
using System.Windows.Shapes;

namespace StudentManage
{
    /// <summary>
    /// Interaction logic for ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
		public bool modifyMode {get;set;}
        public ChangeWindow()
        {
            InitializeComponent();
        }

		private void DoneButton_Click(object sender, RoutedEventArgs e)
		{
			var mainWin = (MainWindow)Application.Current.MainWindow;
			if (modifyMode){
				mainWin.UpdateStudent(FirstTBox.Text,LastTBox.Text,Convert.ToInt32(IDTBox.Text));
				//Close();
			}else{
				var real = 0;
				if (!int.TryParse(IDTBox.Text,out real) || FirstTBox.Text == "" || LastTBox.Text == ""){ // don't ask why i use tryparse like this. it just works
					ErrorLabel.Content = "Fields are incorrect";
					return;
				}
				var attempt = mainWin.AddStudent(FirstTBox.Text,LastTBox.Text,Convert.ToInt32(IDTBox.Text));
				if (attempt == "-1"){
					Close();
				}else{
					ErrorLabel.Content = attempt;
				}
			}
		}

		public void BoxInit(){
			if (modifyMode) IDTBox.IsEnabled = false;
		}
	}
}
