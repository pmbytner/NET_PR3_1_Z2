using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR3_1_Z2;
internal class Osoba : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	private static Dictionary<string, ICollection<string>> powiązaneWłaściwości
		= new Dictionary<string, ICollection<string>>()
	{
		["Imię"] = new string[] { "ImięNazwisko" },
		["Nazwisko"] = new string[] { "ImięNazwisko" },
		["ImięNazwisko"] = new string[] { "FormatWitaj" },
	};
	void NotyfikujZmianę([CallerMemberName] string? nazwaWłaściwości = null)
	{
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs(nazwaWłaściwości)
			);
		if (powiązaneWłaściwości.ContainsKey(nazwaWłaściwości))
			foreach (string powiązanaWłaściwość in powiązaneWłaściwości[nazwaWłaściwości])
				PropertyChanged?.Invoke(
					this,
					new PropertyChangedEventArgs(powiązanaWłaściwość)
					);
	}

	private string imię;
	private string nazwisko;

	public string Imię {
		get => imię;
		set {
			imię = value;
			NotyfikujZmianę();
			//NotyfikujZmianę("ImięNazwisko");
		}
	}
	public string Nazwisko {
		get => nazwisko;
		set
		{
			nazwisko = value;
			NotyfikujZmianę();
			//NotyfikujZmianę("ImięNazwisko");
		}
	}
	public string ImięNazwisko => $"{imię} {nazwisko}";
	public string FormatWitaj => $"Witaj, {ImięNazwisko}";
}
