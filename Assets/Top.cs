
using UnityEngine;

public class Top : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Birds>().GameOver();
        }
    }
}
