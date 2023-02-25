using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace NET_PR3_1_Z2;
/// <summary>
/// Logika interakcji dla klasy ListaOsób.xaml
/// </summary>
public partial class ListaOsób : Window
{
	public ObservableCollection<Osoba> Osoby { get; } = new ObservableCollection<Osoba>();
	public ListaOsób()
	{
		DataContext = this;
		Osoby.Add(new Osoba() { Imię = "Adam"});
		Osoby.Add(new Osoba() { Imię = "Beata"});
		Osoby.Add(new Osoba() { Imię = "Cyprian"});
		InitializeComponent();
	}
}
