using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    private void OnTriggerEnter2D(Collider2D colider)
    {
        Destroy(gameObject);
    }

    public void Spawn(Vector2 spawnPosition)
    {
        GameObject bullet = Instantiate(gameObject, new Vector3(spawnPosition.x, spawnPosition.y - 0.5f, 0f), Quaternion.identity);
    }

    void Update()
    {
        transform.Translate(Vector2.down * _bulletSpeed * Time.deltaTime);
    }
}