using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rigidbodyComponent;
    float moveSpeed = 5f;
    public int health = 4;
    Animator animatorController;
    GameUI gameUIScript;
    // Start is called before the first frame update
    void Start()
    {
        gameUIScript = FindObjectOfType<GameUI>();
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Attack();
        Flip();
    }

    private void FixedUpdate()
    {
        movementInput.Normalize();
        Vector2 newPos = movementInput * moveSpeed * Time.fixedDeltaTime;
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + newPos);
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log(health);
        gameUIScript.Damage(1);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animatorController.SetTrigger("Attack?");
        }
    }

    private void MovementInput()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        animatorController.SetFloat("Speed", moveSpeed * movementInput.sqrMagnitude);
    }

    void Flip()
    {
        if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
