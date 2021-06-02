using RELender.BLL.Interfaces;
using RELender.BLL.Models;
using RELender.WPF.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RELender.WPF.Views
{
	/// <summary>
	/// Interaction logic for ClientsView.xaml
	/// </summary>
	public partial class ClientsView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
		public Client SelectedItem { get; set; }

		public ClientsView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddPersonView(SelectedItem, onSubmit: Client =>
			{
				var oldClient = reLenderService.ClientsRepo.Get(Client.Id);
				oldClient.Name = Client.Name;
				oldClient.Surname = Client.Surname;
				oldClient.Email = Client.Email;
				oldClient.PhoneNo = Client.PhoneNo;

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			reLenderService.ClientsRepo.Remove(SelectedItem.Id);
			//reLenderService.SaveChanges();

			if (reLenderService.SaveChanges() == 0)
			{
				MessageBox.Show("could not delete item");
			}

			await RefreshData();
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			deleteBtn.IsEnabled = editBtn.IsEnabled = SelectedItem != null;
		}

		private async void addBtn_Click(object sender, RoutedEventArgs e)
		{
			var window = new AddPersonView(onSubmit: Client =>
			{
				this.reLenderService.ClientsRepo.Create(new Client(Client));
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			Clients.Clear();
			var updatedData = await Task.Run(() => reLenderService.ClientsRepo.GetAll().ToList());
			updatedData.ForEach(a => Clients.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
