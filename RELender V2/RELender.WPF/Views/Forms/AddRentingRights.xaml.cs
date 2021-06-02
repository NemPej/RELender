using RELender.BLL.Models;
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

namespace RELender.WPF.Views.Forms
{
	/// <summary>
	/// Interaction logic for AddRentingRights.xaml
	/// </summary>
	public partial class AddRentingRights : Window
	{

		/// <summary>
		/// Interaction logic for AddRealEstateView.xaml
		/// </summary>
		private RentingRights data = new RentingRights();
		private readonly Action<RentingRights> onSubmit;

		public ObservableCollection<RealEstate> RealEstates { get; set; }
		public ObservableCollection<Agency> Agencies { get; set; }

		public Agency SelectedAgency { get; set; }
		public RealEstate SelectedRealEstate { get; set; }


		public RentingRights RentingRights
		{
			get => data;
			set
			{
				data = value;

				AgencyComboBox.SelectedItem = data.Agency;
				RealEstateComboBox.SelectedItem = data.RealEstate;
				CompensationInput.Text = data.OwnerCompensation.ToString();
				StartDatePicker.SelectedDate = data.StartDate;
				EndDatePicker.SelectedDate = data.EndDate;
			}
		}

		public AddRentingRights(IEnumerable<RealEstate> realEstates, IEnumerable<Agency> agencies, Action<RentingRights> onSubmit = null)
		{
			DataContext = this;
			this.RealEstates = new ObservableCollection<RealEstate>(realEstates);
			this.Agencies = new ObservableCollection<Agency>(agencies);

			InitializeComponent();
			this.onSubmit = onSubmit;
		}

		public AddRentingRights(RentingRights rentingRights, IEnumerable<RealEstate> realEstates, IEnumerable<Agency> agencies, Action<RentingRights> onSubmit) : this(realEstates, agencies, onSubmit)
		{
			this.RentingRights = rentingRights;
		}

		private void OnSubmit(object sender, RoutedEventArgs e)
		{
			string errorMsg = ValidateInputs();

			if (errorMsg != "")
			{
				MessageBox.Show(errorMsg, "error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			RentingRights.Agency = (Agency)AgencyComboBox.SelectedItem;
			RentingRights.RealEstate = (RealEstate)RealEstateComboBox.SelectedItem;
			RentingRights.OwnerCompensation = Int32.Parse(CompensationInput.Text);
			RentingRights.StartDate = StartDatePicker.SelectedDate.Value;
			RentingRights.EndDate = EndDatePicker.SelectedDate.Value;


			this.onSubmit?.Invoke(RentingRights);

			Close();
		}

		private string ValidateInputs()
		{
			string errorMsg = "";

			if (AgencyComboBox.SelectedItem == null)
			{
				errorMsg += "agency must be selected\n";
			}

			if (RealEstateComboBox.SelectedItem == null)
			{
				errorMsg += "real estate must be selected\n";
			}

			int res;

			if (!Int32.TryParse(CompensationInput.Text, out res))
			{
				errorMsg += "compensation must be a number\n";
			}
			else if (res <= 0)
			{
				errorMsg += "compensation must be positive number\n";
			}

			if (StartDatePicker.SelectedDate == null)
			{
				errorMsg += "start date must be selected\n";
			}

			if (EndDatePicker.SelectedDate == null)
			{
				errorMsg += "end date must be selected\n";
			}

			if (StartDatePicker.SelectedDate > EndDatePicker.SelectedDate)
			{
				errorMsg += "no";
			}


			return errorMsg;
		}
	}
}
