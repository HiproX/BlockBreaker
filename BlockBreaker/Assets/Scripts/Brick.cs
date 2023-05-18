using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject smoke;
    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private bool IsBreakable { get { return this.tag == "Breakable"; } }
    // Start is called before the first frame update
    void Start()
    {
        // Отслеживание разрушаемых кирпичей
        if (IsBreakable)
        {
            ++breakableCount;
            Debug.Log($"breajableCoutn = {breakableCount}");
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (crack)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
        }
        if (IsBreakable)
        {
            HandelHits();
        }
    }
    private void HandelHits()
    {
        int maxHits = hitSprites.Length + 1;
        ++timesHit;
        if (timesHit >= maxHits)
        {
            --breakableCount;
            levelManager.BrickDestroyed();
            Debug.Log($"breajableCoutn = {breakableCount}");
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainModule = smokePuff.GetComponent<ParticleSystem>().main;
        mainModule.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Не хватает спрайта для Brick!");
        }
    }
}
