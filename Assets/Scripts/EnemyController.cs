using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variáveis de movimento
    public float velocidade = 3.0f;
    public bool vertical;
    public float mudancaTempo = 3.0f;

    // Componentes e controle interno
    Rigidbody2D rigidbody2d;
    Animator animator; // Variável para controlar as animações
    float temporizador;
    int direcao = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        // Conecta o componente Animator ao script
        animator = GetComponent<Animator>();

        temporizador = mudancaTempo;
    }

    void Update()
    {
        temporizador -= Time.deltaTime;

        if (temporizador < 0)
        {
           
            direcao = -direcao;
            
            temporizador = mudancaTempo;
        }
    }

    void FixedUpdate()
    {
        Vector2 posicao = rigidbody2d.position;

        if (vertical)
        {
            // Movimento Vertical
            posicao.y += velocidade * direcao * Time.deltaTime;

            // Envia os dados para o Animator
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direcao);
        }
        else
        {
            // Movimento Horizontal
            posicao.x += velocidade * direcao * Time.deltaTime;

            // Envia os dados para o Animator
            animator.SetFloat("MoveX", direcao);
            animator.SetFloat("MoveY", 0);
        }

        rigidbody2d.MovePosition(posicao);
    }

    // Caso o inimigo toque no jogador
    void OnTriggerEnter2D(Collider2D outro)
    {
        PlayerController jogador = outro.gameObject.GetComponent<PlayerController>();
        if (jogador != null)
        {
            jogador.ChangeHealth(-1);
        }
    }
}