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
	/// Interaction logic for RealEsatesView.xaml
	/// </summary>
	public partial class RealEsatesView : Window
	{
		private readonly IRELenderService reLenderService;
		public ObservableCollection<RealEstate> RealEstates { get; set; } = new ObservableCollection<RealEstate>();
		public RealEstate SelectedItem { get; set; }

		public RealEsatesView(IRELenderService reLenderService)
		{
			InitializeComponent();
			this.reLenderService = reLenderService;
			DataContext = this;
		}

		private async void editBtn_Click(object sender, RoutedEventArgs e)
		{
			var view = new AddRealEstateView(SelectedItem, reLenderService.RealEstateOwnersRepo.GetAll(), onSubmit: RealEstate =>
			{
				var oldRealEstate = reLenderService.RealEstatesRepo.Get(RealEstate.Id);
				oldRealEstate.Area = RealEstate.Area;
				oldRealEstate.NoBeds = RealEstate.NoBeds;
				oldRealEstate.Country = RealEstate.Country;
				oldRealEstate.City = RealEstate.City;
				oldRealEstate.Address = RealEstate.Address;
				oldRealEstate.Owner = RealEstate.Owner;

				reLenderService.SaveChanges();
			});
			view.ShowDialog();

			await RefreshData();
		}

		private async void deleteBtn_Click(object sender, RoutedEventArgs e)
		{
			reLenderService.RealEstatesRepo.Remove(SelectedItem.Id);
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
			var window = new AddRealEstateView(reLenderService.RealEstateOwnersRepo.GetAll(), onSubmit: realEstate =>
			{
				this.reLenderService.RealEstatesRepo.Create(realEstate);
				this.reLenderService.SaveChanges();
			});

			window.ShowDialog();

			await RefreshData();
		}

		private async Task RefreshData()
		{
			RealEstates.Clear();
			var updatedData = await Task.Run(() => reLenderService.RealEstatesRepo.GetAll().ToList());
			updatedData.ForEach(a => RealEstates.Add(a));
		}

		private async void onLoaded(object sender, RoutedEventArgs e)
		{
			await RefreshData();
		}
	}
}
