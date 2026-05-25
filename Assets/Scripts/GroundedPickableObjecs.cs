using UnityEngine;

public class GroundedPickableObjecs : MonoBehaviour
{
    private AbstractContentManager contentManager;

    void Start()
    {
        contentManager = GetComponent<AbstractContentManager>();
        contentManager.GetOnContentCountChange().RegisterOnUpdateActions(value => {
            if (value == 0)
            {
                Destroy(gameObject);
            }
        });
    }
}
