using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    
    public float attackDamage = 100f;
    public float hitRange = 2f;
    public float rayDuration = 0.2f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            Debug.Log("Attack");
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
    }

    void Attack()
    {
        Vector3 direction = transform.forward;
        Vector3 origin = transform.position;
        RaycastHit hit;

        Debug.DrawRay(origin, direction * hitRange, Color.red, rayDuration);

        if(Physics.Raycast(origin, direction, out hit, hitRange))
        {
            Debug.Log("Raycast hit: " + hit.transform.name);

            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.SendMessage("TakeDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Hit");
            }
        }
        else
        {
            Debug.Log("Missed");
        }
    }

}
