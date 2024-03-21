using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public InputHandler inputHandler;
    private Moveable moveable;

    void Awake()
    {
        moveable = GetComponent<Moveable>();

    }


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSetDirection(Vector2 direction)
    {
        Debug.Log("Test " + direction);

        moveable.setDirection(direction);


    }

    private void OnEnable()
    {
        inputHandler.OnMoveAction += OnSetDirection;

    }

    private void OnDisable()
    {
        inputHandler.OnMoveAction += OnSetDirection;

    }


}
