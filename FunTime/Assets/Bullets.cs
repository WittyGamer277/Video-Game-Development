using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	[SerializeField]
	AudioClip bubblePop;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other)
	{
        
		var zombie = other.gameObject.GetComponent<Zombie>();

		if (zombie != null)
		{
			zombie.TakeDamage(20);
		}

        var zombieCol = other.gameObject.GetComponent<ZombieCollider>();

        if (zombieCol != null)
        {
            zombieCol.TakeDamage(20);
        }

        AudioSource.PlayClipAtPoint(bubblePop, transform.position);
		Destroy(this.gameObject);
	}
}
