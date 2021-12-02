using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] UnityEvent<int> m_SpeedChange;
    private float m_HP;
    [SerializeField] private float m_HPMax;
    private float m_Temperature;
    private float m_TemperatureLoss = 1 / (1.2f);
    [SerializeField] private float m_TemperatureMax;
    private enum _Zone { SNOW, DEEPSNOW, SAFEPLACE };
    private _Zone m_Zone;

    // Start is called before the first frame update
    void Start()
    {
        m_HP = m_HPMax;
        m_Temperature = m_TemperatureMax;
        m_Zone = _Zone.DEEPSNOW;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            HasChangedSpeed(12);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            HasChangedSpeed(120);
        }

        #region ZoneConditions

        if (m_Zone == _Zone.DEEPSNOW)
        {
            if (m_Temperature > 0)
            {
                m_Temperature -= m_TemperatureLoss * Time.deltaTime;
                Debug.Log(m_Temperature);
            }
        }
        if (m_Zone == _Zone.SNOW)
        {
            if (m_Temperature > 0)
            {
                m_Temperature -= (m_TemperatureLoss / 2) * Time.deltaTime;
                Debug.Log(m_Temperature);
            }
        }
        if (m_Zone == _Zone.SAFEPLACE)
        {
            m_Temperature = 10 * Time.deltaTime;
        }

        #endregion

        #region StatusManagement

        if (m_Temperature > m_TemperatureMax)
        {
            m_Temperature = m_TemperatureMax;
        }

        if (m_Temperature < 0)
        {
            m_Temperature = 0;
        }

        if (m_Temperature == 0)
        {
            m_HP -= Time.deltaTime;
        }

        if (m_HP <= 0)
        {
            gameOver();
        }

        #endregion
    }

    private void HasChangedSpeed(int speed)
    {
        if (m_SpeedChange != null)
        {
            m_SpeedChange.Invoke(speed);
        }
    }

    private void HasChangedZone(string zone)
    {
        switch (zone)
        {
            case "deepsnow":
                m_Zone = _Zone.DEEPSNOW;
                break;
            case "snow":
                m_Zone = _Zone.SNOW;
                break;
            case "safeplace":
                m_Zone = _Zone.SAFEPLACE;
                break;
            default: break;
        }
    }

    private void gameOver()
    {
        Debug.Log("Game Over");
    }
}
