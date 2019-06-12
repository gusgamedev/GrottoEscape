using UnityEngine;

public class RandomLoot : MonoBehaviour {
    
    [SerializeField] private GameObject itemLoot;
    [SerializeField] private int chanceDrop = 0;

    public void DropItem()
    {
        int value = Random.Range(0,100);

        if (value < chanceDrop)
            Instantiate(itemLoot, transform.position, Quaternion.identity);


    }
}