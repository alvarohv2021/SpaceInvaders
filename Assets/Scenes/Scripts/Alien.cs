using UnityEngine;
using Random = System.Random;

public class Alien : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] AlienShoot _shoot;
    [SerializeField] float _shotInterval = 5f;
    float _randomShootTime;
    Random random = new();
    bool _alienBelow;//Con esta variable comprobamos si hay un alien debajo y puede disparar
    BoxCollider2D boxCollider2D;

    // Variables de estado para el movimiento
    static bool _movingRight = true; // Dirección de movimiento lateral

    void Start()
    {
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        MovimientoColemena();
    }

    private void Disparar()
    {
        _shoot.Spawn(transform.position);
        _randomShootTime = Time.time + (float)random.NextDouble() * _shotInterval;
    }

    private void MovimientoColemena()
    {
        float movement = _speed * Time.deltaTime * (_movingRight ? 1 : -1);
        transform.Translate(Vector3.right * movement);
        if (AlcanzaronBorde())
        {
            DescenderAllAliens();
            _movingRight = !_movingRight;
        }
    }

    // Verifica si los aliens alcanzan un borde
    private bool AlcanzaronBorde()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float tamañoDeLaNave = boxCollider2D.size.x;
        float adjustedScreenWidth = screenWidth - (tamañoDeLaNave * 0.5f);
        float positionX = transform.position.x;
        return (positionX >= adjustedScreenWidth && _movingRight) || (positionX <= -adjustedScreenWidth && !_movingRight);
    }
    private void DescenderAllAliens()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        foreach (GameObject alien in aliens)
        {
            alien.transform.Translate(Vector3.down * 1f);
        }
    }
}