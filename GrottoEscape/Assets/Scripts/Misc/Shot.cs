using UnityEngine;

public class Shot : MonoBehaviour {

    [Header("Shot Variables")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletShell;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private ParticleSystem shotParticles;


    public bool canShoot = true;
    
    public  void InstantiateBullet()
    {        
        if (canShoot) {
            canShoot = false;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            Instantiate(bulletShell, firePoint.position, firePoint.rotation);
            shotParticles.Play();
            Invoke("NextShot", fireRate);

        }       
    }
    
    private void NextShot() {
        canShoot = true;
    }

    
}