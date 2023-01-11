using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kana : MonoBehaviour
{
	KanaFactory originFactory;

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


    public KanaFactory OriginFactory
	{
		get => originFactory;
		set
		{
			Debug.Assert(originFactory == null, "Redefined origin factory!");
			originFactory = value;
		}
	}


	void GenerateKanaText()
    {
		kana_text = kanas[Random.Range(0, kanas.Length)];

		//Generate text mesh



	}


	//Recycle object, currently just deletes it
	public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
