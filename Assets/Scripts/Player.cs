using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float timeElapsed = 0.0f;
    private float speed = 1.4f;

    public void MoveTo(Vector2 position)
    {
        var distance = Vector2.Distance(transform.position, position);
        if (Mathf.Round(distance * 1000) == 0)
        {
            transform.position = position;
            timeElapsed = 0.0f;
        }

        var moveDuration = distance * 100 / speed;

        if (timeElapsed < moveDuration)
        {
            transform.position = Vector2.Lerp(transform.position, position, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
        }

    }
}
