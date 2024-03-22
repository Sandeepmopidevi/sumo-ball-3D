using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRB;
    private GameObject player;
    // Reference to the SpawnManager
    public SpawnManager spawnManager;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        // Find the SpawnManager GameObject in the scene and get its SpawnManager component
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        // If the enemy falls below a certain Y position, destroy it and notify SpawnManager
        if (transform.position.y < -10)
        {
            // Notify the SpawnManager to increase the score
            spawnManager.IncreaseScore();
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
