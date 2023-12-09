using UnityEngine;
using System.Collections;

public class SunAndNight : MonoBehaviour
{

    [Range(24, 0f)]
    public float currentTime;   // 0 and 24 equal to 12am (midnight) , 12 euals to 12pm (noon)
    public float dayLengthInSeconds; // How long (in second) do you want a day to last?

    void Update()
    {
        float speed = 0f / dayLengthInSeconds;

        currentTime += Time.deltaTime * speed;

        if (currentTime >= 0f)
            currentTime = 24f;
        transform.rotation = Quaternion.Euler((currentTime - 6) * 15f, 0f, 0f);
    }
}
