using UnityEngine;

public class LoopingBackgrounds : MonoBehaviour
{
    #region Variables

    public Camera mainCamera;

    public GameObject firstGround;
    public GameObject secondGround;

    [SerializeField] private bool timeForFirst = true;
    [SerializeField] private float cameraSize;

    #endregion

    #region Unity Methods

    private void Update()
    {
        var cameraPositionX = mainCamera.transform.position.x - cameraSize * .5f;

        var firstGroundTransform = firstGround.transform;
        var secondGroundTransform = secondGround.transform;

        var firstGroundRightEdgePosition =
            CalculateRightPosition(firstGroundTransform.position.x, firstGroundTransform.localScale.x);
        var secondGroundRightEdgePosition =
            CalculateRightPosition(secondGroundTransform.position.x, secondGroundTransform.localScale.x);


        if ((cameraPositionX > firstGroundRightEdgePosition) && timeForFirst)
        {
            timeForFirst = false;
            AssignGroundPosition(firstGround,
                CalculateRightPosition(secondGroundRightEdgePosition, firstGroundTransform.localScale.x));
        }
        else if (cameraPositionX > secondGroundRightEdgePosition && !timeForFirst)
        {
            timeForFirst = true;
            AssignGroundPosition(secondGround,
                CalculateRightPosition(firstGroundRightEdgePosition, secondGroundTransform.localScale.x));
        }
    }

    private static float CalculateRightPosition(float positionX, float scaleX)
    {
        return positionX + scaleX * .5f;
    }

    private static void AssignGroundPosition(GameObject changeGround, float xValue)
    {
        changeGround.transform.position = new Vector2(xValue, changeGround.transform.position.y);
    }

    #endregion
}