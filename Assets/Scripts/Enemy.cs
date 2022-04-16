using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    [HideInInspector]
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int scoreForDestroy;

    [Header("Weapon")]
    public int pickupChanceWeapon01;
    public GameObject weapon01;
    public int pickupChanceWeapon02;
    public GameObject weapon02;
    public int pickupChanceWeapon03;
    public GameObject weapon03;
    public int pickupChanceWeapon04;
    public GameObject weapon04;

    public int healthPickupChance;
    public GameObject healthPickup;

    public GameObject deathEffect;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage (int amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            int weapon1 = Random.Range(0, 101);
            if (weapon1 < pickupChanceWeapon01)
            {
                Instantiate(weapon01, transform.position, transform.rotation);
            }

            int weapon2 = Random.Range(0, 101);
            if (weapon2 < pickupChanceWeapon02)
            {
                Instantiate(weapon02, transform.position, transform.rotation);
            }

            int weapon3 = Random.Range(0, 101);
            if (weapon3 < pickupChanceWeapon03)
            {
                Instantiate(weapon03, transform.position, transform.rotation);
            }

            int weapon4 = Random.Range(0, 101);
            if (weapon4 < pickupChanceWeapon04)
            {
                Instantiate(weapon04, transform.position, transform.rotation);
            }

            int randHealth = Random.Range(0, 101);
            if (randHealth < healthPickupChance)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Weapon.score++;
        }
    }
	
}
