using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR3_1_Z2;
internal class Osoba : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs(propertyName)
			);
	}

	private string imię;
	private string nazwisko;

	public string Imię {
		get => imię;
		set {
			imię = value;
			OnPropertyChanged("Imię");
			OnPropertyChanged("ImięNazwisko");
		}
	}
	public string Nazwisko {
		get => nazwisko;
		set
		{
			nazwisko = value;
			OnPropertyChanged("Nazwisko");
			OnPropertyChanged("ImięNazwisko");
		}
	}
	public string ImięNazwisko => $"{imię} {nazwisko}";

}
