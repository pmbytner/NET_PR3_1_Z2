using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace NET_PR3_1_Z2;
/// <summary>
/// Logika interakcji dla klasy ListaOsób.xaml
/// </summary>
public partial class ListaOsób : Window
{
	private const string ścieżkaIO = "listaOsób.xml";
	public ObservableCollection<Osoba> Osoby { get; set; } = new ObservableCollection<Osoba>();

	ListBox lista;
	public ListaOsób()
	{
		DataContext = this;
		InitializeComponent();
		lista = (ListBox)this.FindName("Lista");
	}

	private void Edytuj(object sender, RoutedEventArgs e)
	{
		new WidokOsoby(
			(Osoba)lista.SelectedItem
			).Show();
	}

	private void Dodaj(object sender, RoutedEventArgs e)
	{
		Osoba nowa = new Osoba();
		Osoby.Add(nowa);
		new WidokOsoby(
			nowa
			).Show();
	}

	private void Usuń(object sender, RoutedEventArgs e)
	{
		Osoby.Remove(
			(Osoba)lista.SelectedItem
			);
	}

	private void Importuj(object sender, RoutedEventArgs e)
    {
        XmlSerializer serializator
            = new XmlSerializer(typeof(ObservableCollection<Osoba>));
		FileStream strumieńOdczytu = new FileStream(ścieżkaIO, FileMode.Open);
		ObservableCollection<Osoba> osoby
			= (ObservableCollection<Osoba>)serializator.Deserialize(
				strumieńOdczytu
				);
		//Osoby = osoby; //nie działa, bo wiązanie jest do instancji
		strumieńOdczytu.Close();
		foreach (Osoba osoba in osoby)
			Osoby.Add(osoba);
    }

	private void Eksportuj(object sender, RoutedEventArgs e)
	{
		XmlSerializer serializator
			= new XmlSerializer(typeof(ObservableCollection<Osoba>));
		TextWriter strumieńZapisu = new StreamWriter(ścieżkaIO);
		serializator.Serialize(strumieńZapisu, Osoby);
		strumieńZapisu.Close();
	}
}
