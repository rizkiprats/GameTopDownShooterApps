using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveRandom : MonoBehaviour
{
    // Start is called before the first frame update
    private Moveable moveable;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }
    void Start()
    {
        moveable.setDirection(randomDirection(), randomDirection());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private float randomDirection()
    {
        return Random.Range(-1f, 1);
    }
}
