using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputAction moveAction;
    public InputAction launchAction;
    public InputAction talkAction; // Ação para falar

    Rigidbody2D rigidbody2d;
    Animator animator;

    Vector2 move;
    Vector2 moveDirection = new Vector2(1, 0);

    public float speed = 3.0f;
    public GameObject projectilePrefab;
    public float launchForce = 300.0f;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    void Start()
    {
        moveAction.Enable();
        launchAction.Enable();
        talkAction.Enable();

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }


    void Update()

    {

        move = moveAction.ReadValue<Vector2>();



        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))


        {

            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        if (launchAction.WasPressedThisFrame())
        {
            Launch();
        }

        // Verifica se apertou X para falar
        if (Input.GetKeyDown(KeyCode.X))
        {
            FindFriend();
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }


    void FixedUpdate()
    {

        Vector2 position = rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);


        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    void FindFriend()
    {
        // Isto desenha uma linha vermelha na aba SCENE (não na aba Game) quando carregas no X
        Debug.DrawRay(rigidbody2d.position + Vector2.up * 0.2f, moveDirection * 1.5f, Color.red, 1.0f);

        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));

        if (hit.collider != null)
        {
            Debug.Log("O raio bateu em: " + hit.collider.name);
            UIHandler.instance.DisplayDialogue();
        }
        else
        {
            Debug.Log("O raio não encontrou nada na Layer NPC.");
        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + moveDirection * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, launchForce);

        animator.SetTrigger("Launch");
    }


    public void ChangeHealth(int amount)
    {

        if (amount < 0)

        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

        }


        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);

    }

}