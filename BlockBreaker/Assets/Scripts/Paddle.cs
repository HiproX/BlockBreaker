using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }
    private void AutoPlay()
    {
        this.transform.position = new Vector3(Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
    }
    private void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        var paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
        this.transform.position = paddlePos;
    }
}
