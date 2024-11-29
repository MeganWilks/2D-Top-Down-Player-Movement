using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CollectibleManager collectibleManager;

    private Rigidbody2D rb;
    [SerializeField] private float Speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        LookingAtMouse();
        PlayerMove();


    }

    

    private void LookingAtMouse()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Makes player look at mouse Pos
        transform.up = MousePos - new Vector2(transform.position.x, transform.position.y); // Rotates player with Transform
        
    }    
    private void PlayerMove()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        rb.velocity = input.normalized * Speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            collectibleManager.CoinCounter++;
            

        }

        if (other.gameObject.CompareTag("Sack"))
        {
            Destroy(other.gameObject);
            collectibleManager.CoinCounter += 3;
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            Destroy(other.gameObject);
            collectibleManager.CoinCounter += 5;
        }
        
    }
}
