using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(0, 2)]
    public float _asteroidSpeed = 0.30f;
    [Range(1, 50)]
    public float  _maxLifetime = 30.0f;
    public float size = 1f, minSize = 0.05f;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        rbSprite.flipX = ChooseFlipSprite();
        rbSprite.flipY = ChooseFlipSprite();
        this.transform.eulerAngles = new Vector3 (0f, 0f, Random.value  * 360f);
        this.transform.localScale = Vector3.one * size;
        rb.mass = size;
    }

    private bool ChooseFlipSprite()
    {
        int spriteFlip = Random.Range(0, 1);
        if (spriteFlip == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetTrajectory(Vector2 dir)
    {
        rb.AddForce(dir * this._asteroidSpeed);
        Destroy(this.gameObject, this._maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);

            if ((this.size * 0.5f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            Destroy(this.gameObject);
        }
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }
}
