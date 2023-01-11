using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu]
public class KanaFactory : ScriptableObject
{

    Scene contentScene;


    [SerializeField]
    private Kana kanaPrefab;
   

    Kana GetKana()
    {
        Kana instance = Instantiate(kanaPrefab);
        instance.OriginFactory = this;
        MoveToFactoryScene(instance.gameObject);
        return instance;
    }


    public Kana Get()
    {
        return GetKana();
    }







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










    public void Reclaim(Kana kana)
    {
        Debug.Assert(kana.OriginFactory == this, "Wrong factory reclaimed!");
        Destroy(kana.gameObject);
    }



}
