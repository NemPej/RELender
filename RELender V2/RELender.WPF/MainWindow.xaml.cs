using RELender.BLL.Interfaces;
using RELender.WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RELender.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IRELenderService reLenderService;
		private IRELenderServiceFactory reLenderServiceFactory;
		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnClosed(EventArgs e)
		{
			reLenderService.Dispose();
			base.OnClosed(e);
		}

		private void Window_Loaded(object Sender, RoutedEventArgs e)
		{
			string connString = ConfigurationManager.AppSettings.Get("SelectedConnectionStringName");
			reLenderServiceFactory = new RELenderServiceFactory(connString);

			reLenderService = reLenderServiceFactory.Create();

			//reLenderService.AgentsRepo.Create(new BLL.Models.Agent() { Name = "Nemanja", Email = "n-pejic@outlook.com", PhoneNo = "064993412", Surname = "Pejic" });

			var agents = reLenderService.AgentsRepo.GetAll().ToList();
		}

		private void agentsButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new AgentsView(reLenderService);
			window.ShowDialog();
		}

		private void clientsButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new ClientsView(reLenderService);
			window.ShowDialog();
		}

		private void realEstateOwnerButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new RealEstateOwnersView(reLenderService);
			window.ShowDialog();
		}

		private void agencyButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new AgenciesView(reLenderService);
			window.ShowDialog();
		}

		private void realEstateButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new RealEsatesView(reLenderService);
			window.ShowDialog();
		}

		private void rentingRightsButton_Click(object sender, RoutedEventArgs e)
		{
			var window = new RentingRightsView(reLenderService);
			window.ShowDialog();
		}
	}
}
