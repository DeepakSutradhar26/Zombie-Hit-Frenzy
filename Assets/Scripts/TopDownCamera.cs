using UnityEngine;

// Code for top down camera
public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public float smooth = 5f;
    public Vector3 offset = new Vector3(0, 15, 0);

    void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = targetPos;
    }
}