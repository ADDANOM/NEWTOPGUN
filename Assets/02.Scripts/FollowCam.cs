using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    private Transform tr;
    public Transform target;

    public float distance = 3f;
    public float height = 2f;
    public float hoffset = 2f;

    public float damping = 10f;

    void Start()
    {
        tr = transform.parent.GetComponent<Transform>();
    }

    void LateUpdate()
    {

        tr.position = target.position + new Vector3(0, 4.3f, -12.8f);
        tr.rotation = new Quaternion(0.1358092f, 0f, 0f, 0.9907351f);

    }
}
