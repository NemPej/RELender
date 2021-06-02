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
	/// Interaction logic for AddPersonView.xaml
	/// </summary>
	public partial class AddPersonView : Window
	{
		private Person data = new Person();
		private readonly Action<Person> onSubmit;

		public Person Person
		{
			get => data;
			set
			{
				data = value;
				FirstNameInput.Text = data.Name;
				LastNameInput.Text = data.Surname;
				PhoneNoInput.Text = data.PhoneNo;
				EmailInput.Text = data.Email;
			}
		}

		public AddPersonView(Action<Person> onSubmit = null)
		{
			InitializeComponent();

			this.onSubmit = onSubmit;
		}

		public AddPersonView(Person person, Action<Person> onSubmit) : this(onSubmit)
		{
			this.Person = person;
		}

		private void OnSubmit(object sender, RoutedEventArgs e)
		{
			string errorMsg = ValidateInputs();

			if (errorMsg != "")
			{
				MessageBox.Show(errorMsg, "error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			Person.Name = FirstNameInput.Text;
			Person.Surname = LastNameInput.Text;
			Person.PhoneNo = PhoneNoInput.Text;
			Person.Email = EmailInput.Text;

			this.onSubmit?.Invoke(Person);

			Close();
		}

		private string ValidateInputs()
		{
			string errorMsg = "";

			if (FirstNameInput.Text == "")
			{
				errorMsg += "first name cannot be empty\n";
			}

			if (LastNameInput.Text == "")
			{
				errorMsg += "last name cannot be empty\n";
			}

			return errorMsg;
		}
	}
}
