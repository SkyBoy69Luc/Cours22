using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerController))]
public class FireGun : NetworkBehaviour {
    public ParticleSystem fireGun;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject BulletEmiter;
    [SerializeField] float fireRate = 1;
    private AudioSource audioSource;
    private AudioClip gunSound;
    private PlayerController playerController;
    // Use this for initialization
    private float timerLastShot = 0;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        gunSound = Resources.Load<AudioClip>("Sounds/Gun/Pistol");
    }


    void Update() {

        if (isLocalPlayer)
        {
            if (playerController.IsAlive())
            {
                timerLastShot += Time.deltaTime;
                if (timerLastShot > fireRate)
                {
                    var fire1 = Input.GetAxis("Fire1");
                    if (fire1 > 0)
                    {
                        CmdFire(gameObject);
                        timerLastShot = 0;
                    }
                }
            }
        }

    }

    [Command]
    private void CmdFire(GameObject owner)
    {
        GameObject bullet = Instantiate(Bullet, BulletEmiter.transform.position, BulletEmiter.transform.rotation);
        bullet.GetComponent<Bullet>().SetOwner(owner);
        RpcPlayGunSound();
        NetworkServer.Spawn(bullet);
    }

    [ClientRpc]
    private void RpcPlayGunSound()
    {
        audioSource.PlayOneShot(gunSound);
    }
    
}
