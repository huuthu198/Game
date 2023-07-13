
using UnityEngine;
using UnityEngine.UI;
public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public Animator animator;
    public int enemyHP = 100;
    public Slider enemyHeathBar;


    void Start()
    {
        enemyHeathBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.45f, 0.45f);
        }
        else
        {
            transform.localScale = new Vector2(-0.45f, 0.45f);
        }
        
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHeathBar.value = enemyHP;
       if (enemyHP > 0)
        {
            animator.SetTrigger("damage");
        }
        else
        {
            animator.SetTrigger("death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }
    }
}
