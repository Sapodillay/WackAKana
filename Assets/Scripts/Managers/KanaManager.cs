using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanaManager : MonoBehaviour
{

    [SerializeField]
    KanaFactory factory;

    List<Kana> kanaList = new List<Kana>();
    [SerializeField]
    Spawn[] spawns;

    Spawn[] freeSpawns;
    Spawn[] occupiedSpawns;


    Spawn getRandomFreeSpawn()
    {
        int index = Random.Range(0, freeSpawns.Length);
        Spawn freeSpawn = spawns[index];
        //Move free spawn to occupied spawn and then spawn kana dont do this function withot spawning kana or then it will be stuck in limbop please dont do this i beg you
        

        return freeSpawn;
    }





    void SpawnNewKana()
    {
        Kana k = factory.Get();
        k.transform.position = spawns[Random.Range(0, spawns.Length)].spawnPoint.position;
        kanaList.Add(k);
    }





    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnNewKana();
        }


    }





}
