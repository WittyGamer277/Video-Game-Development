using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;


public class BoxTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		var firstPersonChar = other.gameObject.GetComponent<FirstPersonController>();

		if(firstPersonChar != null)
		{
			Debug.Log("Triggered!!!!");
			Zombie[] zombies = GameObject.FindObjectsOfType<Zombie>();

			foreach(var z in zombies)
			{
				z.target = firstPersonChar.gameObject;
			}
		}
	}
}
