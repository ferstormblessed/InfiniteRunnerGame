using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsUI;
    [SerializeField] private GameObject _gameOverScreen;

    public void ShowGameOverScren()
    {
        _gameOverScreen.SetActive(true);
    }

    public void UpdateCoinsText(int newAmount)
    {
        _coinsUI.text = "Coins: " + newAmount;
    }
}
