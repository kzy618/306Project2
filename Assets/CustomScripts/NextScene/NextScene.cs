using UnityEngine;
using System.Collections;
public abstract class NextScene : MonoBehaviour 
{
    public bool _memoryFound;

    public void Start()
    {
        _memoryFound = false;
    }
}