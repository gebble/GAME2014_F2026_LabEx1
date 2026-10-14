using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private Boundary horizontalBoundary = new Boundary { min = -2.0f, max = 2.0f };

    [SerializeField]
    private Boundary verticalBoundary = new Boundary { min = -6.0f, max = 6.0f };

    // Called by the pool whenever this enemy is spawned
    public void Spawn()
    {
        float randomX = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        transform.position = new Vector3(randomX, verticalBoundary.max, 0.0f);
        gameObject.SetActive(true); // "In use" state
    }

    void Update()
    {
        // Move straight down
        transform.position += Vector3.down * speed * Time.deltaTime;

        // When it leaves the bottom of the screen, mark as "not in use"
        if (transform.position.y < verticalBoundary.min)
        {
            gameObject.SetActive(false);
        }
    }
}