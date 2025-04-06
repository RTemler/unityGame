using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    
    public float attackDamage = 100f;
    public float hitRange = 2f;
    public float rayDuration = 0.2f;
    public Transform attackOrigin;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            Debug.Log("Attack");
        }
    }

    void Attack()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - attackOrigin.position).normalized;

        Vector3 offsetPosition = attackOrigin.position + direction * 0.6f;

        Debug.DrawRay(offsetPosition, direction * hitRange, Color.red, rayDuration);

        RaycastHit2D hit = Physics2D.Raycast(offsetPosition, direction, hitRange);

        if(hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);

            if(hit.collider.CompareTag("Enemy") && hit.collider.CompareTag("Player") == false)
            {
                hit.collider.SendMessage("TakeDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Hit");
            }
        }
        else
        {
            Debug.Log("Missed");
        }
    }

}
