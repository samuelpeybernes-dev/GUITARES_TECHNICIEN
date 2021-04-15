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
    public partial class StockMicro : ContentPage
    {
        static NS_WS.WS_GUITARESoapClient Le_WS;

        static List<NS_WS.C_MICROPHONE> Les_Micro = new List<NS_WS.C_MICROPHONE>();

        public StockMicro()
        {
            InitializeComponent();

            Le_WS = new NS_WS.WS_GUITARESoapClient(NS_WS.WS_GUITARESoapClient.EndpointConfiguration.WS_GUITARESoap12);


            foreach (NS_WS.C_MICROPHONE item in Le_WS.GetMicro())
            {
                Les_Micro.Add(item);
            }

            Task.Factory.StartNew(() =>
            {
                ListeMicro.ItemsSource = Les_Micro;
            });
        }
    }

}