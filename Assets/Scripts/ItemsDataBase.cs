using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public static ItemsDataBase instance;

    public Items[] allItems;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ItemsDataBase dans la scène");
            return;
        }
        instance = this;
    }
}
