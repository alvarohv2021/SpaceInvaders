using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] int _vidas = 3;
    void OnTriggerEnter2D()
    {
        if (_vidas > 0)
        {
            _vidas--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
