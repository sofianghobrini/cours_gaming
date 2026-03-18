using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    void Awake()
    {
        foreach (GameObject obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
