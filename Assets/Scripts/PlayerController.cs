using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float velocity;    
    private Rigidbody2D ridigBody;
    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        count = 0;
        ridigBody = GetComponent<Rigidbody2D>();

        winText.text = "";
        SetCountText();
    }

   
    void FixedUpdate()
    {

        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        ridigBody.AddForce(movement * velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        
        countText.text = "Count: " + count.ToString();

        
        if (count >= 11)
            
            winText.text = "You win!";
    }
}