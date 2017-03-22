using UnityEngine;
using System.Collections;

public class MoveGuy : MonoBehaviour {

    Rigidbody2D rb2d;

    [SerializeField]
    float forceMultiplier;

    [SerializeField]
    float jumpForce;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("w pressed");
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        if(Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * forceMultiplier);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * forceMultiplier);
        }
    }
}
