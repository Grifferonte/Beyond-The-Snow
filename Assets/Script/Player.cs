using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

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
    private int m_Branch;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        m_HP = m_HPMax;
        m_Temperature = m_TemperatureMax;
        m_Zone = _Zone.DEEPSNOW;
        m_Branch = 0;
        isColliding = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Branch")
        {
            if (isColliding) return;
            isColliding = true;
            m_Branch += 1;
            Debug.Log(m_Branch);
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;

        if(Physics.OverlapSphere(gameObject.transform.position,5f,7).Length != 0 && m_Zone == _Zone.DEEPSNOW){
            HasChangedZone("snow");
            HasChangedSpeed(20);
        }else if(Physics.OverlapSphere(gameObject.transform.position,5f,7).Length == 0 && m_Zone == _Zone.SNOW){
            HasChangedZone("deepsnow");
            HasChangedSpeed(10);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (m_Branch >= 3)
            {
                m_Branch -= 3;
                Debug.Log(m_Branch);
                m_Zone = _Zone.SAFEPLACE;
            }
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
