using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform targetTr;
    
    public float minDist = 20.0f;
    private float currDist = 0;
    public float rotDamping = 10.0f;
    public float moveSpeed = 20.0f;

    private Transform missileTr;
    private bool isPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        missileTr = transform;
        targetTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        currDist = Vector3.Distance(targetTr.position, missileTr.position);

        if (!isPassed && currDist > minDist)
        {
            Quaternion rot = Quaternion.LookRotation(targetTr.position - missileTr.position);
            missileTr.rotation = Quaternion.Slerp(missileTr.rotation, rot, Time.deltaTime * rotDamping);
        }
        else
        {
            isPassed = true;
        }

        missileTr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
}
