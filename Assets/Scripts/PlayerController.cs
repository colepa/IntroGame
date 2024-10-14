using System.Collections;
using System . Collections . Generic ;
using UnityEngine ;
using UnityEngine . InputSystem ;
using TMPro;

public class PlayerController1 : MonoBehaviour
{

    public Vector2 moveValue;
    public float speed;
    private int PickupCount;
    private int numPickups = 3;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;

    void Start()
    {
        PickupCount = 0;
        WinText.text = "";
        SetCountText();
    }
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
        }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.
        fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            PickupCount += 1;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        ScoreText.text = "Score: " + PickupCount.ToString();
        if(PickupCount >= numPickups)
        {
            WinText.text = "You win!";
        }
    }

    
}