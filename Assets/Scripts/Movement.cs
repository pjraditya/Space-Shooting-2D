using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    float hz;
    public float speed = 15f;
    float xrange = 7.5f;
    float yrange = 2.2f;
    Rigidbody2D rb;
    private Animator anime;
    private void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hz = Input.GetAxis("Horizontal");
        float vz = Input.GetAxis("Vertical");
        if (transform.position.x > xrange) 
        {
            transform.position=new Vector2(xrange, transform.position.y);
        }

        if (transform.position.x < -xrange) 
        {
            transform.position = new Vector2(-xrange, transform.position.y);
        }

        if (transform.position.y > yrange) 
        {
            transform.position = new Vector2(transform.position.x, yrange);
        }
        if (transform.position.y < -4.1) 
        {
            transform.position = new Vector2(transform.position.x, -4.1f);
        }
        transform.Translate(Vector2.right * hz * Time.deltaTime * speed);
        transform.Translate(Vector2.up * vz * Time.deltaTime * speed);
           //anime.SetFloat("Left",1.0f);
           //anime.SetFloat("Right", 1.0f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {             
            GameManager.instance.LiveScore();
            if(GameManager.instance.life<=0)
            {
                GameManager.instance.SoundManager();
                SceneManager.LoadScene(2);
                Destroy(gameObject,0.5f);
            }
        }
    }
}