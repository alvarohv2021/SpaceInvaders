using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] int _vidas = 3;
    void OnTriggerEnter2D()
    {
        if (_vidas > 0)
        {
            _vidas--;
            Debug.Log("Han golpeado " + gameObject.name);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Han destruido " + gameObject.name);
        }
    }
}
