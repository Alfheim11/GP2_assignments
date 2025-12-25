using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToDoUIController : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField taskInputField;
    public TMP_InputField timeInputField; // YENÝ: Saat giriþi için kutu
    public Button addTaskButton;
    public RectTransform taskListContent;
    public GameObject toDoItemPrefab;

    private DBManager _dbManager;

    private void Awake()
    {
        _dbManager = DBManager.Instance;
        addTaskButton.onClick.AddListener(AddNewTask);
    }

    private void Start()
    {
        RefreshTaskList();
    }

    public void AddNewTask()
    {
        if (!string.IsNullOrWhiteSpace(taskInputField.text))
        {
            ToDoItem newTask = new ToDoItem
            {
                Task = taskInputField.text,
                TaskTime = timeInputField.text, // YENÝ: Saati inputtan al
                IsComplete = false
            };

            _dbManager.SaveTask(newTask);

            // Temizlik
            taskInputField.text = "";
            timeInputField.text = ""; // YENÝ: Saat kutusunu temizle

            RefreshTaskList();
        }
    }

    public void RefreshTaskList()
    {
        foreach (Transform child in taskListContent)
        {
            Destroy(child.gameObject);
        }

        List<ToDoItem> allTasks = _dbManager.GetAllTasks();

        foreach (ToDoItem task in allTasks)
        {
            GameObject taskObject = Instantiate(toDoItemPrefab, taskListContent);
            ToDoItemDisplay display = taskObject.GetComponent<ToDoItemDisplay>();

            display.taskText.text = task.Task;

            // YENÝ: Saati ekrana basýyoruz
            // display.timeText null olmasýn diye Unity'de atamayý unutma!
            if (display.timeText != null)
                display.timeText.text = task.TaskTime;

            display.taskToggle.isOn = task.IsComplete;

            display.taskToggle.onValueChanged.AddListener((isComplete) => OnToggleTask(task.Id, isComplete));
            display.deleteButton.onClick.AddListener(() => OnDeleteTask(task.Id));
        }
    }

    public void OnToggleTask(int taskId, bool isComplete)
    {
        ToDoItem taskToUpdate = _dbManager.GetTaskById(taskId);
        if (taskToUpdate != null)
        {
            taskToUpdate.IsComplete = isComplete;
            _dbManager.UpdateTask(taskToUpdate);
        }
    }

    public void OnDeleteTask(int taskId)
    {
        _dbManager.DeleteTask(taskId);
        RefreshTaskList();
    }
}