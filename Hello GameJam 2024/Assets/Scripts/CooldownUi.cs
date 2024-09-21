using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUi : MonoBehaviour
{
    private TextMeshProUGUI _cooldownText;
    private Pause _pause;

    private void Start()
    {
        _cooldownText = GetComponent<TextMeshProUGUI>();
        _pause = GameObject.FindWithTag("Player").GetComponent<Pause>();
    }

    private void Update()
    {
        if (_pause.IsOnCooldown)
        {
            _cooldownText.text = "Next pause in " + _pause.Cooldown + " s";
        }
        else if (!_pause.IsPaused)
        {
            _cooldownText.text = "Press space to pause";
        }
        else
        {
            _cooldownText.text = "Resuming in " + _pause.Cooldown + " s";
        }
    }
}
