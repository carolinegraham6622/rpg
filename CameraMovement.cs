using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // update always comes last, camera goes in late update (this prevents jerky camera)
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {

            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);

            //find distance between it and target and move percentage of distance each time
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
