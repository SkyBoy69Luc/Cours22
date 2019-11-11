using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : MonoBehaviour {

    Rigidbody rigidBody;
    [SerializeField]float DestroyBulletAfterCollisionTime = 5f;
    [SerializeField] float maxLifeTime = 120f;
    [SerializeField] float bulletForce = 1500;
    [SerializeField] int bulletDamage=5;
   /*[SyncVar]*/
    private GameObject owner;
    
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        Vector3 ajustedMovement = transform.TransformDirection(Vector3.forward); 
        rigidBody.AddForce(ajustedMovement * bulletForce);
        Invoke("DetroyBullet", maxLifeTime);
    }

    
    public void SetOwner(GameObject newOwner) {
        owner = newOwner;
    }


    private void OnCollisionEnter(Collision collision) {
        Damagable damagable = collision.gameObject.GetComponentInParent<Damagable>();
       
        if (damagable == null) {
            damagable = collision.gameObject.GetComponent<Damagable>();
        }
        if (damagable != null) {
            if(collision.gameObject != owner) {
                damagable.DealDamage(owner, bulletDamage);
            }
         
            
        } 
        Invoke("DetroyBullet", DestroyBulletAfterCollisionTime);
    }

    private void DetroyBullet() {
        Destroy(gameObject);
    }
}
