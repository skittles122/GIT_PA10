using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public float force = 300f;
    public int Score = 0;
    public Text scoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * force);
            thisAnimation.Play(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(1);
        }
        if(collision.gameObject.tag == "die")
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "score")
        {
            Score += 1;
            scoreText.text = "SCORE: " + Score;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    
}
