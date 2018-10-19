using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XmMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

	    private void ListOfProductBtn_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new ListOfProducts());
	    }

	    private void CreateProductBtn_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new CreateProduct());
        }

	    private void UpdateProductBtn_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new UpdateProduct());
        }

	    private void DeleteProductBtn_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new DeleteProduct());
        }
	}
}