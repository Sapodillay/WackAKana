using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    

    [SerializeField] KanaManager kanaManager;

    /// <summary>
    /// Amount of kanas to spawn per minute
    /// Can be changed at runtime, will be changed after next spawn
    /// </summary>
    [SerializeField] float spawnsPerSecond = 3;
    float i;

    private void Awake()
    {
        i = spawnsPerSecond;
    }

    private void Spawn()
    {
        kanaManager.SpawnNewKana();
    }


    private void Update()
    {

        //Spawn kana every second
        if(Time.time > i)
        {
            i += spawnsPerSecond;
            Spawn();
        }
    }





}

