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
using LaptopLoadTool;
using System.Collections;

namespace BulkFileDelete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            filePathTextBox.Text = Directory.GetCurrentDirectory();
        }

        private void DeleteFilesWithExtension()
        {
            //Get the selected file extension from the combobox
            var item = fileTypesComboBox.SelectedItem as ComboBoxItem;
            string fileExtension = item?.Content?.ToString() ?? fileTypesComboBox.SelectedItem.ToString() ?? "";
            fileExtension = Convert.ToString(fileExtension);
            string exeName = System.AppDomain.CurrentDomain.FriendlyName;

            //Add an entry
            if (fileExtension == "Add")
            {
                GetUserinput getInputForm = new GetUserinput("Additional Entry", "Enter the file extension", "", "Add");
                getInputForm.ShowDialog();
                if (getInputForm.DialogResult.HasValue && getInputForm.DialogResult.Value && !string.IsNullOrEmpty(getInputForm.userInput))
                {
                    string extension = getInputForm.userInput;
                    fileTypesComboBox.Items.Add(extension);
                    fileTypesComboBox.SelectedItem = extension;
                }
                return;
            }
            //Delete all files that contains the file extension (this one checks file name, not file type)
            else if (!fileExtension.Contains("."))
            {
                string[] files = Directory.GetFiles(filePathTextBox.Text);

                //Filter out the files that contain the fileExtension
                files = files.Where(file => System.IO.Path.GetFileNameWithoutExtension(file).Contains(fileExtension)).ToArray();
                files = files.Where(x => !x.Contains(exeName)).ToArray();

                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine("Deleted {0}", file);
                }
                return;
            }

            string filePath = filePathTextBox.Text;

            //Delete all files that are of type fileExtension
            if (Directory.Exists(filePath))
            {
                string[] files = Directory.GetFiles(filePath);
                files = files.Where(x => !x.Contains(exeName)).ToArray();

                foreach (string file in files)
                {
                    if (System.IO.Path.GetExtension(file) == fileExtension?.ToString())
                    {

                        try{
                            File.Delete(file);
                        }
                        catch(Exception e)
                        {

                        }
                    }
                }
            }
            else
            {
                //Handle the case where the file path does not exist or is not a directory
            }
        }
        private void FilePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = filePathTextBox.Text;
            text = text.Replace("\"", "");
            filePathTextBox.Text = text;
        }
        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            DeleteFilesWithExtension();
        }

        private void FilePathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DeleteFilesWithExtension();
            }
        }

        private void DirectoryBtn_Click(object sender, RoutedEventArgs e)
        {
            //Create a new open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Set the dialog properties
            openFileDialog.Title = "Select a folder";
            openFileDialog.Filter = "Folders|\n"; // This filter only allows the selection of folders
            openFileDialog.FileName = "Folder Selection."; // This text is displayed in the file name text box
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == true)
            {
                filePathTextBox.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
        }
    }
}
