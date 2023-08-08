using System.Windows;
using B1Task_2.Services;

namespace B1Task_2;

public partial class FileGridWindow : Window
{
    private static readonly DatabaseService DatabaseService = new();
    
    public FileGridWindow()
    {
        InitializeComponent();
        
        GetFile();
    }
    
    private async void GetFile()
    {
        var list = await DatabaseService.GetFile();

        fileGrid.ItemsSource = list;
    }
    
    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}