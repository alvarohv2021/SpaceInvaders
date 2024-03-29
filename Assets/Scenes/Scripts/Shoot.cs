using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 50f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Cealing") || collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log(collision.gameObject.tag);
        }
    }

    //Comportamiento cuando se choca con una bala
    void OnTriggerEnter2D()
    {
        //No poner nada seria como hace balas penetrantes
        Destroy(gameObject);
    }

    public void Spawn(Vector2 spawnPosition)
    {

        GameObject bullet = Instantiate(gameObject, new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, 0f), Quaternion.identity);

    }

    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }
}
