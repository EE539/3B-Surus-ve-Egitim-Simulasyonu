using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using System.Data.SQLite;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using TMPro;

public class ChooseTraining : MonoBehaviour
{
    private string m_Path, db;
    public static string name = "serbest";
    public static string egitimler = "egitimler";
    private int db_id= 01;
    //sice database sep_train table has startdate and finished data time is required
    DateTime dateTime = DateTime.Today;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void SınavClicked()
    {
        egitimler = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("loading");
    }
    public void SerbestClicked()
    {
        egitimler = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("loading");
        Debug.LogError(name);
    }
    public void TamEgitimOnClicked()
    {
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(name);
    }

    public void egitim01OnClicked() //sürüş kalkış duruş
    {
        egitimler = "egitimler";
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        Debug.LogError(name);
        //database path for adding the chosen seperated train to db
        //m_Path = System.IO.Directory.GetCurrentDirectory();
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        db_id = 1;
        using (var connection = new SQLiteConnection(db))
         {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('"+ db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
         }  
    }

    public void egitim02OnClicked(){ //park eğitimi
        egitimler = "egitimler";
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(name);
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        //park eğitimi seçildiğinde 5 kodu ile sep_train e ekle
        db_id = 2;
        using (var connection = new SQLiteConnection(db))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('" + db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }

    public void egitim03OnClicked() //şerit değiştirme eğitimi
    {
        egitimler = "egitimler";
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(name);
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        //serit değiştirme seçildiğinde 3 kodu ile sep_train e ekle
        db_id = 3;
        using (var connection = new SQLiteConnection(db))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('" + db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }

    public void egitim04OnClicked() //kavşak eğitimi
    {
        egitimler = "egitimler";
        name = EventSystem.current.currentSelectedGameObject.name;
        Debug.LogWarning("name = " + name + " ve eğitimler = " + egitimler);
        SceneManager.LoadScene("loading");
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        //kavşak eğitimi seçildiğinde 4 kodu ile sep_train e ekle
        db_id = 4;
        using (var connection = new SQLiteConnection(db))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('" + db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
    public void egitim05OnClicked() //viraj alma eğitimi
    {
        egitimler = "egitimler";
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        //viraj eğitimi seçildiğinde 5 kodu ile sep_train e ekle
        db_id = 5;
        using (var connection = new SQLiteConnection(db))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('" + db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
    public void egitim06OnClicked() //geçi önceliği eğitimi
    {
        egitimler = "egitimler";
        SceneManager.LoadScene("loading");
        name = EventSystem.current.currentSelectedGameObject.name;
        m_Path = Application.streamingAssetsPath;
        db = "Data Source = " + m_Path + "/database.db";
        Debug.Log(db);
        //geçiş eğitimi seçildiğinde 6 kodu ile sep_train e ekle
        db_id = 6;
        using (var connection = new SQLiteConnection(db))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO sep_train(sep_train_id, finishdate, startdate,username) VALUES('" + db_id + "', 'NOT FINISHED' ,'" + dateTime.ToString("dd/MM/yyyy") + "','" + EnterDatabase.user + "')";
                command.ExecuteNonQuery();

            }
            connection.Close();
        }

    }

}
