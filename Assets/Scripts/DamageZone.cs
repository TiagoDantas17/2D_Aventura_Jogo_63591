using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Esta função é chamada quando algo entra no gatilho (Trigger)
    void OnTriggerStay2D(Collider2D outro)
    {
        // Tenta encontrar o script PlayerController no objeto que entrou
        PlayerController controlador = outro.GetComponent<PlayerController>();

        // Se o objeto for o jogador (controlador não for nulo)
        if (controlador != null)
        {
            // Diminui a saúde em 1 (enviando um valor negativo)
            controlador.ChangeHealth(-1);
        }
    }
}
