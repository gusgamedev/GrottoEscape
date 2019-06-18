using UnityEngine;

public class Shot : MonoBehaviour {

    [Header("Shot Variables")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject granade;
    [SerializeField] private GameObject bulletShell;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private ParticleSystem shotParticles;
    [SerializeField] private GameObject cameraShake;


    public bool canShoot = true;

    public  void InstantiateBullet()
    {        
        if (canShoot) {
            canShoot = false;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            Instantiate(bulletShell, firePoint.position, firePoint.rotation);
            Instantiate(cameraShake, firePoint.position, firePoint.rotation);
            shotParticles.Play();
            Invoke("NextShot", fireRate);

        }       
    }

    public void InstantiateGranade()
    {
        if (granade != null)
        {   
            Instantiate(granade, firePoint.position, firePoint.rotation);
        }
    }

    private void NextShot() {
        canShoot = true;
    }

    
}