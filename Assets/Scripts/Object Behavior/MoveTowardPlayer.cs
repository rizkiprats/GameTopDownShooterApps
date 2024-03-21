using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveTowardPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Moveable moveable;


    private void Awake()
    {
        moveable = GetComponent<Moveable>();

    }
    void Start()
    {
        moveable.setDirection(getDirection());

    }

    // Update is called once per frame
    void Update()
    {
        // moveable.setDirection(getDirection());



    }

    private Vector3 getDirection()
    {
        Vector3 dir;
        dir = GameManager.GetInstance().getPlayerPosition() - transform.position;
        dir = dir.normalized;

        return dir;


    }
}
