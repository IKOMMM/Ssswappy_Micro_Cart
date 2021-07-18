using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandlerOld : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private float score;

    
    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = score.ToString();
    }
}
