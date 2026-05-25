using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestContentData", menuName = "Scriptable Objects/ChestContentData")]
public class ChestContentData : ScriptableObject
{
    [SerializeField]
    private int MaxCapacity;

    [SerializeField]
    private List<ItemData> contents;

    public int GetMaxCapacity()
    {
        return MaxCapacity;
    }

    public List<ItemData> GetContents()
    {
        return contents;
    }

    public int GetContentCount()
    {
        return contents.Count;
    }

    public void AddContents(ItemData item)
    {
        contents.Add(item);
    }

    public void RemoveFromContents(ItemData item)
    {
        if (!contents.Contains(item))
        {
            Debug.LogWarning("Chest " + this + " don't contains " + item);
        }
        contents.Remove(item);
    }
}
