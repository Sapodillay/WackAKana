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

    [SerializeField]
    List<Spawn> freeSpawns = new List<Spawn>();
    [SerializeField]
    List<Spawn> occupiedSpawns = new List<Spawn>();





    private void Awake()
    {

        //Fill free spawns
        foreach(Spawn spawn in spawns)
        {
            freeSpawns.Add(spawn);
        }





    }



    Spawn getRandomFreeSpawn()
    {
        if(freeSpawns.Count == 0)
            return null;


        int index = Random.Range(0, freeSpawns.Count);
        Spawn freeSpawn = freeSpawns[index];
        occupiedSpawns.Add(freeSpawn);
        freeSpawns.Remove(freeSpawn);
        //Move free spawn to occupied spawn and then spawn kana dont do this function withot spawning kana or then it will be stuck in limbop please dont do this i beg you
        

        return freeSpawn;
    }





    void SpawnNewKana()
    {
        //Get random free spawn
        Spawn spawn = getRandomFreeSpawn();
        if(!spawn)
        {
            //Deal damage as their isn't any more kana spots
            return;
        }
        //Get new kana
        Kana k = factory.Get();
        k.transform.position = spawn.spawnPoint.position;
        kanaList.Add(k);
    }





    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            //SpawnNewKana();
        }


    }





}
