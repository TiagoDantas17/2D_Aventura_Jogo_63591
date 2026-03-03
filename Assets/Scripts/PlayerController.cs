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

        // 1. Lê a direção (X e Y) da MoveAction
        Vector2 move = moveAction.ReadValue<Vector2>();

        // 2. Mostra os valores no Console (útil para testar)
        Debug.Log(move);

        // 3. Calcula a nova posição (0.1f é a velocidade fixa por enquanto)
        Vector2 position = (Vector2)transform.position + move * 0.1f;

        // 4. Aplica a posição
        transform.position = position;
    }
}
