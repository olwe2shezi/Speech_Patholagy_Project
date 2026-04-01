using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public Transform playerHead;
    public Transform playerBody;
    public Transform walkTarget;
    public Transform redBall;

    public TextMeshProUGUI instructionText;

    private int step = 0;
    private Vector3 startLookDir;

    void Start()
    {
        startLookDir = playerHead.forward;
        instructionText.text = "Look around.";
    }

    void Update()
    {
        switch (step)
        {
            case 0:
                CheckLookAround();
                break;

            case 1:
                CheckTurnAround();
                break;

            case 2:
                CheckWalk();
                break;

            case 3:
                CheckGrabBall();
                break;

            case 4:
                CheckDropBall();
                break;
        }
    }

    void CheckLookAround()
    {
        float angle = Vector3.Angle(startLookDir, playerHead.forward);

        if (angle > 40f)
        {
            step = 1;
            instructionText.text = "Turn your body around using the joystick.";
        }
    }

    void CheckTurnAround()
    {
        float bodyRotation = playerBody.eulerAngles.y;

        if (bodyRotation > 120f)
        {
            step = 2;
            instructionText.text = "Walk to the corner of the room.";
        }
    }

    void CheckWalk()
    {
        float distance = Vector3.Distance(playerBody.position, walkTarget.position);

        if (distance < 1.2f)
        {
            step = 3;
            instructionText.text = "Grab the red ball using the grip button.";
        }
    }

    void CheckGrabBall()
    {
        if (redBall.parent != null)
        {
            step = 4;
            instructionText.text = "Place the ball back down.";
        }
    }

    void CheckDropBall()
    {
        if (redBall.parent == null)
        {
            instructionText.text = "Tutorial Complete!";
        }
    }
}