using UnityEngine;

public class Shot : MonoBehaviour {
    public bool _canShoot = true;

    [Header("Shot Variables")]
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _fireRate = 0.2f;

    public  void Shoot(bool facingRight)
    {        
        if (_bullet != null && _firePoint != null && _canShoot) {
            _canShoot = false;
            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);                
            Invoke("NextShot", _fireRate);
        }       
    }
    
    void NextShot() {
        _canShoot = true;
    }

    
}