using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 50f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Equals("SpaceShip"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    public void Spawn(Vector2 spawnPosition)
    {

        GameObject bullet = Instantiate(gameObject, new Vector3(spawnPosition.x, spawnPosition.y+0.5f, 0f), Quaternion.identity);

    }

    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }
}
