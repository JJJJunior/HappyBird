
using UnityEngine;

public class Middle : MonoBehaviour
{
    private bool isFinished;

    private void Start()
    {
        isFinished = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFinished)
        {
            other.GetComponent<Birds>().AddPoint(1);
            isFinished = true;
        }
    }
}
