
using System.Collections.Generic;
using UnityEngine;


public class PillarGenerater : MonoBehaviour
{

    public float intervalGenerater;
    private float timer;
    public bool isWaiting;
    private GameObject pillars;
    public List<GameObject> pillarModels = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        pillars = transform.GetChild(0).gameObject;
        timer = intervalGenerater;  // 初始化计时器
    }


    void Update()
    {
        timer -= Time.deltaTime;  // 每帧减少时间
        if (timer < 0f)
        {
            if (!Birds.GetInstance.gameOver)
            {
                GeneratePillar();
                timer = intervalGenerater;  // 重置计时器
            }
        }
    }

    void GeneratePillar()
    {
        if (pillarModels == null || pillarModels.Count == 0)
        {
            Debug.LogError("pillarModels 列表为空或未初始化！");
            return;
        }
        // 随机选择一个索引
        int randomIndex = Random.Range(0, pillarModels.Count);

        GameObject clone = Instantiate(pillarModels[randomIndex]);

        clone.transform.SetParent(pillars.transform);
        clone.transform.position = transform.position;
    }
}
