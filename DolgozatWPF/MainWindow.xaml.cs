using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DolgozatWPF
{
    class Dolgozat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }

        public Dolgozat(string nev, int eletkor, int pontszam)
        {
            this.Nev = nev;
            this.Eletkor = eletkor;
            this.Pontszam = pontszam;
        }
    }

    public partial class MainWindow : Window
    {
        List<Dolgozat> dolgozatok = new List<Dolgozat>();

        public MainWindow()
        {
            InitializeComponent();
            dolgozatok.Add(new Dolgozat("Kiss Péter", 16, 87));
            dolgozatok.Add(new Dolgozat("Nagy Anna", 17, 92));
            dolgozatok.Add(new Dolgozat("Szabó Tamás", 16, 78));
            dolgozatok.Add(new Dolgozat("Tóth Éva", 18, 95));
            dolgozatok.Add(new Dolgozat("Varga Bence", 17, 81));
            dolgozatok.Add(new Dolgozat("Horváth Zsolt", 16, 65));
            dolgozatok.Add(new Dolgozat("Molnár Réka", 18, 89));
            dolgozatok.Add(new Dolgozat("Lakatos Dániel", 17, 72));
            dgDolgozatok.ItemsSource = dolgozatok;
        }

        private void btnHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            dolgozatok.Add(new Dolgozat(txtNev.Text, int.Parse(txtEletkor.Text), int.Parse(txtPontszam.Text)));
            dgDolgozatok.Items.Refresh();
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> sorok = new List<string>();
            foreach (var d in dolgozatok)
            {
                sorok.Add($"{d.Nev};{d.Eletkor};{d.Pontszam}");
            }
            File.WriteAllLines("dolgozatok.txt", sorok);
            MessageBox.Show("Sikeres mentés!");
        }
    }
}
