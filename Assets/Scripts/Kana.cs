using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

/// <summary>
/// Holds string romaji and string kana together
/// </summary>
struct KanaRomaji
{
	public string romaji;
	public string kana;
}

/// <summary>
/// Class for handling KanaData
/// </summary>
class KanaData : ScriptableObject
{

	public static string[] vowelKanas = new string[]
	{
		"あ:A",
		"え:E",
		"い:I",
		"お:O",
		"う:U",
	};

    public static string[] KKanas = new string[]
	{
        "か:KA",
        "け:KE",
        "き:KI",
        "こ:KO",
        "く:KU",
	};

    public static string[] SKanas = new string[]
	{
        "さ:SA",
        "せ:SE",
        "し:SHI",
        "そ:SO",
        "す:SU",
	};

    public static string[] TKanas = new string[]
	{
        "た:TA",
        "て:TE",
        "ち:CHI",
        "と:TO",
        "つ:TU",
	};

    public static string[] NKanas = new string[]
	{
        "な:NA",
        "ね:NE",
        "に:NI",
        "の:NO",
        "ぬ:NU",
	};

    public static string[] HKanas = new string[]
	{
        "は:HA",
        "へ:HE",
        "ひ:HI",
        "ほ:HO",
        "ふ:FU",
	};

    public static string[] MKanas = new string[]
	{
        "ま:MA",
        "め:ME",
        "み:MI",
        "も:MO",
        "む:MU",
	};

    public static string[] YKanas = new string[]
    {
        "や:YA",
        "ゆ:YU",
        "よ:YO",
    };

    public static string[] RKanas = new string[]
    {
        "ら:A",
        "れ:E",
        "り:I",
        "ろ:O",
        "る:U",
    };

    public static string[] EXTRAKanas = new string[]
    {
        "わ:WA",
        "を:WO",
        "ん:N",
    };







    public static string[] kanas = new string[] {
        "あ:A",
        "え:E",
        "い:I",
        "お:O",
        "う:U",
    };

    public static string[][] jaggedKanas = new string[10][]
    {
        vowelKanas,
        KKanas,
        SKanas,
        TKanas,
        NKanas,
        HKanas,
        MKanas,
        YKanas,
        RKanas,
        EXTRAKanas,
    };

    public static KanaRomaji GetRandomKanaALL()
    {
        List<String> allKanas = new List<string>();

        foreach (string[] kanaArray in jaggedKanas)
        {
            foreach(string eKana in kanaArray)
            {
                allKanas.Add(eKana);
            }

        }
        string[] kanaSplit = allKanas[UnityEngine.Random.Range(0, allKanas.Count)].Split(":");
        KanaRomaji kana = new KanaRomaji();
        kana.kana = kanaSplit[0];
        kana.romaji = kanaSplit[1];
        return kana;
    }


	/// <summary>
	/// Gets random KanaRomaji from current avalible pool of kanas
	/// </summary>
	/// <returns></returns>
	public static KanaRomaji GetRandomKana()
	{
		string[] kanaSplit = kanas[UnityEngine.Random.Range(0,kanas.Length)].Split(":");
        KanaRomaji kana = new KanaRomaji();
		kana.kana = kanaSplit[0];
		kana.romaji = kanaSplit[1];
		return kana;
    }

}



public class Kana : MonoBehaviour
{
	KanaFactory originFactory;

	string _text;
	public string Text
	{ get { return _text; } }


	//List of valid kanas
	//TODO: Add all Kanas


	[SerializeField] TMPro.TextMeshPro textMesh;


    public KanaFactory OriginFactory
	{
		get => originFactory;
		set
		{
			Debug.Assert(originFactory == null, "Redefined origin factory!");
			originFactory = value;
		}
	}

	/// <summary>
	/// Initalization code that is created at the start of GameObject lifetime inside of the KanaFactory.cs
	/// </summary>
	public void Init()
    {
        SetKanaText();
    }



	/// <summary>
	/// Generates a random kanas from string[] kanas and sets it as the textMeshPro text;
	/// </summary>
    public void SetKanaText()
    {
		//Random kanaRomaji
		KanaRomaji randomKana = KanaData.GetRandomKanaALL();

        
		//Set romanji to text
        _text = randomKana.romaji;
		//Set display text to kana
		textMesh.text = randomKana.kana;
	}


    /// <summary>
    /// Recycle object, currently just deletes it
    /// </summary>
    public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
