using UnityEngine;

public class death : MonoBehaviour
{
    private int health = 100;
    void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;

        if(health < 0)
        {
            Destroy(gameObject);
            Debug.Log("Death");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
