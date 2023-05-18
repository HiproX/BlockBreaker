using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBall;
    private bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBall = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBall;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
