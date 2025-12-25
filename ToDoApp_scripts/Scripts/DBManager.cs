using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using System.Collections.Generic;


public class DBManager
{
    private IDbConnection _connection;
    private IDbCommand _command;
    private IDataReader _reader;
    private string _dbPath;

    private static DBManager _instance;

    public static DBManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DBManager();
            }
            return _instance;
        }
    }

    private DBManager()
    {
        _dbPath = "URI=file:" + Application.persistentDataPath + "/Todo.db2";
        Debug.Log("Veritabaný yolu: " + _dbPath);

        try
        {
            _connection = new SqliteConnection(_dbPath);
            _connection.Open();
            CreateTable();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Veritabaný baðlantý hatasý: " + ex.Message);
        }
    }

    private void CreateTable()
    {
        // YENÝ: Tabloya TaskTime eklendi
        string sqlQuery = "CREATE TABLE IF NOT EXISTS ToDoItems (Id INTEGER PRIMARY KEY, Task TEXT NOT NULL, TaskTime TEXT, IsComplete INTEGER NOT NULL)";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;
        _command.ExecuteNonQuery();
        _command.Dispose();
    }

    public void SaveTask(ToDoItem task)
    {
        // YENÝ: TaskTime kaydediliyor
        string sqlQuery = "INSERT INTO ToDoItems (Task, TaskTime, IsComplete) VALUES (@Task, @TaskTime, @IsComplete)";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;

        var pTask = _command.CreateParameter();
        pTask.ParameterName = "@Task";
        pTask.Value = task.Task;
        _command.Parameters.Add(pTask);

        var pTime = _command.CreateParameter();
        pTime.ParameterName = "@TaskTime";
        pTime.Value = task.TaskTime; // Saati ekle
        _command.Parameters.Add(pTime);

        var pComplete = _command.CreateParameter();
        pComplete.ParameterName = "@IsComplete";
        pComplete.Value = task.IsComplete ? 1 : 0;
        _command.Parameters.Add(pComplete);

        _command.ExecuteNonQuery();
        _command.Dispose();
    }

    public List<ToDoItem> GetAllTasks()
    {
        List<ToDoItem> tasks = new List<ToDoItem>();
        string sqlQuery = "SELECT * FROM ToDoItems";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;
        _reader = _command.ExecuteReader();

        while (_reader.Read())
        {
            ToDoItem task = new ToDoItem();
            task.Id = _reader.GetInt32(0);
            task.Task = _reader.GetString(1);
            // YENÝ: Okurken saati de çekiyoruz (Sýra 2'de, IsComplete 3'e kaydý)
            task.TaskTime = _reader.IsDBNull(2) ? "" : _reader.GetString(2);
            task.IsComplete = _reader.GetInt32(3) == 1;
            tasks.Add(task);
        }

        _reader.Close();
        _command.Dispose();

        return tasks;
    }

    public ToDoItem GetTaskById(int id)
    {
        ToDoItem task = null;
        string sqlQuery = "SELECT * FROM ToDoItems WHERE Id = @Id";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;

        var pId = _command.CreateParameter();
        pId.ParameterName = "@Id";
        pId.Value = id;
        _command.Parameters.Add(pId);

        _reader = _command.ExecuteReader();

        if (_reader.Read())
        {
            task = new ToDoItem();
            task.Id = _reader.GetInt32(0);
            task.Task = _reader.GetString(1);
            task.TaskTime = _reader.IsDBNull(2) ? "" : _reader.GetString(2);
            task.IsComplete = _reader.GetInt32(3) == 1;
        }

        _reader.Close();
        _command.Dispose();

        return task;
    }

    public void UpdateTask(ToDoItem task)
    {
        // YENÝ: Güncelleme sorgusu da saati içeriyor
        string sqlQuery = "UPDATE ToDoItems SET Task = @Task, TaskTime = @TaskTime, IsComplete = @IsComplete WHERE Id = @Id";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;

        var pTask = _command.CreateParameter();
        pTask.ParameterName = "@Task";
        pTask.Value = task.Task;
        _command.Parameters.Add(pTask);

        var pTime = _command.CreateParameter();
        pTime.ParameterName = "@TaskTime";
        pTime.Value = task.TaskTime;
        _command.Parameters.Add(pTime);

        var pComplete = _command.CreateParameter();
        pComplete.ParameterName = "@IsComplete";
        pComplete.Value = task.IsComplete ? 1 : 0;
        _command.Parameters.Add(pComplete);

        var pId = _command.CreateParameter();
        pId.ParameterName = "@Id";
        pId.Value = task.Id;
        _command.Parameters.Add(pId);

        _command.ExecuteNonQuery();
        _command.Dispose();
    }

    public void DeleteTask(int id)
    {
        string sqlQuery = "DELETE FROM ToDoItems WHERE Id = @Id";

        _command = _connection.CreateCommand();
        _command.CommandText = sqlQuery;

        var pId = _command.CreateParameter();
        pId.ParameterName = "@Id";
        pId.Value = id;
        _command.Parameters.Add(pId);

        _command.ExecuteNonQuery();
        _command.Dispose();
    }

    public void CloseConnection()
    {
        if (_connection != null && _connection.State == ConnectionState.Open)
        {
            _connection.Close();
        }
    }
}