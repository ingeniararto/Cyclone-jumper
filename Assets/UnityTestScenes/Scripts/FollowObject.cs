using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Reference to the object to follow
    public Vector3 offset; // Offset to apply between the camera and the target object

    private void Update()
    {
        // Update the camera's position based on the target object's position
        transform.position = new Vector3(transform.position.x, target.position.y+3, transform.position.z);
    }
}