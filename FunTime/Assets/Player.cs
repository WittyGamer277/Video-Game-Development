using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField]
	Text healthText;

	int health = 100;

	// Use this for initialization
	void Start () {
		healthText.text = health.ToString();
	}
	

	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int amt)
	{
		health -= amt;
		healthText.text = health.ToString();

		if(health <= 0)
		{
			Application.LoadLevel("dead");
			Destroy(this.gameObject);
		}
	}
}
