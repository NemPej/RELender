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
	public partial class AddRealEstateView : Window
	{


		/// <summary>
		/// Interaction logic for AddRealEstateView.xaml
		/// </summary>
		private RealEstate data = new RealEstate();
		private readonly Action<RealEstate> onSubmit;
		public ObservableCollection<RealEstateOwner> RealEstateOwners { get; set; }
		public RealEstateOwner SelectedRealEstateOwner { get; set; }

		public RealEstate RealEstate
		{
			get => data;
			set
			{
				data = value;
				AreaInput.Text = data.Area.ToString();
				NumberOfBedsInput.Text = data.NoBeds.ToString();
				CountryInput.Text = data.Country;
				CityInput.Text = data.City;
				AddressInput.Text = data.Address;
				OwnerComboBox.SelectedItem = data.Owner;
				//EmailInput.Text = data.;
			}
		}

		public AddRealEstateView(IEnumerable<RealEstateOwner> realEstateOwners, Action<RealEstate> onSubmit = null)
		{
			DataContext = this;
			this.RealEstateOwners = new ObservableCollection<RealEstateOwner>(realEstateOwners);

			InitializeComponent();
			this.onSubmit = onSubmit;
		}

		public AddRealEstateView(RealEstate realEstate, IEnumerable<RealEstateOwner> realEstateOwners, Action<RealEstate> onSubmit) : this(realEstateOwners, onSubmit)
		{
			this.RealEstate = realEstate;
		}

		private void OnSubmit(object sender, RoutedEventArgs e)
		{
			string errorMsg = ValidateInputs();

			if (errorMsg != "")
			{
				MessageBox.Show(errorMsg, "error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			RealEstate.Area = Int32.Parse(AreaInput.Text);
			RealEstate.NoBeds = Int32.Parse(NumberOfBedsInput.Text);
			RealEstate.Country = CountryInput.Text;
			RealEstate.City = CityInput.Text;
			RealEstate.Address = AddressInput.Text;
			RealEstateOwner owner = (RealEstateOwner)OwnerComboBox.SelectedItem;
			RealEstate.Owner = owner;
			RealEstate.OwnerId = owner.Id;
			//RealEstate.Email = EmailInput.Text;

			this.onSubmit?.Invoke(RealEstate);

			Close();
		}


		private string ValidateInputs()
		{
			string errorMsg = "";

			int res;

			if (!Int32.TryParse(AreaInput.Text, out res))
			{
				errorMsg += "area must be a number\n";
			} else if (res <= 0)
			{
				errorMsg += "area must be positive number\n";
			}


			if (!Int32.TryParse(NumberOfBedsInput.Text, out res))
			{
				errorMsg += "number of beds must be a number\n";
			}
			else if (res <= 0)
			{
				errorMsg += "number of beds must be positive number\n";
			}

			if (OwnerComboBox.SelectedItem == null)
			{
				errorMsg += "owner must be selected\n";
			}

			if (CountryInput.Text == "")
			{
				errorMsg += "country cannot be empty";
			}

			if (CityInput.Text == "")
			{
				errorMsg += "city cannot be empty";
			}

			if (AddressInput.Text == "")
			{
				errorMsg += "address cannot be empty";
			}

			return errorMsg;
		}

	}

}
