using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    private void OnTriggerEnter2D(Collider2D colider)
    {
        Debug.Log("Se activo el trigger");
        if (colider.gameObject.name.Equals("SpaceShip"))
        {
            Destroy(gameObject);
            Destroy(colider.gameObject);
            Debug.Log("Acierto");
        }
        else if (colider.gameObject.name.Equals("Floor"))
        {
            Destroy(gameObject);
        }
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
