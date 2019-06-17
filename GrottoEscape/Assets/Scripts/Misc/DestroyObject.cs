using Cinemachine;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
    }

    public void AutoDestroy()
    {
        Destroy(gameObject);
    }

    
}
