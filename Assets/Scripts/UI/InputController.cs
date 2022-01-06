using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler
{
#if UNITY_EDITOR
    [SerializeField] private int downEventCount = 0;
    [SerializeField] private int clickEventCount = 0;
    [SerializeField] private int beginDragEventCount = 0;
    [SerializeField] private int dragEventCount = 0;
    [SerializeField] private int upEventCount = 0;
#endif

    public static InputController Instance;
    [SerializeField] private Camera cam;
    [SerializeField] private EventSystem eventSystem;
    private static UnityEvent<Vector2> _downEvent = new UnityEvent<Vector2>();
    private static UnityEvent<Vector2> _clickEvent = new UnityEvent<Vector2>();
    private static UnityEvent<Vector2> _beginDragEvent = new UnityEvent<Vector2>();
    private static UnityEvent<Vector2> _dragEvent = new UnityEvent<Vector2>();
    private static UnityEvent<Vector2> _upEvent = new UnityEvent<Vector2>();

    private void Awake()
    {
        Instance = this;
    }

    public static event UnityAction<Vector2> DownUpdate
    {
        add
        {
            _downEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.downEventCount++;
#endif
        }
        remove
        {
            _downEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.downEventCount--;
#endif
        }
    }
    public static event UnityAction<Vector2> ClickUpdate
    {
        add
        {
            _clickEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.clickEventCount++;
#endif
        }
        remove 
        {
            _clickEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.clickEventCount--;
#endif
        }
    }
    public static event UnityAction<Vector2> BeginDragUpdate
    {
        add
        {
            _beginDragEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.beginDragEventCount++;
#endif
        }
        remove
        {
            _beginDragEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.beginDragEventCount--;
#endif
        }
    }
    public static event UnityAction<Vector2> DragUpdate
    {
        add
        {
            _dragEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.dragEventCount++;
#endif
        }
        remove
        {
            _dragEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.dragEventCount--;
#endif
        }
    }
    public static event UnityAction<Vector2> UpUpdate
    {
        add
        {
            _upEvent.AddListener(value);
#if UNITY_EDITOR
            Instance.upEventCount++;
#endif
        }
        remove
        {
            _upEvent.RemoveListener(value);
#if UNITY_EDITOR
            Instance.upEventCount--;
#endif
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _downEvent.Invoke(cam.ScreenToWorldPoint(eventData.position));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _clickEvent.Invoke(cam.ScreenToWorldPoint(eventData.position));
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _beginDragEvent.Invoke(cam.ScreenToWorldPoint(eventData.position));
    }
    public void OnDrag(PointerEventData eventData)
    {
        _dragEvent.Invoke(cam.ScreenToWorldPoint(eventData.position));
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _upEvent.Invoke(cam.ScreenToWorldPoint(eventData.position));
    }
}
