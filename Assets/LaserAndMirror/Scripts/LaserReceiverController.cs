using UnityEngine;
using System.Collections;

public class LaserReceiverController : MonoBehaviour {

    // Inherit this class and override this method to add behaviour when laser hits receiver.
    public void activate()
    {
        print("Receiving Laser!!");
    }

}
