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
	/// Interaction logic for AgenciesView.xaml
	/// </summary>
	public partial class AgenciesView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<Agency> Agencies { get; set; } = new ObservableCollection<Agency>();
		public Agency SelectedItem { get; set; }

		public AgenciesView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddAgencyView(SelectedItem, onSubmit: agent =>
			{
				var oldAgency = reLenderService.AgenciesRepo.Get(agent.Id);
				oldAgency.Name = agent.Name;

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			reLenderService.AgenciesRepo.Remove(SelectedItem.Id);
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
			var window = new AddAgencyView(onSubmit: agency =>
			{
				this.reLenderService.AgenciesRepo.Create(agency);
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			Agencies.Clear();
			var updatedData = await Task.Run(() => reLenderService.AgenciesRepo.GetAll().ToList());
			updatedData.ForEach(a => Agencies.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
