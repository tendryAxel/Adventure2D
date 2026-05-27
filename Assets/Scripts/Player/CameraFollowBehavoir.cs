using UnityEngine;

public class CameraFollowBehavoir : MonoBehaviour
{
    private GameObject actualFocus;

    [SerializeField]
    private float zOffset = -10;

    [SerializeField]
    private float smoothTime = 5;

    private Vector2 speed = Vector2.zero;

    void FollowAction()
    {
        if (!actualFocus) return;

        Vector2 newPosition2d = Vector2.SmoothDamp(transform.position, actualFocus.transform.position, ref speed, smoothTime);
        
        transform.position = new(newPosition2d.x, newPosition2d.y, zOffset);
    }

    void FixedUpdate()
    {
        FollowAction();
    }

    public void SetActualFocus(GameObject toFocus)
    {
        actualFocus = toFocus;
    }
}
