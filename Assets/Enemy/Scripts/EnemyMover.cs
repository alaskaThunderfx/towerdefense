using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======
[RequireComponent(typeof(Enemy))]
>>>>>>> waypoint
public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]
    [Range(0f, 5f)]
<<<<<<< HEAD
    float speed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
=======
    float speed = 1.5f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
>>>>>>> waypoint
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
<<<<<<< HEAD
=======

        if (!enemy)
            yield break;

        FinishPath();
>>>>>>> waypoint
    }
}
