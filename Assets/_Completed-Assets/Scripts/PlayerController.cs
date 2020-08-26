using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text WinText;
	
	private Rigidbody2D rigid_body_2d;
	
	private int count;
	
    // Start is called before the first frame update
    void Start()
    {
        rigid_body_2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText();
    }

    //Before Physics Occurs
    void FixedUpdate()
    {
		float horizontal_movement = Input.GetAxis("Horizontal");
		float vertical_movement = Input.GetAxis("Vertical");
		
		Vector2 movement = new Vector2(horizontal_movement, vertical_movement);
		
		rigid_body_2d.AddForce(movement * speed);
	
		
    }
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			
			SetCountText();
			
			if(count >= 12)
			{
				WinText.text = "You Win!!!";
			}
		}
	}
	
	void SetCountText()
	{
		countText.text = "Points: " + count.ToString();
	}
}

