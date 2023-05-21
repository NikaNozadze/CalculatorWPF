using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace _2_Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			foreach (UIElement el in MainRoot.Children)
			{
				if (el is Button)
				{
					((Button)el).Click += Button_Click;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//OriginalSource - anu originals viyenebt. Content - mis kontents viyenebt
			string str = (string)((Button)e.OriginalSource).Content;

			try
			{
				if (str == "AC")
				{
					TextLabel.Text = string.Empty;
				}
				else if (str == "=")
				{
					string? value = new DataTable().Compute(TextLabel.Text, null).ToString();
					TextLabel.Text = value;
				}
				else
				{
					//cifrebi gverdigverd rom daiweros
					TextLabel.Text += str;
				}
			}
			catch
			{
				TextLabel.Text = "ERROR";
			}
		}
	}
}
