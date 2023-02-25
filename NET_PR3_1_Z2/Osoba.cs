using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_PR3_1_Z2;
public class Osoba : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	private static Dictionary<string, ICollection<string>> powiązaneWłaściwości
		= new Dictionary<string, ICollection<string>>()
	{
		["Imię"] = new string[] { "ImięNazwisko" },
		["Nazwisko"] = new string[] { "ImięNazwisko" },
		["ImięNazwisko"] = new string[] { "FormatWitaj" },
		["DataUrodzenia"] = new string[] { "Wiek" },
		["DataŚmierci"] = new string[] { "Wiek" }
	};
	void NotyfikujZmianę(
		[CallerMemberName] string? nazwaWłaściwości = null,
		HashSet<string> jużZrobione = null
		)
	{
		if (jużZrobione == null)
			jużZrobione = new();
		PropertyChanged?.Invoke(
			this,
			new PropertyChangedEventArgs(nazwaWłaściwości)
			);
		jużZrobione.Add(nazwaWłaściwości);
		if (powiązaneWłaściwości.ContainsKey(nazwaWłaściwości))
			foreach (string powiązanaWłaściwość in powiązaneWłaściwości[nazwaWłaściwości])
				if(jużZrobione.Contains(powiązanaWłaściwość) == false)
					NotyfikujZmianę(powiązanaWłaściwość, jużZrobione);
	}

	private string
		imię,
		nazwisko
		;
	private DateTime?
		dataUrodzenia = null,
		dataŚmierci = null
		;

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
	public DateTime? DataUrodzenia {
		get => dataUrodzenia;
		set
		{
			dataUrodzenia = value;
			NotyfikujZmianę();
		}
	}
	public DateTime? DataŚmierci {
		get => dataŚmierci;
		set
		{
			dataŚmierci = value;
			NotyfikujZmianę();
		}
	}

	public string ImięNazwisko => $"{imię} {nazwisko}";
	public string FormatWitaj => $"Witaj, {ImięNazwisko}";
	public ushort? Wiek
	{
		get
		{
			if (dataUrodzenia == null)
				return null;
			DateTime? koniec;
			if (dataŚmierci == null)
				koniec = DateTime.Now;
			else
				koniec = dataŚmierci;
			TimeSpan różnica = (TimeSpan)(koniec - dataUrodzenia);
			return (ushort)Math.Floor(różnica.Days / 365.25);
		}
	}
}
