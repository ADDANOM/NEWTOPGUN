using UnityEngine;
using System.Collections;

public class E_Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * Time.deltaTime * 10f;

		transform.Translate(Vector3.forward * 50f * Time.deltaTime);
		Destroy(this.gameObject, 5.0f);


	}
}
