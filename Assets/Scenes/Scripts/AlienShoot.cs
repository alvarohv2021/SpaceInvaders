using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D colider)
    {
        _animator.SetTrigger("hit");
        _bulletSpeed = 0f;
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