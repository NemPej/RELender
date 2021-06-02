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
	/// Interaction logic for RentingRightsView.xaml
	/// </summary>
	public partial class RentingRightsView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<RentingRights> RentingRights { get; set; } = new ObservableCollection<RentingRights>();
		public RentingRights SelectedItem { get; set; }

		public RentingRightsView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddRentingRights(SelectedItem, reLenderService.RealEstatesRepo.GetAll(), reLenderService.AgenciesRepo.GetAll(), onSubmit: RentingRights =>
			{
				var oldRentingRights = reLenderService.RentingRightsRepo.Get(RentingRights.Id);
				oldRentingRights.Agency = RentingRights.Agency;
				oldRentingRights.OwnerCompensation = RentingRights.OwnerCompensation;
				oldRentingRights.RealEstate = RentingRights.RealEstate;
		

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			reLenderService.RentingRightsRepo.Remove(SelectedItem.Id);
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
			var window = new AddRentingRights(reLenderService.RealEstatesRepo.GetAll(), reLenderService.AgenciesRepo.GetAll(), onSubmit: rentingRights =>
			{
				this.reLenderService.RentingRightsRepo.Create(rentingRights);
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			RentingRights.Clear();
			var updatedData = await Task.Run(() => reLenderService.RentingRightsRepo.GetAll().ToList());
			updatedData.ForEach(a => RentingRights.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
