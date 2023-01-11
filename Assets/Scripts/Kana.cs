using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kana : MonoBehaviour
{
	KanaFactory originFactory;

    [SerializeField] GameObject TextPrefab;


	//List of valid kanas
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

	//Called on initalize inside of KanaFactory.cs
	public void Init()
    {
		GenerateKanaText();
    }





    public void GenerateKanaText()
    {
		kana_text = kanas[Random.Range(0, kanas.Length)];
		GameObject newText = Instantiate(TextPrefab);
		newText.transform.SetParent(gameObject.transform);
		newText.transform.position = this.transform.position + textOffset;
		TMPro.TextMeshPro textMeshPro = newText.GetComponent<TMPro.TextMeshPro>();
		textMeshPro.text = kana_text;



	}


	//Recycle object, currently just deletes it
	public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
