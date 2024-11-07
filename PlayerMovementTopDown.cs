using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    // Start is called before the first frame update

    public float MovementSpeed;
    float SpeedX,SpeedY;
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedX = Input.GetAxisRaw("Horizontal") * MovementSpeed;
        SpeedY = Input.GetAxisRaw("Vertical") * MovementSpeed;
        rb2D.velocity = new Vector2 (SpeedX,SpeedY);
        
    }
}
