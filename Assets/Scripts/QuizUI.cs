using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton> m_buttoList = null;

    public void Constructor(Question q, Action<OptionButton> callback)
    {
        m_question.text = q.text;

        for (int i = 0; i < m_buttoList.Count; i++)
        {
            m_buttoList[i].Constructor(q.options[i] , callback);
        }
    }

}
