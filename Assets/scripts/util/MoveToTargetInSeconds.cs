using UnityEngine;
using System.Collections;
using System;

public class MoveToTargetInSeconds : MonoBehaviour
{
    public static event Action<GameObject> OnArrivedAtTarget = delegate { };

    public void start(Vector3 target, float seconds)
    {
        IEnumerator coroutine = MoveToTargetInSecondsCoroutine(target, seconds);
        StartCoroutine(coroutine);
    }

    private IEnumerator MoveToTargetInSecondsCoroutine(Vector3 target, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = this.gameObject.transform.position;
        while (elapsedTime < seconds)
        {
            this.gameObject.transform.position = Vector3.Lerp(startingPos, target, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        this.gameObject.transform.position = target;
        OnArrivedAtTarget.Invoke(this.gameObject);
    }
}
