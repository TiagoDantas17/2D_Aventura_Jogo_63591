using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Variáveis relacionadas com o movimento do personagem
    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;

    // Start é chamado antes do primeiro frame
    void Start()
    {
        moveAction.Enable();
        // Obtém a referência do componente Rigidbody2D anexado à Ruby
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Lê o valor do input (teclas) e guarda na variável global 'move'
        move = moveAction.ReadValue<Vector2>();
    }

    // FixedUpdate é usado para cálculos de física de forma estável
    void FixedUpdate()
    {
        // Calcula a nova posição baseada no Rigidbody para evitar o tremor (jittering)
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;

        // Move o Rigidbody para a nova posição, respeitando as colisões
        rigidbody2d.MovePosition(position);
    }
}
