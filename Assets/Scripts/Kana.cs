using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kana : MonoBehaviour
{
	KanaFactory originFactory;

    [SerializeField] GameObject TextPrefab;


	//List of valid kanas
	//TODO: Add all Kanas
	string[] kanas = new string[]
	{
		"KA",
		"KE",
		"KO",
		"KI",
		"KU"
	};

	public string kana_text;

	private Vector3 textOffset = new Vector3(0, 0.25f, -0.1f);


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
		GenerateKanaText();
    }




	/// <summary>
	/// Gets a random string from string[] kanas
	/// Initalizes a new text gameObject and sets the parent to the Kana GameObject
	/// also sets the transformation so that it is infront of the Kana Mesh and sets the text to the random text from string[] kanas.
	/// </summary>
    public void GenerateKanaText()
    {
		kana_text = kanas[Random.Range(0, kanas.Length)];
		GameObject newText = Instantiate(TextPrefab);
		newText.transform.SetParent(gameObject.transform);
		newText.transform.position = this.transform.position + textOffset;
		TMPro.TextMeshPro textMeshPro = newText.GetComponent<TMPro.TextMeshPro>();
		textMeshPro.text = kana_text;
	}


    /// <summary>
    /// Recycle object, currently just deletes it
    /// </summary>
    public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
