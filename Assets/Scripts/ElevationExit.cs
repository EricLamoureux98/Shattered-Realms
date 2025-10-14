using UnityEngine;

public class ElevationExit : MonoBehaviour
{
    [SerializeField] Collider2D[] mountainColliders; // Colliders on top of mountain
    [SerializeField] Collider2D[] boundaryColliders; // Colliders around mountain

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }

            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = false;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
