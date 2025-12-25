using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; // DateTime için gerekli

public class ToDoItemDisplay : MonoBehaviour
{
    public TMP_Text taskText;
    public TMP_Text timeText; // YENÝ: Unity'de bu Text'i ataman lazým
    public Toggle taskToggle;
    public Button deleteButton;

    private void Update()
    {
        CheckDeadline();
    }

    private void CheckDeadline()
    {
        // Eðer timeText baðlý deðilse veya boþsa iþlem yapma
        if (timeText == null || string.IsNullOrEmpty(timeText.text)) return;

        // Kullanýcý 10.30 veya 10:30 girebilir, ikisini de düzeltip alalým
        string cleanedTime = timeText.text.Replace(".", ":");

        DateTime deadline;
        // Metni saate çevirmeye çalýþ
        if (DateTime.TryParse(cleanedTime, out deadline))
        {
            // Eðer Þu An > Girilen Saat ise (Süre dolduysa)
            if (DateTime.Now > deadline)
            {
                taskText.color = Color.red;
                timeText.color = Color.red;
            }
            else
            {
                // Süre dolmadýysa normal renk (Siyah)
                taskText.color = Color.black;
                timeText.color = Color.black;
            }
        }
    }
}