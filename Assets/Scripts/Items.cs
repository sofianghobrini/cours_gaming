using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Items : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite image;
    public string description;
    public int bonusHealth;
    public int bonusSpeed;
    public float speedDuration;
    public int price;
}