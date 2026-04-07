using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocidade = 3.0f;
    public bool vertical;
    public float mudancaTempo = 3.0f;

    public ParticleSystem fumeEfeito;
    public GameObject efeitoMorte;

    bool broken = true;

    Rigidbody2D rigidbody2d;
    Animator animator;
    AudioSource audioSource;

    float temporizador;
    int direcao = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        temporizador = mudancaTempo;
    }

    void Update()
    {
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
        if (!broken)
        {
            return;
        }

        Vector2 posicao = rigidbody2d.position;

        if (vertical)
        {
            posicao.y += velocidade * direcao * Time.deltaTime;

            if (animator != null)
            {
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", direcao);
            }
        }
        else
        {
            posicao.x += velocidade * direcao * Time.deltaTime;

            if (animator != null)
            {
                animator.SetFloat("MoveX", direcao);
                animator.SetFloat("MoveY", 0);
            }
        }

        rigidbody2d.MovePosition(posicao);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (!broken)
        {
            return;
        }

        PlayerController jogador = outro.gameObject.GetComponent<PlayerController>();
        if (jogador != null)
        {
            jogador.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;

        if (rigidbody2d != null)
        {
            rigidbody2d.linearVelocity = Vector2.zero;
            rigidbody2d.simulated = false;
        }

        if (audioSource != null)
        {
            audioSource.Stop();
        }

        if (fumeEfeito != null)
        {
            fumeEfeito.Stop();
        }

        if (efeitoMorte != null)
        {
            Instantiate(efeitoMorte, transform.position, Quaternion.identity);
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Se tiveres animação de consertado, usa isto:
        // if (animator != null)
        // {
        //     animator.SetTrigger("Fixed");
        // }
    }
}