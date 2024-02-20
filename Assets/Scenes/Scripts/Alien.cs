using UnityEngine;
using Random = System.Random;

public class Aline : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] AlienShoot _shoot;
    [SerializeField] float _shotInterval = 5f;
    float _randomShootTime;
    Random random = new();
    bool _alienBelow;
    Vector2 _initialPosition;
    float _destinoXD;
    float _destinoXI;
    bool _llegadaDestino = false;

    void Start()
    {
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
        _initialPosition = transform.position;
        _destinoXD = _initialPosition.x + 4f;
        _destinoXI = _initialPosition.x - 4f;
    }

    void Update()
    {
        _alienBelow = Physics2D.Raycast(transform.position, Vector2.down, 1.5f);
        Debug.DrawRay(transform.position, Vector2.down * 2.5f, Color.red);

        if (Time.time >= _randomShootTime)
        {
            if (!_alienBelow)
            {
                Disparar();
            }
        }
        MoviemientoColemena();
    }

    private void Disparar()
    {
        _shoot.Spawn(transform.position);
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
    }
    private void MoviemientoColemena()
    {
        if (transform.position.x >= _destinoXD && !_llegadaDestino)
        {
            Debug.Log("DESTINO ALCANZADO");
            transform.position = transform.position + new Vector3(0f, -1f, 0f);
            _llegadaDestino = !_llegadaDestino;
        }
        else if (transform.position.x <= _destinoXI && _llegadaDestino)
        {
            Debug.Log("DESTINO ALCANZADO");
            transform.position = transform.position + new Vector3(0f, -1f, 0f);
            _llegadaDestino = !_llegadaDestino;
        }
        transform.position = transform.position + new Vector3(_llegadaDestino ? -1 : +1, 0f, 0f) * Time.deltaTime;
    }
}

