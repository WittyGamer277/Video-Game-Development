using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    [SerializeField]
    Transform exitPoint;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("called");
        c.transform.position = exitPoint.position;
    }
}
