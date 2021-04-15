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
    public partial class StockVibrato : ContentPage
    {
        static NS_WS.WS_GUITARESoapClient Le_WS;

        static List<NS_WS.C_VIBRATO> Les_Vibrato = new List<NS_WS.C_VIBRATO>();

        public StockVibrato()
        {
            InitializeComponent();

            Le_WS = new NS_WS.WS_GUITARESoapClient(NS_WS.WS_GUITARESoapClient.EndpointConfiguration.WS_GUITARESoap12);


            foreach (NS_WS.C_VIBRATO item in Le_WS.GetVibrato())
            {
                Les_Vibrato.Add(item);
            }

            Task.Factory.StartNew(() =>
            {
                ListeVibrato.ItemsSource = Les_Vibrato;
            });
        }
    }

}