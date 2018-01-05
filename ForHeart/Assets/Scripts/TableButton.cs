using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class TableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
{

    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    public float durationThreshold = 3.0f;

    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;

    // Use this for initialization
    void Start () {
		
	}

    private bool isStarToDecelerate = false;

    // Update is called once per frame
    private void Update()
    {
        if (isPointerDown && !longPressTriggered)
        {
            CanvasControl.Instance.tableButton.Rotate(200.0f, true);
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
                LongPress();
            }
        }
    }

    private float z;
    private  float rotateSpeed = 200;

    public void Reset()
    {
        rotateSpeed = 200;
    }

    public void Rotate(float speed, bool isAccelerate, float offset = 1.0f)
    {

        z -= (Time.deltaTime * rotateSpeed);
        rotateSpeed += offset;

        if (z > 360.0f)
            z -= 360.0f;

        this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, z);

    }

    public void LongPress()
    {
        Debug.Log("LongPress ! ! !");

        CanvasControl.Instance.ShowText();

        this.transform.DOKill();
        this.transform.DORotate(new Vector3(0, 0, 0), 1.5f, RotateMode.FastBeyond360).SetEase(Ease.OutExpo);
    }

    public void Click()
    {
        Debug.Log("Click ! ! !");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;

        CanvasControl.Instance.ResetText();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        Reset();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerDown = false;
        Reset();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!longPressTriggered)
        {
            Click();
            CanvasControl.Instance.ResetText();
        }
    }
}
