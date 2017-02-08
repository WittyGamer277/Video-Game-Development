using UnityEngine;
using System.Collections;

public class KillParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var p = GetComponent<ParticleSystem>();
		if(!p.IsAlive())
		{
			Destroy(this.gameObject);
		}
	}
}
