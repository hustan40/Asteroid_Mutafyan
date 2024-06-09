using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explode;
    public AudioSource explodeAudAst;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private TextMeshProUGUI score_txt, lives_txt, score_end_txt, newRecord_txt;
    private int maxScore;
    public float respawnTime = 3.0f;
    public int lives = 3;
    public int score = 0, scoreChange = 1000;

    private void Start()
    {
        score_txt.text = score.ToString();
        lives_txt.text = lives.ToString();
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explode.transform.position = asteroid.transform.position;
        this.explode.Play();
        explodeAudAst.Play();

        if ((asteroid.size * 0.5f) >= asteroid.minSize)
        {
            score += 50;
        }
        else
        {
            score += 100;
        }

        if (score >= scoreChange)
        {
            lives++;
            scoreChange += 1000;
            lives_txt.text = lives.ToString();
        }
        score_txt.text = score.ToString();
    }

    public void PlayerDied()
    {
        lives--;
        this.explode.transform.position = this.player.transform.position;
        this.explode.Play();
        lives_txt.text = lives.ToString();
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
    }    
    private void Respawn()
    {
        this.player.gameObject.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisions), respawnTime);
    }
    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        if (score > PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", score);
            newRecord_txt.text = "Поздравляю с новым рекордом";
        }
        else
        {
            newRecord_txt.text = "Ваш рекорд " + PlayerPrefs.GetInt("maxScore");
        }
        score_end_txt.text = score.ToString();
        endMenu.SetActive(true);
    }
}
