using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;


    public AudioSource pingu;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText(SaveStateController.controller.health);
        winText.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            //count = count + 1;
            Debug.Log(SaveStateController.controller.health);
            SaveStateController.controller.health += 1;
            SetCountText(SaveStateController.controller.health);
            pingu.Play();
        }
    }

    void SetCountText(int count)
    {

        countText.text = "x " + count.ToString();
        if (count >= 12)
        {
            //winText.text = "\\(You . Win)/";
        }
    }
}