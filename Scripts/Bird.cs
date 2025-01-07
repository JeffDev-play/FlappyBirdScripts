using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed;
    public AudioClip clipWing;
    public AudioClip clipHit;
    public AudioSource sourceHit;
    public AudioSource source;
    public GameObject gameOver;
    public GameObject tutorial;
    public GameObject spawPipes;
    public Rigidbody2D rig;

    private bool isDead = false;
    private bool isStartedGame = false;
    private bool onClick = false;
    void Start()
    {
        Time.timeScale = 1;
        rig.isKinematic = true;
    }

   
    void Update()
    {
        onClick = Input.GetMouseButtonDown(0);
        if (Input.GetMouseButtonDown(0) && !isDead && isStartedGame)
        {
            source.PlayOneShot(clipWing);
            rig.velocity = Vector2.up * speed;
        }
        if (onClick && !isDead && !isStartedGame)
        {
            rig.isKinematic = false;
            source.PlayOneShot(clipWing);
            rig.velocity = Vector2.up * speed;
            spawPipes.SetActive(true);
            tutorial.SetActive(false);
            isStartedGame = true;

        }
    }
    private void FixedUpdate()
    {
        float rotation = Mathf.Clamp(rig.velocity.y * rotationSpeed, -90f, 25f);
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sourceHit.PlayOneShot(clipHit);
        gameOver.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
    }
}
