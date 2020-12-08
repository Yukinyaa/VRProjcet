using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
// Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent m_enemy = null;
    //웨이 포인트 및 컨트롤 선언
    [SerializeField] Transform[] m_tfWayPoints = null;

    int m_count = 0;
    //위험지역에 들어온 타겟
    Transform m_target = null;

    public void SetTarget(Transform p_target)
    {
        CancelInvoke();
        m_target = p_target;
    }
    public void RemoveTarget()
    {
        m_target = null;
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }
    
    void MoveToNextWayPoint()
    {
        if(m_target == null)
        {
            //속도가 0이되면
            if (m_enemy.velocity == Vector3.zero)
            {
                //다음 목적지로(다돌면 다시 처음지역으로)
                m_enemy.SetDestination(m_tfWayPoints[m_count++].position);

                if (m_count >= m_tfWayPoints.Length)
                    m_count = 0;
            }
        }
        else
        {
            ;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Player" :
                Destroy(gameObject);
            break;    
        }    
    }
    void Start()
    {
        m_enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //시작되면 2초마다 움직이게 조정
        InvokeRepeating("MoveToNextWayPoint", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null)
        {
            m_enemy.SetDestination(m_target.position);
        }
    }
}
