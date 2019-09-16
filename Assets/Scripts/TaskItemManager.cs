using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItemManager : Singleton<TaskItemManager>
{
    [SerializeField]
    public GameObject contentSlot;

    [SerializeField]
    public GameObject taskItemPrefub;

    private List<TaskItemStruct> loadedTaskList;
    private List<GameObject> createdTasks;

    //初期化メソッド(初アクセスまたはAwake時のどちらか一度だけ実行される)
    protected override void Init()
    {
        base.Init();

        Debug.Log("TaskItemManager -- Initialized ");

        loadedTaskList = new List<TaskItemStruct>();


        loadedTaskList.Add(new TaskItemStruct(20190916, 3600, "風呂洗い", true));
        loadedTaskList.Add(new TaskItemStruct(20190916, 99, "みきと交際", false));
        loadedTaskList.Add(new TaskItemStruct(20190916, 192168, "会社入って", true));
        loadedTaskList.Add(new TaskItemStruct(20190916, 1994, "製作開始", true));
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TaskItemManager -- Started ");
        createdTasks = new List<GameObject>();
        for (int i = 0; i < loadedTaskList.Count; i++)
        {
            GameObject tmp = Instantiate(taskItemPrefub);
            tmp.GetComponent<TaskItemScript>().Setup(loadedTaskList[i]);
            tmp.transform.SetParent(contentSlot.transform);
            //tmp.transform.parent = contentSlot.transform;
            createdTasks.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct TaskItemStruct
{
    public int createdDate;
    public int totalSecond;
    public string taskName;
    public bool isRunning;

    public TaskItemStruct(int _createdDate,int _totalSecond,string _taskName,bool _isRunning)
    {
        createdDate = _createdDate;
        totalSecond = _totalSecond;
        taskName = _taskName;
        isRunning = _isRunning;
    }
}
