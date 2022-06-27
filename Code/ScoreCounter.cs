using UnityEngine;
using System;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI Text;
    private uint Score;
    private float RealScore;

    private void Start() {
        Text = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if (GameManager.GameHasEnded)
            return;

        RealScore += Time.deltaTime * 7f;
        Score = Convert.ToUInt32(RealScore);
        Text.text = $"Score: {Score}";
    }
}
