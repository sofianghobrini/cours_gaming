using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyOnLoadScene instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scène");
            return;
        }
        instance = this;

        foreach (GameObject obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    } 

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (GameObject obj in objects)
        {
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
        }
    }
}
