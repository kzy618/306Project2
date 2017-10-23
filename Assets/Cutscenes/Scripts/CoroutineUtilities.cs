using UnityEngine;
using System.Collections;

public static class CoroutineUtilities
{
    /**
     * Static class that is used for real time timing, works even with time scale set to 0.
     **/
    public static IEnumerator WaitForRealTime(float delay)
    {
        while (true)
        {
            float pauseEndTime = Time.realtimeSinceStartup + delay;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            break;
        }
    }
}