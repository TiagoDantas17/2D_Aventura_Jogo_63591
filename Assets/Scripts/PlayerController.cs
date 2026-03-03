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
        // Lê o valor do input (teclas)
        Vector2 move = moveAction.ReadValue<Vector2>();

        // Calcula a posição usando 'transform' (em inglês) e Time.deltaTime para velocidade constante
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;

        // Aplica a nova posição ao objeto
        transform.position = position;
    }
}
