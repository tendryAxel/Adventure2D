using System.Collections.Generic;
using UnityEngine;

public class AbstractContentManager : MonoBehaviour
{
    [SerializeField]
    protected int MaxCapacity;

    [SerializeField]
    protected List<ItemData> contents;

    // Modification Action register
    private OnUpdateActionsRegister<int> onContentCountChange = new();

    public OnUpdateActionsRegister<int> GetOnContentCountChange()
    {
        return onContentCountChange;
    }

    protected void UpdateContentCount()
    {
        onContentCountChange.Update(contents.Count);
    }

    protected int GetMaxCapacity()
    {
        return MaxCapacity;
    }

    public List<ItemData> GetContents()
    {
        return contents;
    }

    protected int GetContentCount()
    {
        return contents.Count;
    }

    protected void AddContents(ItemData item)
    {
        contents.Add(item);
        UpdateContentCount();
    }

    protected void RemoveFromContents(ItemData item)
    {
        if (!contents.Contains(item))
        {
            throw new ContainerDontContainException(this, item);
        }
        contents.Remove(item);
        UpdateContentCount();
    }

    protected bool IsNotFull()
    {
        return GetContentCount() < GetMaxCapacity();
    }

    protected void MoveTo(ItemData item, AbstractContentManager from)
    {
        if (!IsNotFull())
        {
            throw new IsContentFullException(this);
        }
        /*
        Debug.Log("Start exchange... between " + from + " to " + this);
        Debug.Log("From content: " + from.GetContents());
        Debug.Log("To content: " + GetContents());
        */
        
        from.RemoveFromContents(item);
        AddContents(item);
        
        /*
        Debug.Log("End exchange... between " + from + " to " + this);
        Debug.Log("From content: " + from.GetContents());
        Debug.Log("To content: " + GetContents());
        */
    }
}

[System.Serializable]
public class IsContentFullException : System.Exception
{
    public IsContentFullException(AbstractContentManager container) : base("Conatiner " + container + " is full") { }
}

[System.Serializable]
public class ContainerDontContainException : System.Exception
{
    public ContainerDontContainException(AbstractContentManager container, ItemData item) : base("Container " + container + " don't any contains " + item) { }
}
