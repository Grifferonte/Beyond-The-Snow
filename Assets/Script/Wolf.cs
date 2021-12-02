using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wolf : MonoBehaviour
{
    [SerializeField] Player player;
    private Transform m_CurrentPlayerCP;
    [SerializeField] List<Transform> m_WolfPos = new List<Transform>();
    [SerializeField] List<Transform> m_Cp = new List<Transform>();
    int listIndex;
    private bool isArrivedToDestination;
    // Start is called before the first frame update
    void Start()
    {
        isArrivedToDestination = true;
    }


    // Update is called once per frame
    void Update()
    {
        m_CurrentPlayerCP = player.getCheckpoint();
        listIndex = m_Cp.IndexOf(m_CurrentPlayerCP);

        if (!isArrivedToDestination)
        {
            transform.LookAt(m_WolfPos[listIndex], Vector3.up);
            //Vector3.MoveTowards(transform.position, m_WolfPos[listIndex].position, 1000000f);
        }
        else
        {
            Debug.Log(listIndex);
            transform.LookAt(m_Cp[listIndex], Vector3.up);
        }

    }
}
