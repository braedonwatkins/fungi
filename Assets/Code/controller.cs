using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Float a rigidbody object a set distance above a surface.

    public float floatHeight;     // Desired floating height.
    public float liftForce;       // Force to apply when lifting the rigidbody.
    public float damping;         // Force reduction proportional to speed (reduces bouncing).
    // public Animator animator;

    public Transform attackPoint;
    public Transform footPoint;
    public LayerMask enemyLayers;
    public Rigidbody2D rb;    
    

    [SerializeField] private float groundDistance = 0.01f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jump = 2.5f;
    [SerializeField] private float attackRange = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) this.transform.Translate(Vector2.right * speed * Time.deltaTime); 
        if(Input.GetKey(KeyCode.LeftArrow)) this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        if(Input.GetKeyDown("x")) Attack();
    }

    void Attack() 
    {
        // //play anim
        // animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("TODO: Damage & HP Logic " + enemy.name);
        }
    }

    bool IsGrounded() 
    {
        // Cast a ray straight down.
        bool hit = Physics2D.Raycast(footPoint.position, Vector2.down, groundDistance);
        return hit;
    }
}
