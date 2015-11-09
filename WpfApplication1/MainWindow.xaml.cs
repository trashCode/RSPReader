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
    public class Oiseau
    {
        public string nom { get; set; }
        public Int32 envergure { get; set; }


        public Oiseau()
        {

        }
        public Oiseau(string nom, Int32 envergure)
        {
            this.nom = nom;
            this.envergure = envergure;
        }
    }

    public partial class MainWindow : Window
    {
        

        List<Oiseau> vivarium = new List<Oiseau>();
        ObservableCollection<Oiseau> liveArium = new ObservableCollection<Oiseau>();

        public MainWindow()
        {
            InitializeComponent();
            liveArium.Add(new Oiseau("canard mandarin", 12));
            liveArium.Add(new Oiseau("canard breton", 22));
            liveArium.Add(new Oiseau("albatros", 90));
            lbVivarium.ItemsSource = liveArium;
            tvVivarium.ItemsSource = liveArium;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Oiseau o = new Oiseau(textNom.Text , Int32.Parse(textEnvergure.Text));
            liveArium.Add(o);
            

        }


        //Remove supprime le dernier element du vivarium
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (liveArium.Count > 0)
            {
                string btnText = liveArium.Last().nom;
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
