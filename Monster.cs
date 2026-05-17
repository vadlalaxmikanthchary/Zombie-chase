using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D mybody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.linearVelocity = new Vector2(speed , mybody.linearVelocityY);

    }
}
