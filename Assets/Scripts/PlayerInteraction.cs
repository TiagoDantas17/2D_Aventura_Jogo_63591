using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float distancia = 2.0f; // Aumentado ligeiramente para facilitar o toque
    public LayerMask camadaNPC;    // Define "NPC" no Inspector do Unity

    private Vector2 ultimaDirecao = Vector2.down;

    void Update()
    {
        // Se a LayerMask estiver vazia no Inspector, o raio não funciona
        if (camadaNPC.value == 0)
        {
            Debug.LogError("ERRO: Configura a 'Camada NPC' no Inspector do Player!");
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0)
            ultimaDirecao = new Vector2(moveX, 0);
        else if (moveY != 0)
            ultimaDirecao = new Vector2(0, moveY);

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Lança o raio a partir do centro do player na direção que ele olha, APENAS na camada NPC
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ultimaDirecao, distancia, camadaNPC);

            // Desenha o raio no Scene (podes ver ao carregar no E)
            Debug.DrawRay(transform.position, ultimaDirecao * distancia, Color.red, 1f);

            if (hit.collider != null)
            {
                NonPlayerCharacter npc = hit.collider.GetComponent<NonPlayerCharacter>();

                if (npc != null)
                {
                    Debug.Log("Sapo detetado, diálogo aberto!");
                    npc.Falar();
                }
            }
            else
            {
                Debug.Log("Nada na camada NPC detetado à frente.");
                // O DIÁLOGO NÃO PODE ABRIR AQUI
            }
        }
    }
}