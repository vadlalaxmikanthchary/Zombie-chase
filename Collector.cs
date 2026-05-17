using UnityEngine;

public class Collector : MonoBehaviour
{
     private string Enemy_Tag = "Enemy";
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Enemy_Tag) || collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
