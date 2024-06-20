using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class CFirebase : MonoBehaviour
{
    DatabaseReference m_Reference;

    public string genders;
    public int userIndex = 0;

    public int ageNumber;
    private string userName; // name 변수

    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        WriteUserData("0", "aaaa", "man", 25);

        // PlayerPrefs.DeleteKey("UserIndex"); // UserIndex 초기화

        m_Reference.Child("userIndex").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                userIndex = int.Parse(snapshot.Value.ToString());
            }
        });


        ReadUserData();

    }

    void ReadUserData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (var childSnapshot in snapshot.Children)
                    {
                        string userId = childSnapshot.Key;
                        string name = childSnapshot.Child("name").Value.ToString();
                        string gender = childSnapshot.Child("gender").Value.ToString();
                        int age = int.Parse(childSnapshot.Child("age").Value.ToString());



                        Debug.Log("User ID: " + userId + ", Name: " + name + ", Gender: " + gender + ", Age: " + age);
                    }
                }
            });
    }

    void WriteUserData(string userId, string name, string gender, int age)
    {
        m_Reference.Child("users").Child(userId).Child("name").SetValueAsync(name);
        m_Reference.Child("users").Child(userId).Child("gender").SetValueAsync(gender);
        m_Reference.Child("users").Child(userId).Child("age").SetValueAsync(age);
    }

    public void UpdateUsers()
    {
        WriteUserData(userIndex.ToString(), userName, genders, ageNumber);

        // Firebase에 userIndex 값 저장
        m_Reference.Child("userIndex").SetValueAsync(userIndex);

        print(userName);
    }

    public void SetUserName(string name)
    {
        userName = name;
    }

    // 게임이 종료될 때 호출되는 함수
    private void OnApplicationQuit()
    {
        // Firebase에 마지막 userIndex 값 저장
        userIndex++;
        m_Reference.Child("userIndex").SetValueAsync(userIndex);
    }
}
