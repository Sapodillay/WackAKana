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
		"い:I",
		"う:U",
		"え:E",
		"お:O",
	};

    public static string[] KKanas = new string[]
	{
        "か:KA",
        "き:KI",
        "く:KU",
        "け:KE",
        "こ:KO",
	};

    public static string[] SKanas = new string[]
	{
        "さ:SA",
        "し:SHI",
        "す:SU",
        "せ:SE",
        "そ:SO",
	};

    public static string[] TKanas = new string[]
	{
        "た:TA",
        "ち:CHI",
        "つ:TSU",
        "て:TE",
        "と:TO",
	};

    public static string[] NKanas = new string[]
	{
        "な:NA",
        "に:NI",
        "ぬ:NU",
        "ね:NE",
        "の:NO",
	};

    public static string[] HKanas = new string[]
	{
        "は:HA",
        "ひ:HI",
        "ふ:FU",
        "へ:HE",
        "ほ:HO",
	};

    public static string[] MKanas = new string[]
	{
        "ま:MA",
        "み:MI",
        "む:MU",
        "め:ME",
        "も:MO",
	};

    public static string[] YKanas = new string[]
    {
        "や:YA",
        "ゆ:YU",
        "よ:YO",
    };

    public static string[] RKanas = new string[]
    {
        "ら:RA",
        "り:RI",
        "る:RU",
        "れ:RE",
        "ろ:RO",
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

    public Spawn Spawn
    { get { return _spawnPoint; } }
    Spawn _spawnPoint;


    [SerializeField] KanaManager kanaManager;

    [SerializeField] Renderer signRenderer;
    /// <summary>
    /// Material that displays the current decay of the Kana
    /// </summary>
    [SerializeField] Material progressMaterial;
    /// <summary>
    /// Amount of time in seconds for the object to decay and negate points to the player
    /// </summary>
    [SerializeField] float decay = 2;
	[SerializeField] TMPro.TextMeshPro textMesh;

    //Time at initalization
    float initTime;

    public KanaFactory OriginFactory
	{
		get => originFactory;
		set
		{
			Debug.Assert(originFactory == null, "Redefined origin factory!");
			originFactory = value;
		}
	}

    void MaterialSetup()
    {
        Material material = Instantiate(progressMaterial);
        signRenderer.material = material;
        progressMaterial = material;
        progressMaterial.SetFloat("_Radius", 0f);

    }


    /// <summary>
    /// Initalization code that is created at the start of GameObject lifetime inside of the KanaFactory.cs
    /// </summary>
    public void Init(Spawn spawn)
    {
        //Set init time to the current game time.
        initTime = Time.time;
        _spawnPoint = spawn;
        MaterialSetup();
        SetKanaText();
        kanaManager = FindObjectOfType<KanaManager>();
    }


    private void Update()
    {
        //Returns true after decay time of the object spawning
        if (-(initTime - Time.time) > decay)
        {
            //Destroy
            progressMaterial.SetFloat("_Radius", 0.58f);
            Recycle();
        }
        //Get the current progress, 0.58f is 100% progress for the progressMaterial
        float progress = Mathf.Lerp(0, 0.58f, -(initTime - Time.time) / decay);
        progressMaterial.SetFloat("_Radius", progress);
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
        kanaManager.recycleKana(this);
		originFactory.Reclaim(this);
    }









}
