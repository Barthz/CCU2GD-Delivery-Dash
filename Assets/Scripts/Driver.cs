using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    private const string BOOST_TAG = "Boost";
    private const string WORLD_COLLISION_TAG = "WorldCollision";

    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;

    [SerializeField] TMP_Text boostText;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(BOOST_TAG))
        {
            Debug.Log("Boost collected! Speed increased.");

            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(WORLD_COLLISION_TAG))
        {
            Debug.Log("Crashed! Boost reset.");

            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) {
            move = 1f;
        } else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) {
            steer = 1f;
        } else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount );

        //Debug.Log("Move Speed: " + moveAmount + " Steer Amount: " + steerAmount);
    }
}
