public class GroundedPickableObjecs : AbstractContentManager
{
    void Start()
    {
        GetComponent<AbstractContentManager>();
        GetOnContentCountChange().RegisterOnUpdateActions(value => {
            if (value == 0)
            {
                Destroy(gameObject);
            }
        });
    }
}
