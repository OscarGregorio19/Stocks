using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stocks.ViewModels
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VM1 : ContentPage
	{
		public VM1 ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hola culeros xD " + DateTime.Now);
        }
    }
}