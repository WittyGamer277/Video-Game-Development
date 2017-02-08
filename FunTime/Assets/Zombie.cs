using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	[SerializeField]
	public GameObject target = null;

	[SerializeField]
	AudioClip cowgroan;

	[SerializeField]
	GameObject mbExplosion;

	private int Health = 100;

	// Use this for idfdfnitialization
	void Start () {
	
	}

	float timeCounter = 0;
	float hitRate = 1;

	// Update is called once per frame
	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		if(agent != null && target != null)
		{
			agent.destination = target.transform.position;
		}
		if(Health <= 0)
		{
			Instantiate(mbExplosion, transform.position, Quaternion.Euler(Vector3.zero));

			Destroy(gameObject);
		}

		if(hitRate > timeCounter)
		{
			timeCounter += Time.deltaTime;
		}

		else
		{
			if (target != null)
			{
				if (target.GetComponent<Player>() != null)
				{
					if (Vector3.Distance(target.transform.position, this.transform.position) < 2.0f)
					{
						target.GetComponent<Player>().TakeDamage(10);
					}
				}
			}

			timeCounter = 0;
		}
	}

	public void TakeDamage(int amt)
	{
		Health -= amt;
		AudioSource.PlayClipAtPoint(cowgroan, transform.position);
	}
}
