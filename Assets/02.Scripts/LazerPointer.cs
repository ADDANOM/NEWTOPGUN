using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LazerPointer : MonoBehaviour
{
    SteamVR_Behaviour_Pose pose;
    SteamVR_Input_Sources hand;
    SteamVR_Action_Boolean trigger;
    SteamVR_Action_Vibration haptic;

    public float dis = 500.0f;

    LineRenderer line;

    Ray ray;
    RaycastHit hit;
    GameObject preButton;
    GameObject currButton;

    Transform tr;

    SelectCharactor sel;

    // Start is called before the first frame update
    void Start()
    {
        
        tr = GetComponent<Transform>();

        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        trigger = SteamVR_Actions.default_InteractUI;
        haptic = SteamVR_Actions.default_Haptic;

        GameObject sel = GameObject.FindWithTag("Button"); 

        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        ray = new Ray(tr.position, tr.forward);

        if (Physics.Raycast(ray, out hit, dis))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance));  // 다른 오브젝트까지의 거리

            currButton = hit.collider.gameObject;  

            if(currButton != preButton)
            {
                ExecuteEvents.Execute(currButton, data, ExecuteEvents.pointerEnterHandler);
                ExecuteEvents.Execute(preButton, data, ExecuteEvents.pointerExitHandler);

                preButton = currButton;
            }

            if (trigger.GetStateDown(hand))
            {
                SteamVR_Actions.default_Haptic.Execute(0.1f, 0.5f, 50.0f, 1.0f, hand); // Execute: 몇초후 시작할것인가, 지속시간, 주파수, 진폭

                if (hit.transform.CompareTag("Button"))
                {
                    Debug.Log($"hit = {hit.point}");
                    ExecuteEvents.Execute(currButton, data, ExecuteEvents.pointerClickHandler);
                }
            }
        }
    }

    void CreateLine()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, dis));
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = Color.red;
    }
}
