using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update

    private Moveable moveable;

    private void Awake()
    {

        moveable = GetComponent<Moveable>();

    }
    void Start()
    {
        //moveable.setDirection(transform.up);


    }

    // Update is called once per frame
    void Update()
    {
        moveable.setDirection(transform.up);

    }
}
