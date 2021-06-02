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
	/// Interaction logic for AgentsView.xaml
	/// </summary>
	public partial class AgentsView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<Agent> Agents { get; set; } = new ObservableCollection<Agent>();
		public Agent SelectedItem { get; set; }

		public AgentsView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddPersonView(SelectedItem, onSubmit: agent =>
			{
				var oldAgent = reLenderService.AgentsRepo.Get(agent.Id);
				oldAgent.Name = agent.Name;
				oldAgent.Surname = agent.Surname;
				oldAgent.Email = agent.Email;
				oldAgent.PhoneNo = agent.PhoneNo;

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			reLenderService.AgentsRepo.Remove(SelectedItem.Id);
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
			var window = new AddPersonView(onSubmit: agent =>
			{
				this.reLenderService.AgentsRepo.Create(new Agent(agent));
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			Agents.Clear();
			var updatedData = await Task.Run(() => reLenderService.AgentsRepo.GetAll().ToList());
			updatedData.ForEach(a => Agents.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
