using Ookii.Dialogs.Wpf;
using System.Windows;
using System.IO;
using System.ComponentModel;
using CompositeTask.Models;

namespace CompositeTask;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	public MainWindow()
	{
		InitializeComponent();

		DataContext = this;
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	private void OnPropertyChanged(string propertyName)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	private MyFolder? currentFolder;
	public MyFolder? CurrentFolder
	{
		get { return currentFolder; }
		set { currentFolder = value; OnPropertyChanged(nameof(CurrentFolder)); }
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		VistaFolderBrowserDialog folderDialog = new();

		if (folderDialog.ShowDialog() is true)
		{
			DirectoryInfo directory = new DirectoryInfo(folderDialog.SelectedPath);
			CurrentFolder = new MyFolder(directory.Name, directory.FullName);
			AllFilesList(CurrentFolder, directory);
		}
	}

	public void AllFilesList(MyFolder folder, DirectoryInfo directory)
	{
		var listOfFiles = directory.GetFiles();

		foreach (var file in listOfFiles)
			folder.Add(new File(file.Name, file.Length, file.FullName));

		listOfFiles = null;
	}
}
