using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [Header("Shoot")]
    public  GameObject projectile;
    public  Transform shotPoint;
    public  float timeBetweenShots;

    private float shotTime;

    Animator cameraAnim;

    [Header("Score")]
    public static int score;
    public TextMeshProUGUI scoreText;

    [Header("Ammunition")]
    public int ammo;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        score = 0;
    }

    public void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        if (Input.GetMouseButtonDown(0) && (ammo > 0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectile, GameObject.FindGameObjectWithTag("Weapon").transform.position, transform.rotation);
                cameraAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
            }
            ammo--;
        }       

        ammoText.text = ammo.ToString();
        scoreText.text = "Killed "+ score.ToString();
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Weapon1")
        {
            ammo += 20;
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Weapon2")
        {
            ammo += 15;
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Weapon3")
        {
            ammo += 10;
            Destroy(otherObject.gameObject);
        }

        if (otherObject.tag == "Weapon4")
        {
            ammo += 5;
            Destroy(otherObject.gameObject);
        }
    }

}