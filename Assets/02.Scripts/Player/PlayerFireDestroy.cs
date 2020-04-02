using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireDestroy : MonoBehaviour
{
    public void OnEnable()
    {
        Invoke("Destroy", 1.5f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        CancelInvoke();
    }

}
