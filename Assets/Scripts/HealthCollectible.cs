using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaudeColecionavel : MonoBehaviour
{
    public int valorCura = 1;
    void OnTriggerEnter2D(Collider2D outro)
    {
        PlayerController controlador = outro.GetComponent<PlayerController>();

      if (controlador != null)
      {
            
          controlador.ChangeHealth(1);

          Destroy(gameObject);
      }
    }
}