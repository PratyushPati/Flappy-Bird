using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    public SpriteRenderer spritrenderer;
    public Sprite[] sprites;
    public int spriteIndex;

    public void Start()
    {
        spritrenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(animatesprite), 0.15f, 0.15f);
    }
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up*strength;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    public void animatesprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spritrenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            FindObjectOfType<GameManager>().gameover();
        }else if (collision.gameObject.tag == "scoring")
        {
            FindObjectOfType<GameManager>().increaseScore();
        }
    }
}
