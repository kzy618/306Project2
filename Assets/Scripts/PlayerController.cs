using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public GameObject quitPanel;
    public AudioSource pingu;

    private bool quitMenuOpen;
    private Animator quitter;
    private Rigidbody rb;

    public string mem1;
    public string mem2;
    public string mem3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText(SaveStateController.controller.health);
        winText.text = "";
        quitMenuOpen = false;
        quitter = quitPanel.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!quitMenuOpen)
            {
                quitMenuOpen = true;
                quitter.SetTrigger("Open");
            }
            else {
                quitter.SetTrigger("Close");
                quitMenuOpen = false;
            }
        }
    }

    public void closeQuitMenu()
    {
        quitter.SetTrigger("Close");
        quitMenuOpen = false;

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

            if (other.gameObject.name == "Memory 1")
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(mem1, LoadSceneMode.Additive);
            }
            else if (other.gameObject.name == "Memory 2")
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(mem2, LoadSceneMode.Additive);
            }
            else if (other.gameObject.name == "Memory 3")
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(mem3, LoadSceneMode.Additive);
            }
        }
    }

    void SetCountText(int count)
    {

        countText.text = "Health: " + count.ToString();
        if (count >= 12)
        {
            //winText.text = "\\(You . Win)/";
        }
    }
}