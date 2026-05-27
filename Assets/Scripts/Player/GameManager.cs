using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CameraFollowBehavoir cameraFollowBehavoir;

    [SerializeField]
    private GameObject actualPlayer;

    void Update()
    {
        cameraFollowBehavoir.SetActualFocus(actualPlayer);
    }
}
