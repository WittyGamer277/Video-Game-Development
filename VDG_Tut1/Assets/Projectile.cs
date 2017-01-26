using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * 10); // (0,1,0)

        RaycastHit hit;
        if(Physics.Raycast(new Ray(transform.position, Vector2.up), out hit, 1))
        {
            //destroy collision object using hit.transform.gameobject
            Destroy(hit.transform.gameObject);
        }
	}
}
