using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.VisualBasic.FileIO;

namespace LaptopLoadTool
{
    //Gets input from the user, stores it in userInput
    public partial class GetUserinput : Window
    {
        public string? userInput { get; set; } = null;
        public GetUserinput(string title = "Custom Input", string prompt = "Ebter information", string textBox = "", string buttonName = "Confirm")
        {
            InitializeComponent();
            this.Title = title;
            labelPrompt.Content = prompt;
            userInputBox.Text = textBox;
            userInputBox.Focus();
            userInputBox.SelectionStart = userInputBox.Text.Length;
            userInputBox.SelectionLength = 0;
            confirmButton.Content = buttonName;
        }
        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            CloseForm();
        }
        private void Event_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                CloseForm();
        }
        private void CloseForm()
        {
            DialogResult = true;
            this.userInput = userInputBox.Text;
            this.Close();
        }
    }
}
