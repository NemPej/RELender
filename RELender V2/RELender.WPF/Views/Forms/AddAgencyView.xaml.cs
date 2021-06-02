using RELender.BLL.Models;
using System;
using System.Collections.Generic;
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
	/// Interaction logic for AddAgencyView.xaml
	/// </summary>
	public partial class AddAgencyView : Window
	{
		private Agency data = new Agency();
		private readonly Action<Agency> onSubmit;

		public Agency Agency
		{
			get => data;
			set
			{
				data = value;
				NameInput.Text = data.Name;
			}
		}

		public AddAgencyView(Action<Agency> onSubmit = null)
		{
			InitializeComponent();

			this.onSubmit = onSubmit;
		}

		public AddAgencyView(Agency agency, Action<Agency> onSubmit) : this(onSubmit)
		{
			this.Agency = agency;
		}

		private void OnSubmit(object sender, RoutedEventArgs e)
		{
			string errorMsg = ValidateInputs();

			if (errorMsg != "")
			{
				MessageBox.Show(errorMsg, "error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			Agency.Name = NameInput.Text;

			this.onSubmit?.Invoke(Agency);

			Close();
		}

		private string ValidateInputs()
		{
			string errorMsg = "";

			if (NameInput.Text == "")
			{
				errorMsg += "name cannot be empty\n";
			}


			return errorMsg;
		}
	}
}
