using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaudeColecionavel : MonoBehaviour
{
    public int valorCura = 1;

    AudioSource audioSource;

    // ✨ novo: efeito de partículas
    public GameObject efeitoPickup;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        PlayerController controlador = outro.GetComponent<PlayerController>();

        if (controlador != null && controlador.health < controlador.maxHealth)
        {
            controlador.ChangeHealth(valorCura);

            // ✨ criar efeito de partículas
            if (efeitoPickup != null)
            {
                Instantiate(efeitoPickup, transform.position, Quaternion.identity);
            }

            // 🔊 tocar som
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            // destruir depois de um pequeno delay
            Destroy(gameObject, 0.2f);
        }
        else if (controlador != null)
        {
            Debug.Log("Ruby já está com a saúde na capacidade máxima!");
        }
    }
}