using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    private Vector2 moveAmount;
    private Animator anim;

    [Header("Health Configuration")]
    public int health;    
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Hurt Configuration")]
    public Animator hurtAnim;    
    public GameObject hurtSound;

    private SceneTransition sceneTransitions;

    [Header("Trail")]
    public GameObject trail;
    private float timeBtwTrail;
    public float startTimeBtwTrail;
    public Transform groundPos;
    public GameObject pausePanel;
  

    [Header("Pause")]
    public bool paused = false;

    private void Start()
    {
        /*----------------------------------------------------*/
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransitions = FindObjectOfType<SceneTransition>();

    }

    void Update()
    {
        /*-----------------PAUSE-----------------*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused == true)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);            
        }
        else 
        {            
            Time.timeScale = 1f;
            pausePanel.SetActive(false);            
        }
        /*-----------------PAUSE-----------------*/

        /*-----------------MOVEMENT--------------*/
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {

            if (timeBtwTrail <= 0)
            {
                Instantiate(trail, groundPos.position, Quaternion.identity);
                timeBtwTrail = startTimeBtwTrail;
            }
            else
            {
                timeBtwTrail -= Time.deltaTime;
            }
            anim.SetBool("isRunning", true);
        }
        else 
        {
            anim.SetBool("isRunning", false);
        }
        /*-----------------MOVEMENT--------------*/
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
       Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(this);
            sceneTransitions.LoadScene("Lose");
        }
    }
        
    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
            }
            else
            {
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
            }

        }
    }

    public void Heal(int healAmount) 
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else 
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

}