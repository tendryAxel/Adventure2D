using UnityEngine;

[System.Serializable]
public class InteracableItemInfo
{
    [SerializeField]
    private ItemData info;

    public ItemData GetInfo()
    {
        return info;
    }
}
