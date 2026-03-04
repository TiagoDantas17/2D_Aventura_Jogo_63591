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
    int currentHealth;
    void Start()
    {
        moveAction.Enable();
      
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

   
    void Update()
    {

        move = moveAction.ReadValue<Vector2>();
    }

    
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
