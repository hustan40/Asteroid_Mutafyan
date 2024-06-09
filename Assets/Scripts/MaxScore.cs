using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score_txt;
    private void Start()
    {
        score_txt.text = "Ваш рекорд: " + PlayerPrefs.GetInt("maxScore");
    }
 }
