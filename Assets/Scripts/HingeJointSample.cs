using UnityEngine;
using System.Collections;

public class HingeJointSample : MonoBehaviour
{
    private GameObject[] spawnPoints;
    private GameObject ball, rota;
    private SpriteRenderer ballSpriteRenderer;
    private Rigidbody2D ballRigidbody;

    public GameObject motorPlatform;

    // Use this for initialization
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        ball = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"), 
                                       GetSpawnPoint(),
                                       Quaternion.identity);

        ballSpriteRenderer = ball.GetComponent<SpriteRenderer>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballSpriteRenderer.isVisible)
        {
            ballRigidbody.velocity = Vector3.zero;
            ball.transform.position = GetSpawnPoint();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            JointMotor2D motor = motorPlatform.GetComponent<HingeJoint2D>().motor;
            motor.motorSpeed *= -1;
            motorPlatform.GetComponent<HingeJoint2D>().motor = motor;
        }
    }

    private Vector3 GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

}