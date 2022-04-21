using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    [Tooltip("Healt from 1 to 100")]
    public int health;
    [Tooltip("How much and what type of enemys gonna span when player fight with Boss")]
    public Enemy[] enemies;
    [Tooltip("Enemy spawn time")]
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    [Tooltip("Amount of dealing damage to player when boss collide with player")]
    public int damage;

    [Header("VFX")]
    public GameObject blood;
    public GameObject effect;

    private Slider healthBar;

    private SceneTransition sceneTransitions;

    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;
        sceneTransitions = FindObjectOfType<SceneTransition>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            healthBar.gameObject.SetActive(false);
            sceneTransitions.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }

}
