using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    [SerializeField] private Sprite[] meters = new Sprite[7];
    private Image _image;

    void Start()
    {
        _image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.sprite = meters[1];
    }
}
