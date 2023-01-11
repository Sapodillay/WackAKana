using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kana : MonoBehaviour
{
	KanaFactory originFactory;
    public KanaFactory OriginFactory
	{
		get => originFactory;
		set
		{
			Debug.Assert(originFactory == null, "Redefined origin factory!");
			originFactory = value;
		}
	}


	//Recycle object, currently just deletes it
	public void Recycle()
    {
		originFactory.Reclaim(this);
    }









}
