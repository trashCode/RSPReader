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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApplication1.TreeView_control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Espece
    {
        public string titre { get; set; }
        public ObservableCollection<Oiseau> membres { get; set; }

        public Espece(string nom)
        {
            this.titre = nom;
            this.membres = new ObservableCollection<Oiseau>();
        }
    }
    
    public class Oiseau
    {
        public string nom { get; set; }
        public Int32 envergure { get; set; }
        public ObservableCollection<Oiseau> sous_especes {get;set;}

        

        public Oiseau()
        {
            this.sous_especes = new ObservableCollection<Oiseau>();
        }
        public Oiseau(string nom, Int32 envergure)
        {
            this.nom = nom;
            this.envergure = envergure;
            this.sous_especes = new ObservableCollection<Oiseau>();
        }
    }//Oiseau

    public partial class MainWindow : Window
    {
        

        List<Oiseau> vivarium = new List<Oiseau>();
        ObservableCollection<Espece> liveArium = new ObservableCollection<Espece>();

        public MainWindow()
        {
            InitializeComponent();
            Oiseau c1 = new Oiseau("canard", 10);
            c1.sous_especes.Add(new Oiseau("canard mandarin", 90));
            c1.sous_especes.Add(new Oiseau("col vert", 100));
            Espece e1 = new Espece("Grands");
            e1.membres.Add(new Oiseau("albatros", 90));
            liveArium.Add(e1);
            liveArium.Add(new Espece("petits"));
            liveArium[1].membres.Add(new Oiseau("canard commun", 25));
            liveArium[1].membres[0].sous_especes.Add(new Oiseau("canard col vert", 20));
            liveArium[1].membres[0].sous_especes.Add(new Oiseau("poule d'eau", 18));
            liveArium[1].membres.Add(new Oiseau("canard mandarin", 15));
            //lbVivarium.ItemsSource = liveArium;
            tvVivarium.ItemsSource = liveArium;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Oiseau o = new Oiseau(textNom.Text , Int32.Parse(textEnvergure.Text));
            //liveArium.Add(o);
            

        }


        //Remove supprime le dernier element du vivarium
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (liveArium.Count > 0)
            {
                liveArium.Remove(liveArium.Last());
            }
        }

        private void lbVivarium_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbVivarium.SelectedItem != null)
            {
                txtDetails.Text = (lbVivarium.SelectedItem as Oiseau).envergure.ToString();

            }
        }
    }
}
