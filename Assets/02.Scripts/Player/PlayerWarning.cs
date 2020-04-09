using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PlayerWarning : MonoBehaviourPunCallbacks
{
    public GameObject OutArea;
    // GameObject outscreen;
    // TextMeshPro _text;

    GameObject warn_left;
    GameObject warn_right;
    GameObject warn_up;
    GameObject warn_down;
    GameObject warn_forward;
    GameObject warn_backward;
    Image _image;



    void Start()
    {
        _image = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").GetComponent<Image>();
        warn_left = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(0).gameObject;
        warn_right = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(1).gameObject;
        warn_down = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(2).gameObject;
        warn_up = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(3).gameObject;
        warn_forward = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(4).gameObject;
        warn_backward = GameObject.Find("CameraRig").transform.Find("Camera").transform.Find("Canvas").transform.Find("OutArea").transform.GetChild(5).gameObject;
    }


    private void OnTriggerStay(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.tag == "AREA")
            {
                if (other.gameObject.name == "Zone_Up")
                {
                    if (transform.position.y > 200.0f)
                    {
                        Debug.Log("GO DOWN!");
                        warn_down.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_down.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }

                }
                else if (other.gameObject.name == "Zone_Down")
                {
                    if (transform.position.y < -200.0f)
                    {
                        Debug.Log("Go UP!");
                        warn_up.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_up.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }
                }
                else if (other.gameObject.name == "Zone_West")
                {
                    if (transform.position.x < -300.0f)
                    {
                        Debug.Log("Go RIGHT!");
                        warn_right.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_right.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }

                }
                else if (other.gameObject.name == "Zone_East")
                {
                    if (transform.position.x > 300.0f)
                    {
                        Debug.Log("Go LEFT!");
                        warn_left.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_left.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }

                }
                else if (other.gameObject.name == "Zone_North")
                {
                    if (transform.position.z > 800.0f)
                    {
                        Debug.Log("Go BACKWARD!");
                        warn_backward.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_backward.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }

                }
                else if (other.gameObject.name == "Zone_South")
                {
                    if (transform.position.z < -200.0f)
                    {
                        Debug.Log("Go FORWARD!");
                        warn_forward.SetActive(true);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.25f);
                    }
                    else
                    {
                        warn_forward.SetActive(false);
                        _image.color = new Color(0.2f, 0.0f, 1.0f, 0.0f);
                    }

                }
            }
        }



    }



}
