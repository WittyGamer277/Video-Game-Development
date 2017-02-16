using UnityEngine;
using System.Collections;
using System;

public class ZombieCollider : MonoBehaviour {

    [SerializeField]
    Zombie zombie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void TakeDamage(int v)
    {
        zombie.TakeDamage(v);
    }
}
