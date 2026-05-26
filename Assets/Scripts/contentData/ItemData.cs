using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    public string ItemName()
    {
        return itemName;
    }

    [SerializeField]
    private Texture2D itemImage;
    public Texture2D ItemImage()
    {
        return itemImage;
    }
}