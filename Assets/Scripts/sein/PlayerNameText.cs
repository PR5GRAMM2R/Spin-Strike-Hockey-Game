using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameText : MonoBehaviour
{
    private TextMeshProUGUI nameText;

    private void Start()
    {
        nameText = GetComponent<TextMeshProUGUI>();

        if (AuthManager.User != null)
        {
            nameText.text = $"���� ���� ����\n{AuthManager.User.Email}";
        }
        else
        {
            nameText.text = "ERROR : AuthManager.User == null";
        }
    }
}
