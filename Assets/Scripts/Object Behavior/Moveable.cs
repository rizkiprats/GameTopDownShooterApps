using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    // public Vector3 direction;
    private Vector3 direction;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }


    private void updatePosition()
    {
        transform.position = getNextPosition();
    }

    public Vector3 getNextPosition()
    {

        return transform.position + newPosition();
    }

    public Vector3 newPosition()
    {
        return direction * Time.deltaTime * speed;
    }

    internal void setXDirection(float xdirection)
    {
        direction.x = xdirection;
    }

    internal void setYDirection(float ydirection)
    {
        direction.y = ydirection;
    }

    public void setDirection(Vector3 value)
    {
        direction = value;
    }

    public void setDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;
    }
    internal void setDirection(float x, float y)
    {
        direction.x = x;
        direction.y = y;
    }

}
