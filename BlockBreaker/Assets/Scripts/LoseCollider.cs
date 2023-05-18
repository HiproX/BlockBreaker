using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        levelManager.LoadLevel("Lose");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
