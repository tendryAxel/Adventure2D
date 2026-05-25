using UnityEngine;

public class AbstractContentManager : MonoBehaviour
{
    // TODO: rename that to AnyContentData
    [SerializeField]
    private ChestContentData chestContent;

    public ChestContentData GetContentData()
    {
        return chestContent;
    }

    public bool CanBeMovedInto(ItemData item)
    {
        return IsNotFull();
    }

    public bool IsNotFull()
    {
        return chestContent.GetContentCount() < chestContent.GetMaxCapacity();
    }

    public void MoveTo(ItemData item, ChestContentData from)
    {
        if (!CanBeMovedInto(item))
        {
            Debug.LogWarning("Item " + item + " cannot be moved into " + this);
        }
        /*
        Debug.Log("Start exchange... between " + from + " to " + this);
        Debug.Log("From content: " + from.GetContents());
        Debug.Log("To content: " + chestContent.GetContents());
        */
        
        from.RemoveFromContents(item);
        chestContent.AddContents(item);
        
        /*
        Debug.Log("End exchange... between " + from + " to " + this);
        Debug.Log("From content: " + from.GetContents());
        Debug.Log("To content: " + chestContent.GetContents());
        */
    }
}
