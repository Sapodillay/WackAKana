using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanaManager : MonoBehaviour
{

    [SerializeField]
    KanaFactory factory;

    [SerializeField]
    Spawn[] spawns;

    [SerializeField]
    List<Spawn> freeSpawns = new List<Spawn>();
    [SerializeField]
    List<Spawn> occupiedSpawns = new List<Spawn>();

    List<Kana> kanaList = new List<Kana>();



    private void Awake()
    {

        //Fill free spawns
        foreach(Spawn spawn in spawns)
        {
            freeSpawns.Add(spawn);
        }


    }


    /// <summary>
    /// Gets a random Spawn that isn't occupied
    /// Moves the spawn from the freeSpawns array to the occupy spawn array
    /// </summary>
    /// <returns></returns>
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

    public void freeSpawn(Spawn spawn)
    {
        occupiedSpawns.Remove(spawn);
        freeSpawns.Add(spawn);
    }


    /// <summary>
    /// Spawn new Kana in a free spawn
    /// </summary>
    public void SpawnNewKana()
    {
        //Get random free spawn
        Spawn spawn = getRandomFreeSpawn();
        if(!spawn)
        {
            //Deal damage as their isn't any more kana spots
            return;
        }
        //Get new kana
        Kana k = factory.Get(spawn);

        //Set kana object to the spawn point and add vector to make kana visible
        k.transform.position = spawn.spawnPoint.position + Vector3.up;
        kanaList.Add(k);
    }

    /// <summary>
    /// Called from InputHandler.cs with the current text the user has submitted.
    /// </summary>
    /// <param name="submitText">Text submitted from InputHandler</param>
    public void Submit(string submitText)
    {

        foreach(Kana kana in kanaList)
        {
            if (submitText.Equals(kana.Text, System.StringComparison.OrdinalIgnoreCase))
            {
                //Handle success code
                kana.Recycle();
                return;
            }

        }

    }




    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            SpawnNewKana();
        }


    }

    internal void recycleKana(Kana kana)
    {
        kanaList.Remove(kana);
        freeSpawn(kana.Spawn);
        kanaList.Add(kana);
    }
}
