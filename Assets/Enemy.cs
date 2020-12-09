using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent m_enemy = null;
    //웨이 포인트 및 컨트롤 선언
    [SerializeField] Transform[] m_tfWayPoints = null;
    [SerializeField] GameObject dust_effect = null;
    Vector3 oldPosition;
    Vector3 currentPosition;

    int m_count = 0;
    float velocity;
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
        oldPosition = transform.position;
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
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(velocity > 1.5f)
        //if(velocity > 0f)
            {
            switch(other.gameObject.tag)
            {
                case "Enemy" :
                    GameObject Instance_effect = Instantiate(dust_effect, transform.position, transform.rotation);
                    Destroy(Instance_effect, 1.0f);
                break;
                case "Sword" :
                    Instance_effect = Instantiate(dust_effect, transform.position, transform.rotation);
                    Destroy(Instance_effect, 1.0f);
                break;    
                case "Spear" :
                    Instance_effect = Instantiate(dust_effect, transform.position, transform.rotation);
                    Destroy(Instance_effect, 1.0f);
                break;        
            }
        }    
    }
    void Start()
    {
        m_enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //시작되면 2초마다 움직이게 조정
        InvokeRepeating("MoveToNextWayPoint", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null)
        {
            m_enemy.SetDestination(m_target.position);
        }
        currentPosition = transform.position;
        var distance = (currentPosition - oldPosition);
        velocity = (distance.x * distance.x) + (distance.y * distance.y) + (distance.z * distance.z) / Time.deltaTime;
        oldPosition = currentPosition;
    }


}
