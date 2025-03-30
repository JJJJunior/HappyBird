
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Birds : SingletonMonoBehaviour<Birds>
{

    private Rigidbody2D rb;
    public float upDistance;
    public float interval;
    public float timer;
    bool isJump;
    public bool gameOver;

    private Vector2 originPlayerPos;

    public GameObject gameOverUI;
    public GameObject gameInfoUI;
    Text showPoint;
    Button restartBTN;
    private int currentPoint;
    private int maxPoint = 0;

    public GameObject pillars;


    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        showPoint = gameInfoUI.transform.GetChild(0).transform.GetComponent<Text>();
        restartBTN = gameOverUI.transform.Find("Button").transform.GetComponent<Button>();
        isJump = false;
        gameOver = false;
        originPlayerPos = transform.position;
        restartBTN.onClick.AddListener(delegate { InitGame(); });
        showPoint.text = "目前得分： " + currentPoint.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJump && !gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * upDistance, ForceMode2D.Impulse);
                timer = interval;
                isJump = true;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                isJump = false;
            }
        }
    }


    public void InitGame()
    {
        gameOver = false;
        transform.position = originPlayerPos;
        gameOverUI.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.None;
        currentPoint = 0;
        showPoint.text = "最高分：" + maxPoint + " 目前得分：" + currentPoint.ToString();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameOver = true;
        showPoint.text = "最高分：" + maxPoint + " 目前得分：" + currentPoint.ToString();

        if (currentPoint > maxPoint)
        {
            maxPoint = currentPoint;
        }

        if (pillars.transform.childCount > 0)
        {
            foreach (Transform child in pillars.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }


    public void AddPoint(int number)
    {
        currentPoint += number;

        if (currentPoint > maxPoint)
        {
            maxPoint = currentPoint;
        }

        showPoint.text = "最高分：" + maxPoint + " 目前得分：" + currentPoint.ToString();
    }
}
