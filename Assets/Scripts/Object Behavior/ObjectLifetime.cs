using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectLifetime : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime;
    private float timer;

    public UnityEvent onTimerReachZero;

    public float DelayBlink;
    void Start()
    {
        timer = lifeTime;
        StartCoroutine(objectTimer());

    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            // Destroy(gameObject);
            onTimerReachZero.Invoke();
        }


        timer -= Time.deltaTime;

    }

    private IEnumerator objectTimer()
    {

        Color defaultColor = GetComponent<SpriteRenderer>().color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.5f;

        yield return new WaitForSeconds(lifeTime * 0.7f);
        while (timer > 0)
        {
            GetComponent<SpriteRenderer>().color = blinkColor;
            yield return new WaitForSeconds(DelayBlink);
            GetComponent<SpriteRenderer>().color = defaultColor;
            yield return new WaitForSeconds(DelayBlink);

        }
    }
}
