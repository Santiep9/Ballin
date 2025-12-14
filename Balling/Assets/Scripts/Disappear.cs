using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private static List<Disappear> allTimedObjects = new List<Disappear>();

    [SerializeField] private float timeToDisappear = 3f;

    private Coroutine disappearCoroutine;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isActive = true;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        if (!allTimedObjects.Contains(this))
            allTimedObjects.Add(this);
    }

    private void OnDestroy()
    {
        allTimedObjects.Remove(this);
    }

    private void OnEnable()
    {
        ResetObject();
    }

    public void StartTimer()
    {
        if (!isActive) return;

        if (disappearCoroutine != null)
            StopCoroutine(disappearCoroutine);

        disappearCoroutine = StartCoroutine(DisappearAfterTime());
    }

    private IEnumerator DisappearAfterTime()
    {
        yield return new WaitForSeconds(timeToDisappear);
        isActive = false;
        gameObject.SetActive(false);
    }

    public void ResetObject()
    {
        if (disappearCoroutine != null)
            StopCoroutine(disappearCoroutine);

        isActive = true;
        transform.position = startPosition;
        transform.rotation = startRotation;
        gameObject.SetActive(true);
    }

    public static void ResetAll()
    {
        foreach (var obj in allTimedObjects)
        {
            obj.ResetObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartTimer();
        }
    }
}