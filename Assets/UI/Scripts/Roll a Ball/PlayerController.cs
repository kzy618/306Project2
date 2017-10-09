using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    public AudioSource pingu;
    private Rigidbody rb;

    public string mem1;
    public string mem2;
    public string mem3;

    public Animator anim;
    public float animDuration;
    public Animator death;
    public Animator clear;

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
            SaveStateController.controller.health--;
            SetCountText(SaveStateController.controller.health);
            pingu.Play();
        }

        if (other.gameObject.name == "Memory 1")
            {
                Time.timeScale = 0;
                StartCoroutine(playFade(mem1));
            }
            else if (other.gameObject.name == "Memory 2")
            {
                Time.timeScale = 0;
                StartCoroutine(playFade(mem2));
            }
            else if (other.gameObject.name == "Memory 3")
            {
                Time.timeScale = 0;
                StartCoroutine(playFade(mem3));
            }
    }

    void SetCountText(int count)
    {

        countText.text = "x " + count.ToString();
        if (SaveStateController.controller.health <= 0)
        {
            Time.timeScale = 0;
            death.SetTrigger("PlayerDeath");
        } else
        {
           // Time.timeScale = 0;
          //  clear.SetTrigger("LevelClear");
        }
    }

    IEnumerator playFade(string memoryToLoad)
    {
        anim.SetTrigger("FadeToMemory");
        var scene = SceneManager.LoadSceneAsync(memoryToLoad, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        yield return CoroutineUtilities.WaitForRealTime(animDuration);
        scene.allowSceneActivation = true;
    }
}