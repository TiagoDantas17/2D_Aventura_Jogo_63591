using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; // Guarda a posição

        position.x = position.x + 0.01f; // Move devagar para a direita
        position.y = position.y + 0.01f; // Move devagar para cima

        transform.position = position; // Aplica a nova posição
    }
}
