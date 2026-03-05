using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    void Start()
    {
        moveAction.Enable();
      
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

   
    void Update()
    {

        move = moveAction.ReadValue<Vector2>();
        // Debug.Log(move);

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
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    
    } 

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            // Se ela já estiver invencível, ignoramos o dano e saímos da função
            if (isInvincible)
                return;

            // Se não estava invencível, agora fica!
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        // Aplica a mudança de vida e garante que fica entre 0 e o Máximo
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Saúde atual: " + currentHealth + "/" + maxHealth);
    }
}
