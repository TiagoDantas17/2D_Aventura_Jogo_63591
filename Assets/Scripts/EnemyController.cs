using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variáveis de movimento
    public float velocidade = 3.0f;
    public bool vertical;
    public float mudancaTempo = 3.0f;

    // --- PASSO 2: Nova variável para o estado do inimigo ---
    bool broken = true;

    // Componentes e controle interno
    Rigidbody2D rigidbody2d;
    Animator animator;
    float temporizador;
    int direcao = 1;

    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

       
        animator = GetComponent<Animator>();

        temporizador = mudancaTempo;
    }

    void Update()
    {
        // Se o inimigo não estiver mais quebrado, paramos de contar o tempo
        if (!broken)
        {
            return;
        }

        temporizador -= Time.deltaTime;

        if (temporizador < 0)
        {

            direcao = -direcao;

            temporizador = mudancaTempo;

        }
    }

    void FixedUpdate()
    {
        // --- PASSO 3: Verifica se o inimigo está consertado ---
        if (!broken)
        {
            return; // Sai da função e o inimigo para de se mover
        }

        Vector2 posicao = rigidbody2d.position;

        if (vertical)
        {

            posicao.y += velocidade * direcao * Time.deltaTime;
            
            
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direcao);
        }
        else
        {

            posicao.x += velocidade * direcao * Time.deltaTime;


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

    // --- PASSO 4: Nova função pública para consertar o robô ---
    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;

        // Dica: Se você tiver uma animação de "Fix", pode disparar aqui!
        // animator.SetTrigger("Fixed"); 
    }
}