
using UnityEngine;

public class Pillar : MonoBehaviour
{

    public float speed = 10;


    void Update()
    {
        if (!Birds.GetInstance.gameOver)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

}
