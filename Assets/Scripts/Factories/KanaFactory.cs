using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu]
public class KanaFactory : ScriptableObject
{

    Scene contentScene;


    [SerializeField]
    private Kana kanaPrefab;
   

    /// <summary>
    /// Gets a default Kana object and initalizes it.
    /// </summary>
    /// <returns></returns>
    Kana GetKana(Spawn spawn)
    {
        Kana instance = Instantiate(kanaPrefab);
        instance.OriginFactory = this;
        instance.Init(spawn);
        MoveToFactoryScene(instance.gameObject);
        return instance;
    }


    /// <summary>
    /// Gets a Kana Object
    /// TODO: Add support for more Kana types to easily change difficulties and slowly introduce new kana
    /// </summary>
    /// <returns></returns>
    public Kana Get(Spawn spawn)
    {
        return GetKana(spawn);
    }


    /// <summary>
    /// Move instance to the content scene 
    /// If in editor check if the scene already exists incase of a hot reload
    /// </summary>
    /// <param name="o">The game object to be moved</param>
    void MoveToFactoryScene (GameObject o)
    {
        if (!contentScene.isLoaded)
        {
            if (Application.isEditor)
            {
                contentScene = SceneManager.GetSceneByName(name);
                if (!contentScene.isLoaded)
                {
                    contentScene = SceneManager.CreateScene(name);
                }
            }
            else
            {
                contentScene = SceneManager.CreateScene(name);
            }
        }
        SceneManager.MoveGameObjectToScene(o, contentScene);
    }









    /// <summary>
    /// Recycle the GameObject, currently just deletes it
    /// </summary>
    /// <param name="kana">The object to recycle</param>
    public void Reclaim(Kana kana)
    {
        Debug.Assert(kana.OriginFactory == this, "Wrong factory reclaimed!");
        Destroy(kana.gameObject);
    }



}
