using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Adicionado

public class PlayerController : MonoBehaviour
{

    public InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        // Esta linha substitui todos os "ifs" anteriores!
        Vector2 move = moveAction.ReadValue<Vector2>();

        Vector2 position = transform.position;

        // Movimento suave usando a nova MoveAction
        position.x = position.x + 3.0f * move.x * Time.deltaTime;
        position.y = position.y + 3.0f * move.y * Time.deltaTime;

        transform.position = position;
    }
}
