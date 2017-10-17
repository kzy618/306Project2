using UnityEngine;
using System.Collections;
using System;

public class CafeButtonNumber : MonoBehaviour {

    public string num;
    public string notOccupied = "_";

    public TextMesh month1;
    public TextMesh month2;

    public TextMesh day1;
    public TextMesh day2;

    private Boolean triggered = false;
    private Collider other;

    private Vector3 defaultPosition;
    private Vector3 pressedPosition;

    void Start()
    {
        defaultPosition = transform.position;
        pressedPosition = transform.position - (transform.up * GetComponent<Renderer>().bounds.size.y / 2);
    }

    void FixedUpdate()
    {
        if (triggered && !other)
        {
            transform.position = defaultPosition;
            triggered = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = pressedPosition;
            this.other = other;
            this.triggered = true;
            this.assignNumToDate();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = defaultPosition;
            triggered = false;
        }
    }

    void assignNumToDate()
    {
        if (day1.text.Equals(notOccupied))
        {
            this.changeText(day1, num);
        }
        else if (day2.text.Equals(notOccupied))
        {
            this.changeText(day2, num);
        }
        else if (month1.text.Equals(notOccupied))
        {
            this.changeText(month1, num);
        }
        else if (month2.text.Equals(notOccupied))
        {
            this.changeText(month2, num);
        }
        else
        {
            this.changeText(day1, num);
            this.changeText(day2, notOccupied);
            this.changeText(month1, notOccupied);
            this.changeText(month2, notOccupied);
        }
    }

    void changeText(TextMesh tm, string text)
    {
        tm.text = text;
    }
}
