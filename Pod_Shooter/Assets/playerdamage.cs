using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamage : MonoBehaviour, Damagable {
    playerLife playerlife;
    // Use this for initialization

    public void DealDamage(int damage)
        {
        playerlife.TakeDammage(damage);
        }
	void Start () {
        playerlife = GetComponent<playerLife>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
