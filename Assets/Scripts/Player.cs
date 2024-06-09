using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet_prefab;
    public GameManager gameManager;
    public Transform bullet_start_pos;
    public float _thrustSpeed = 2.0f;
    public float _turnSpeed = 4.0f;

    private Rigidbody2D rb;
    private bool _thrusting;
    private float _turnDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        RotationPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            rb.AddForce(this.transform.up * this._thrustSpeed);
        }
        if (_turnDir != 0.0f)
        {
            rb.AddTorque(_turnDir * this._turnSpeed);
        }
    }

    private void RotationPlayer()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDir = -1.0f;
        }
        else
        {
            _turnDir = 0.0f;
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bullet_prefab, bullet_start_pos);
        bullet.BulletMove(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;

            this.gameObject.SetActive(false);
            gameManager.PlayerDied();
        }
    }
}
