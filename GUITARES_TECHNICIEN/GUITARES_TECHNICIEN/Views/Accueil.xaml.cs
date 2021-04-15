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
    public partial class Accueil : ContentPage
    {

        static NS_WS.WS_GUITARESoapClient Le_WS;

        static List<NS_WS.C_GUITARE> Les_Guitares = new List<NS_WS.C_GUITARE>();

        public Accueil()
        {
            InitializeComponent();

            Le_WS = new NS_WS.WS_GUITARESoapClient(NS_WS.WS_GUITARESoapClient.EndpointConfiguration.WS_GUITARESoap12);


            foreach (NS_WS.C_GUITARE item in Le_WS.Select_Guitare())
            {
                Les_Guitares.Add(item);
            }

            Task.Factory.StartNew(() =>
            {
                listeGuitare.ItemsSource = Les_Guitares;
            });
        }

        public void On_btn_Click(object P_Sender, EventArgs P_Arg)
        {
            Task.Factory.StartNew(() =>
            {
                Le_WS.Add_Bois(Nom_Bois.Text, Origine.Text);

            });
        }
    }
}