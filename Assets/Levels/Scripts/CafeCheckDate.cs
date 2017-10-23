using UnityEngine;
using System;
using System.Collections;

public class CafeCheckDate : MonoBehaviour {

    public GameObject player;
    public Vector3 sendPlayerIfWrong = new Vector3(-2, 127,43);

    public string notOccupied = "_";

    public string dayText1 = "0";
    public string dayText2 = "1";
    public string monthText1 = "0";
    public string monthText2 = "1";

    public TextMesh day1;
    public TextMesh day2;
    public TextMesh month1;
    public TextMesh month2;
    public TextMesh slash;
    public TextMesh hint;
    private string defaultHintText;

    public TextMesh wrong;

    //DoorButton
    public GameObject _shedDoor;

    private Boolean triggered = false;
    private Collider other;

    private Vector3 defaultPosition;
    private Vector3 pressedPosition;

    private float openDoorHeight;
    private Vector3 doorPosition;

    public float doorSpeed = 0.1f;


	// sound to play when door opens
	public AudioSource _doorSound;

    void Start()
    {
        defaultHintText = hint.text;

        defaultPosition = transform.position;
        pressedPosition = transform.position - (transform.up * GetComponent<Renderer>().bounds.size.y / 2);

        doorPosition = _shedDoor.transform.position;
        openDoorHeight = doorPosition.y - (_shedDoor.transform.up * _shedDoor.GetComponent<Renderer>().bounds.size.y).y;
    }

    void FixedUpdate()
    {
        if (triggered && !other)
        {
            transform.position = defaultPosition;
            triggered = false;
            this.putTextBack();
        }
        if (triggered)
        {
            _shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y - doorSpeed, doorPosition.z);
            if (_shedDoor.transform.position.y <= openDoorHeight)
            {
                _shedDoor.transform.position = new Vector3(doorPosition.x, openDoorHeight, doorPosition.z);
            }
        }
        else
        {
            _shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y + doorSpeed, doorPosition.z);
            if (_shedDoor.transform.position.y >= doorPosition.y)
            {
                _shedDoor.transform.position = new Vector3(doorPosition.x, doorPosition.y, doorPosition.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = pressedPosition;
            this.other = other;
            if (this.isDateCorrect())
            {
                this.triggered = true;
                this.removeText();
				openDoorSound();
            }
            else
            {
                this.setTextWrong();
                StartCoroutine(this.sendPlayerDown());
                //this.putTextBack();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = defaultPosition;
            triggered = false;
            this.putTextBack();
        }
    }

    bool isDateCorrect()
    {
        if (day1.text == dayText1 && day2.text == dayText2 
            && month1.text == monthText1 && month2.text == monthText2)
        {
            return true;
        }
        return false;
    }
    void setTextToNotOccupied()
    {
        day1.text = notOccupied;
        day2.text = notOccupied;
        month1.text = notOccupied;
        month2.text = notOccupied;
    }

    void setTextWrong()
    {
        wrong.text = "WRONG!";
    }
    IEnumerator sendPlayerDown()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = sendPlayerIfWrong;
        wrong.text = "";
;    }
    void removeText()
    {
        day1.text = "";
        day2.text = "";
        month1.text = "";
        month2.text = "";
        slash.text = "";
        hint.text = "";
        wrong.text = "";
    }
    void putTextBack()
    {
        day1.text = notOccupied;
        day2.text = notOccupied;
        month1.text = notOccupied;
        month2.text = notOccupied;
        slash.text = "/";
        hint.text = defaultHintText;
        wrong.text = "";
    }

	// Play door sound if audio source exists 
	void openDoorSound() {
		if (_doorSound != null) {
			// start playuing the door sound as it opens
			_doorSound.Play();
		}
	}

	// Play door sound if audio source exists 
	void stopOpenDoorSound() {
		if (_doorSound != null) {
			// stop the door sound if it's still playing
			if(_doorSound.isPlaying){
				_doorSound.Stop();
			}
		}
	}
}
