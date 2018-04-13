using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordArray : MonoBehaviour {

	public List<Word> words;

	void Awake()
	{
		words = new List<Word> ();
	}

	public void BuildArray()
	{
		words.Add(new Word("Wheat", "Пшеница", "Plants"));
		words.Add(new Word("Bracken", "Папоротник", "Plants"));
		words.Add(new Word("Nettle", "Крапива", "Plants"));
		words.Add(new Word("Carnation", "Гвоздика", "Plants"));
        words.Add(new Word("Poppy", "Мак", "Plants"));
        words.Add(new Word("Birch", "Берёза", "Plants"));
        words.Add(new Word("Oak", "Дуб", "Plants"));
        words.Add(new Word("Poplar", "Тополь", "Plants"));
        words.Add(new Word("Willow", "Ива", "Plants"));
        words.Add(new Word("Dahlia", "Георгин", "Plants"));
        words.Add(new Word("Daisy", "Маргаритка", "Plants"));
        words.Add(new Word("Snowdrop", "Подснежник", "Plants"));
        words.Add(new Word("Bluebell", "Колокольчик", "Plants"));
        words.Add(new Word("Moss", "Мох", "Plants"));
        words.Add(new Word("Fir", "Пихта", "Plants"));
        words.Add(new Word("Lime", "Липа", "Plants"));
        words.Add(new Word("Maple", "Клён", "Plants"));
        words.Add(new Word("Pine", "Ель/Сосна", "Plants"));
        words.Add(new Word("Hawthom", "Боярышник", "Plants"));
        words.Add(new Word("Tulip", "Тюльпан", "Plants"));

        words.Add(new Word("Badger", "Барсук", "Animals"));
		words.Add(new Word("Stork", "Аист", "Animals"));
		words.Add(new Word("Viper", "Гадюка", "Animals"));
		words.Add(new Word("Caterpillar", "Гусеница", "Animals"));
        words.Add(new Word("Lark", "Жаворонок", "Animals"));
        words.Add(new Word("Beetle", "Жук", "Animals"));
        words.Add(new Word("Crane", "Журавль", "Animals"));
        words.Add(new Word("Gnat", "Комар", "Animals"));
        words.Add(new Word("Grassshopper", "Кузнечик", "Animals"));
        words.Add(new Word("Elk", "Лось", "Animals"));
        words.Add(new Word("Wasp", "Оса", "Animals"));
        words.Add(new Word("Peacock", "Павлин", "Animals"));
        words.Add(new Word("Lynx", "Рысь", "Animals"));
        words.Add(new Word("Ostich", "Страус", "Animals"));
        words.Add(new Word("Ferret", "Хорёк", "Animals"));
        words.Add(new Word("Heron", "Цапля", "Animals"));
        words.Add(new Word("Hawk", "Ястреб", "Animals"));
        words.Add(new Word("Falcon", "Сокол", "Animals"));
        words.Add(new Word("Hare", "Заяц", "Animals"));
        words.Add(new Word("Magpie", "Сорока", "Animals"));

        words.Add(new Word("Yeast", "Дрожжи", "Food"));
		words.Add(new Word("Ketchup", "Кетчуп", "Food"));
		words.Add(new Word("Strach", "Крахмал", "Food"));
		words.Add(new Word("Beet", "Свекла", "Food"));
        words.Add(new Word("Plum", "Слива", "Food"));
        words.Add(new Word("Vinegar", "Уксус", "Food"));
        words.Add(new Word("Persimmon", "Хурма", "Food"));
        words.Add(new Word("Cottage cheese", "Творог", "Food"));
        words.Add(new Word("Sour", "Сметана", "Food"));
        words.Add(new Word("Flour", "Мука", "Food"));
        words.Add(new Word("Caviar", "Икра", "Food"));
        words.Add(new Word("Fig", "Инжир", "Food"));
        words.Add(new Word("Date", "Финик", "Food"));
        words.Add(new Word("Porrige", "Каша", "Food"));
        words.Add(new Word("Dumplings", "Пельмени", "Food"));
        words.Add(new Word("Seasoning", "Приправа", "Food"));
        words.Add(new Word("Juice", "Сок", "Food"));
        words.Add(new Word("Pie", "Пирог", "Food"));
        words.Add(new Word("Pistachio", "Фисташка", "Food"));
        words.Add(new Word("Mustard", "Горчица", "Food"));

        words.Add(new Word("Buggy", "Коляска", "Baby goods"));
		words.Add(new Word("Nursery", "Бутылочка для кормления", "Baby goods"));
		words.Add(new Word("Potty", "Горшок", "Baby goods"));
		words.Add(new Word("Nibbler", "Соска для еды", "Baby goods"));
        words.Add(new Word("Bib", "Слюнявчик", "Baby goods"));
        words.Add(new Word("Cradle", "Люлька", "Baby goods"));
        words.Add(new Word("Beanbang", "Погремушка", "Baby goods"));
        words.Add(new Word("Diaper", "Подгузники", "Baby goods"));
        words.Add(new Word("Baby powder", "Присыпка детская", "Baby goods"));
        words.Add(new Word("Soother", "Соска-пустышка", "Baby goods"));
        words.Add(new Word("Baby monitor", "Радио-няня", "Baby goods"));
        words.Add(new Word("Teethers", "Прорезыватель для зубов", "Baby goods"));
        words.Add(new Word("Footmoof", "Конверт прогулочный", "Baby goods"));
        words.Add(new Word("Sliders", "Ползунки", "Baby goods"));
        words.Add(new Word("Changing board", "Пеленальная доска", "Baby goods"));
        words.Add(new Word("Drinker", "Поильник", "Baby goods"));
        words.Add(new Word("Overalls", "Комбинезон", "Baby goods"));
        words.Add(new Word("Walker", "Ходунки", "Baby goods"));
        words.Add(new Word("Play-bed", "Кровать-манеж", "Baby goods"));
        words.Add(new Word("Bootees", "Пинетки", "Baby goods"));

    }

	public string GetCategoryOfWord(string w)
	{
		string s="";
		foreach (Word ww in words) {
			if (ww.word == w) {
				s = ww.category;
				break;
			}
		}
		return s;
	}

	public List<string> GetWordsOfCategory(string c)
	{
		List<string> cats = new List<string> ();
		foreach (Word w in words) {
			if (w.category == c)
				cats.Add (w.word);
		}
		print (cats.Count);
		return cats;
	}

	public string GetDescriptionOfWord(string w)
	{
		string d = "";
		foreach(Word ww in words)
		{
			if (ww.word == w) {
				d = ww.description;
				break;
			}
		}
		return d;
	}

	public List<string> CreateListForGame(string[] cats)
	{
		System.Random r = new System.Random ();
        List<string> result = new List<string>();
		foreach (string c in cats) {
			List<string> wordsCat = GetWordsOfCategory (c);
            /*
			Debug.Log (wordsCat.Count);
			Debug.Log ("|"+c+"|");
			int i = 0;
			while (i < 5) {
				int ii = r.Next () % wordsCat.Count;
				if (!result.Contains (wordsCat [ii])) {
					i++;
					result.Add (wordsCat [ii]);
				}
			}
            */
            wordsCat.OrderBy(x=>r.Next()).Take(4);
            foreach (string s in wordsCat)
            {
                result.Add(s);
            }            
		}

		result = Shuffle (result);
		return result;
	}

	public List<string> Shuffle(List<string> list)  
	{
        System.Random rng = new System.Random();
        int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			string value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}
		return list;
	}
}
