
using UnityEngine;

public class OutScreen : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            collision.GetComponent<Birds>().GameOver();
        }
        if (collision.CompareTag("Pillar"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
