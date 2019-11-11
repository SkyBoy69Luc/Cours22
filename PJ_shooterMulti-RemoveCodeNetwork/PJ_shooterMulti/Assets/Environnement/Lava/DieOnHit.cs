using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnHit : MonoBehaviour {
    public int damage=10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
       /* Damagable damagable = collision.gameObject.GetComponentInParent<Damagable>();
        if(damagable == null) {
            damagable = collision.gameObject.GetComponent<Damagable>();
        }
        if (damagable != null) {
            damagable.DealDamage(gameObject, damage);
        }
        print(collision.gameObject.name);*/
    }

    private void OnTriggerEnter(Collider other) {
        Damagable damagable = other.gameObject.GetComponentInParent<Damagable>();
        if (damagable == null) {
            damagable = other.gameObject.GetComponent<Damagable>();
        }
        if (damagable != null) {
            damagable.DealDamage(gameObject, damage);
        }
        print(other.gameObject.name);
    }
}
