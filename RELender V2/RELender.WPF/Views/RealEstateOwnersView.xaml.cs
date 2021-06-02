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
	/// Interaction logic for RealEstateOwnersView.xaml
	/// </summary>
	public partial class RealEstateOwnersView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<RealEstateOwner> RealEstateOwners { get; set; } = new ObservableCollection<RealEstateOwner>();
		public RealEstateOwner SelectedItem { get; set; }

		public RealEstateOwnersView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddPersonView(SelectedItem, onSubmit: RealEstateOwner =>
			{
				var oldRealEstateOwner = reLenderService.RealEstateOwnersRepo.Get(RealEstateOwner.Id);
				oldRealEstateOwner.Name = RealEstateOwner.Name;
				oldRealEstateOwner.Surname = RealEstateOwner.Surname;
				oldRealEstateOwner.Email = RealEstateOwner.Email;
				oldRealEstateOwner.PhoneNo = RealEstateOwner.PhoneNo;

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			//reLenderService.RealEstateOwnersRepo.Remove(SelectedItem.Id);
			await Task.Run(() => reLenderService.RealEstateOwnersRepo.Remove(SelectedItem.Id));

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
			var window = new AddPersonView(onSubmit: RealEstateOwner =>
			{
				this.reLenderService.RealEstateOwnersRepo.Create(new RealEstateOwner(RealEstateOwner));
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			RealEstateOwners.Clear();
			var updatedData = await Task.Run(() => reLenderService.RealEstateOwnersRepo.GetAll().ToList());
			updatedData.ForEach(a => RealEstateOwners.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
