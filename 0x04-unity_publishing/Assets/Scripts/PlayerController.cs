using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //Total Health at start
    public int health = 5;
    // public speed var can be changed at any moment for testing
    public float speed = 1.0f;
    // Vector3 limits for 3D objects Rigidbody movements
    public Vector3 movement;
    // Rigidbody
    public Rigidbody rb;
    // Holds starting score
    private int score = 0;
    // Holds current score
    public Text scoreText;
    // Holds current health points
    public Text healthText;
    // Contains Bar to hold text for winner/loser msgs
    public GameObject WLBar;
    //Text for if player won or lost the game
    public Text WinLoseText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        if (health == 0)
        {
            health = 5;
            score = 0;
            WLBar.SetActive(true);   
            WLBar.GetComponent<Image>().color = Color.red;
            WinLoseText.GetComponent<Text>().color = Color.white;
            WinLoseText.text = "Game Over!";     
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * speed);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed);

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    //Trigger Colliders, Destroy, Compare, etc.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            SetHealthText();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            WLBar.SetActive(true);   
            WLBar.GetComponent<Image>().color = Color.green;
            WinLoseText.GetComponent<Text>().color = Color.black;
            WinLoseText.text = "You Win!";
            StartCoroutine(LoadScene(3));    
        }
    }

    // Player score
    void SetScoreText()
    {
        score++;
        scoreText.text = "Score :" + score;
    }

    // Player Health
    void SetHealthText()
    {
        health--;
        healthText.text = "Health: " + health;
    }

    /// <summary>
    /// Method that waits a few seconds before restarting
    /// the game
    /// </summary>
    /// <param name="seconds"> Seconds to wait </param>
    /// <returns> WaitForSeconds in real time </returns>
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
