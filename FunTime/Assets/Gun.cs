using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	[SerializeField]
	GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && bullet != null)
		{
			var gb = GameObject.Instantiate(bullet, transform.position + transform.forward * 2, transform.rotation) as GameObject;

			var rb = gb.GetComponent<Rigidbody>();

			rb.AddForce(transform.forward * 1000);
		}
	}
}
