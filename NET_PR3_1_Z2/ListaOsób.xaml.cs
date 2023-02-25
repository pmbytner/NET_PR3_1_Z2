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

	ListBox lista;
	public ListaOsób()
	{
		DataContext = this;
		InitializeComponent();
		lista = (ListBox)this.FindName("Lista");
	}

	private void Edytuj(object sender, RoutedEventArgs e)
	{
		(new WidokOsoby(
			(Osoba)lista.SelectedItem
			)).Show();
	}

	private void Dodaj(object sender, RoutedEventArgs e)
	{
		Osoba nowa = new Osoba();
		Osoby.Add(nowa);
		(new WidokOsoby(
			nowa
			)).Show();
	}

	private void Usuń(object sender, RoutedEventArgs e)
	{
		Osoby.Remove(
			(Osoba)lista.SelectedItem
			);
	}
}
