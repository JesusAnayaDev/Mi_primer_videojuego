using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrecColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;
    [SerializeField] private Transform enemy;
    
    
    private Transform hijo;
    private Quiz m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_quizDB = GameObject.FindObjectOfType<Quiz>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();
        NextQuestion();
        
    }

    private void Update(){
        if (enemy.childCount > 0)
        {
            hijo = enemy.transform.GetChild(0);
        }
        
    }

    private void NextQuestion()
    {
        m_quizUI.Constructor(m_quizDB.GetRandom(), GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if (m_audioSource.isPlaying)
        
            m_audioSource.Stop();

        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SettingColor(optionButton.Option.correct ? m_correctColor : m_incorrecColor );

        if (optionButton.Option.correct)
        {
            Destroy(hijo.gameObject);
        }else{
            Direction.speed = 400f;
        }

        m_audioSource.Play();

        yield return new WaitForSeconds(m_waitTime);
        NextQuestion();
        
    }

}
