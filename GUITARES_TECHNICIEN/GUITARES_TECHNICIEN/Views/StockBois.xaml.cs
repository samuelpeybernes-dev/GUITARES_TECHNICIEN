using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GUITARES_TECHNICIEN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockBois : ContentPage
    {
        static NS_WS.WS_GUITARESoapClient Le_WS;

        static List<NS_WS.C_BOIS> Les_Bois = new List<NS_WS.C_BOIS>();

        public StockBois()
        {
            InitializeComponent();

            Le_WS = new NS_WS.WS_GUITARESoapClient(NS_WS.WS_GUITARESoapClient.EndpointConfiguration.WS_GUITARESoap12);


            foreach (NS_WS.C_BOIS item in Le_WS.GetBois())
            {
                Les_Bois.Add(item);
            }

            Task.Factory.StartNew(() =>
            {
                ListeBois.ItemsSource = Les_Bois;
            });
        }
    }

}