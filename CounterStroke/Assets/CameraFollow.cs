using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    float depthoffset;

    [SerializeField]
    float heightoffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.right * target.position.x  + Vector3.forward * (depthoffset) + Vector3.up * heightoffset;
    }
}
