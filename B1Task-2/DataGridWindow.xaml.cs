using System.Linq;
using System.Windows;
using System.Windows.Controls;
using B1Task_2.Services;

namespace B1Task_2;

public partial class DataGridWindow : Window
{
    private static readonly DatabaseService DatabaseService = new();

    public DataGridWindow()
    {
        InitializeComponent();

        SetTitleToComboBox();
    }
    
    private void FileId_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = FileId.SelectedIndex;
        
        GetData(index);
    }

    private async void GetData(int id)
    {
        var dataList = await DatabaseService.GetData(id);

        DataGridForClass1.ItemsSource = dataList.GetRange(0, 73);
        DataGridForClass2.ItemsSource = dataList.GetRange(74, 101);
        DataGridForClass3.ItemsSource = dataList.GetRange(175, 83);
        DataGridForClass4.ItemsSource = dataList.GetRange(259, 25);
        DataGridForClass5.ItemsSource = dataList.GetRange(284, 31);
        DataGridForClass6.ItemsSource = dataList.GetRange(316, 109);
        DataGridForClass7.ItemsSource = dataList.GetRange(425, 12);
        DataGridForClass8.ItemsSource = dataList.GetRange(448, 52);
        DataGridForClass9.ItemsSource = dataList.GetRange(500, 109);
    }

    private async void SetTitleToComboBox()
    {
        var addedFiles = await DatabaseService.GetFile();
    
        var titleList = addedFiles.Select(f => f.Title).ToList();

        FileId.ItemsSource = titleList;
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}