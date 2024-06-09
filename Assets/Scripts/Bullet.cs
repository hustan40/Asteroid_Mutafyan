using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(300, 1000)]
    public float _bulletSpeed = 300.0f;

    public float _maxLifetime = 10.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void BulletMove(Vector2 dir)
    {
        rb.AddForce(dir * this._bulletSpeed);
        Destroy(this.gameObject, this._maxLifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
