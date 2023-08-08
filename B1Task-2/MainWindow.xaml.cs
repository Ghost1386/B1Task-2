using System;
using System.Windows;
using B1Task_2.Services;
using Microsoft.Win32;

namespace B1Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
            
                if (openFileDialog.ShowDialog() == true)
                {
                    var databaseService = new DatabaseService();

                    var filePath = openFileDialog.FileName.Replace(@"\", "\\");

                    if (await databaseService.AddData(filePath))
                    {
                        if (await databaseService.AddFile(openFileDialog.FileName))
                        {
                            MessageBox.Show("Данные из файла добавлены в СУБД");
                            
                            return;
                        }
                    }
                    
                    MessageBox.Show("По неизвестной ошибке не удалось добавить данные в СУБД");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void BtnDataList_OnClick(object sender, RoutedEventArgs e)
        {
            var dataGridWindow = new DataGridWindow();
            dataGridWindow.Show();
            Close();
        }
        
        private void BtnFileList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileGridWindow = new FileGridWindow();
            fileGridWindow.Show();
            Close();
        }
    }
}