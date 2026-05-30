using System.Linq;

public class ChestContentManagement : AbstractContentManager
{
    private ItemData selectItem;

    public ItemData GetSelectedItem()
    {
        if (GetContentCount() == 0)
        {
            throw new GetFromEmptyChestException(this);
        }

        if (selectItem == null)
        {
            return GetContents().First();
        }

        return selectItem;
    }

    public void SetSelectedItem(ItemData itemData)
    {
        if (!GetContents().Contains(itemData))
        {
            throw new ContainerDontContainException(this, itemData);
        }

        selectItem = itemData;
    }
}

[System.Serializable]
public class GetFromEmptyChestException : System.Exception
{
    public GetFromEmptyChestException(ChestContentManagement chest) : base("This chest " + chest + " is empty") { }
}
