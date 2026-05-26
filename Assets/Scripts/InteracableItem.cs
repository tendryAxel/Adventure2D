using UnityEngine;

public class InteracableItem : MonoBehaviour
{
    [SerializeField]
    private ItemData info;

    public ItemData GetInfo()
    {
        return info;
    }
}
