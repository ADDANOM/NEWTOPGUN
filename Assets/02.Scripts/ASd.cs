using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASd : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(200, 200, 400));
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
