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
    float halfScreenWidth = (2f * Camera.main.orthographicSize) * Camera.main.aspect;

    // Variables de estado para el movimiento
    bool _movingRight = true; // Dirección de movimiento lateral
    float _lastDescentTime; // Último momento en que los aliens descendieron

    void Start()
    {
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
        _initialPosition = transform.position;
        //TODO: Obtener distancia que se tiene que mover lateralmente
        //Calcular la distancia de la posicion inical al final de la pantalla
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
        //MovimientoColemena();
    }

    private void Disparar()
    {
        _shoot.Spawn(transform.position);
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
    }

    private void MovimientoColemena()
    {

    }
}