using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidade = 3.0f;
    public bool vertical;
    public float mudancaTempo = 3.0f;

    Rigidbody2D rigidbody2d;
    float temporizador;
    int direcao = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        temporizador = mudancaTempo;
    }

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador < 0)
        {
            direcao = -direcao;
            // Alterna o eixo aleatoriamente no final de cada ciclo
            vertical = (Random.value > 0.5f);
            temporizador = mudancaTempo;
        }
    }

    void FixedUpdate()
    {
        Vector2 posicao = rigidbody2d.position;
        if (vertical)
        {
            posicao.y += velocidade * direcao * Time.deltaTime;
        }
        else
        {
            posicao.x += velocidade * direcao * Time.deltaTime;
        }
        rigidbody2d.MovePosition(posicao);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        PlayerController jogador = outro.gameObject.GetComponent<PlayerController>();
        if (jogador != null)
        {
            jogador.ChangeHealth(-1);
        }
    }
}