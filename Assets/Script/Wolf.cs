using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Wolf : MonoBehaviour
{
    [SerializeField] Player player;
    private Transform m_CurrentPlayerCP;
    [SerializeField] List<Transform> m_WolfPos = new List<Transform>();
    private Transform m_CurrentWolfPos;
    [SerializeField] List<Transform> m_Cp = new List<Transform>();
    int listIndex;
    [SerializeField] NavMeshAgent m_WolfNM;
    [SerializeField] GameObject m_FootPrintPfb;
    private float elapsed;
    private float elapsedCD = 0.2f;
    private string footprint;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentWolfPos = m_WolfPos[0];
        //goToNextCPWolf();
        footprint = "left";
        elapsed =Time.time + elapsedCD;
    }


    // Update is called once per frame
    void Update()
    {
        m_CurrentPlayerCP = player.getCheckpoint();
        listIndex = m_Cp.IndexOf(m_CurrentPlayerCP);


        if (Vector3.Distance(transform.position, m_CurrentWolfPos.position)< 2)
        {
            m_WolfNM.enabled = false;
        }
        else
        {
            m_WolfNM.enabled = true;
            m_WolfNM.SetDestination(m_CurrentWolfPos.position);
            if (Time.time >= elapsed)
            {
                elapsed =Time.time + elapsedCD;
                if(footprint == "left"){
                    footprint = "right";
                    Instantiate(m_FootPrintPfb,new Vector3(transform.position.x-0.2f,0.5f,transform.position.z), Quaternion.identity);
                }else{
                    footprint = "left";
                    Instantiate(m_FootPrintPfb,new Vector3(transform.position.x+0.2f,0.5f,transform.position.z), Quaternion.identity);
                }
            }
        }
    }

    public void goToNextCPWolf()
    {
        m_CurrentWolfPos = m_WolfPos[m_WolfPos.IndexOf(m_CurrentWolfPos) + 1];
    }



}
