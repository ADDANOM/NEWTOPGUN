//using UnityEngine;
//using System.Collections;

//public class E_Bullet : MonoBehaviour {

//	private Transform eTr;
//	private Transform pTr;

//	float moveSpeed = 10.0f;

//	private float dist;
//	private float tracedist = 50.0f;   // 추적 사정거리


//	void Start () 
//	{
//		eTr = GameObject.FindWithTag("ENEMY").GetComponent<Transform>();
//		pTr = GameObject.FindWithTag("Player").GetComponent<Transform>();


//		StartCoroutine(Chase());
//	}
	
//	void Update () 
//	{
//		//transform.position += transform.forward * Time.deltaTime * 10f;

//		dist = Vector3.Distance(eTr.position, pTr.position);  // 플레이어와 적의 거리
//		Debug.Log($"dist = {dist}");

//		//transform.Translate(Vector3.forward * 50f * Time.deltaTime);
		


//	}

//	IEnumerator Chase()
//	{
//		while (dist > tracedist)
//		{
//			transform.position = Vector3.MoveTowards(eTr.position, pTr.position, moveSpeed * Time.deltaTime);
//			Debug.Log($"Corr start!");

//			if (dist <= tracedist)
//			{
//				break;
//			}
//			yield return new WaitForSeconds(0.2f);
//			StartCoroutine(Move());
//			Debug.Log("asdasd");
//		}

//	}

//	IEnumerator Move()
//	{
//		eTr.Translate(0, 0, moveSpeed * Time.deltaTime);

//		yield return new WaitForSeconds(0.2f);
//		Destroy(this.gameObject, 4.0f);
//	}
//}
