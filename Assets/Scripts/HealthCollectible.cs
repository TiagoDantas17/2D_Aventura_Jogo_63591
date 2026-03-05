using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaudeColecionavel : MonoBehaviour
{
    public int valorCura = 1;
    void OnTriggerEnter2D(Collider2D outro)
    {
        PlayerController controlador = outro.GetComponent<PlayerController>();

        if (controlador != null && controlador.health < controlador.maxHealth)
        {
            
          controlador.ChangeHealth(1);

          Destroy(gameObject);
      }
       
        
        else if (controlador != null)
        {
            // Opcional: Apenas para saber o porque da fruta não foi destruída
            Debug.Log("Ruby já está com a saúde na capacidade máxima!");
        }
    }
}