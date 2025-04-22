using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
        transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }
}
