using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Kana : MonoBehaviour
{
	KanaFactory originFactory;

    [SerializeField] GameObject kanaImagePrefab;

	string _text;
	public string Text
	{ get { return _text; } }


	//List of valid kanas
	//TODO: Add all Kanas
	[SerializeField] Dictionary<string, Sprite> kanas = new Dictionary<string, Sprite>();







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
        CompileTextImage();
    }



	/// <summary>
	/// Generates a random kana from string[] kana_text and adds a image sprite from "Sprites/" kana_text[i] ".png"
	/// </summary>
    public void CompileTextImage()
    {
		//Random kana

		int index = Random.Range(0, kanas.Count);

		string kana_text = kanas.ElementAt(index).Key;
		Sprite kana_sprite = kanas.ElementAt(index).Value;

		//Instantiate image and set it's parent to the kana and position it infront of the kana
		GameObject kanaImage = Instantiate(kanaImagePrefab);
		kanaImage.transform.SetParent(gameObject.transform);
		kanaImage.transform.position = this.transform.position + textOffset;
		kanaImage.transform.localScale = Vector3.one / 2.2f;

        _text = kana_text;
	}


    /// <summary>
    /// Recycle object, currently just deletes it
    /// </summary>
    public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
