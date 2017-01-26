using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    [SerializeField]
    Transform bullet;

    [SerializeField]
    Transform spawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, spawner.position, spawner.rotation);
        }
    }
}
