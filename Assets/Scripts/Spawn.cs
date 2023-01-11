using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{


    Kana currentKana;
    [SerializeField]
    public Transform spawnPoint;

    public void DeleteKana()
    {
        currentKana.Recycle();
        currentKana = null;
    }



}
