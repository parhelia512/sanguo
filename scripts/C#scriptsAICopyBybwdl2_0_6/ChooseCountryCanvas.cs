using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseCountryCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    /*

public class SelectHorizontalScrollItem : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [Tooltip("ͼƬ")]
    [SerializeField] private Image image;
    [Tooltip("��������")]
    [SerializeField] private Text nameText;
    [Tooltip("������")]
    [SerializeField] private CanvasGroup canvasGroup;

    [Tooltip("ѡ������")]
    public int itemIndex;
    [Tooltip("��Ϣ����")]
    public int infoIndex;
    [Tooltip("�����ı�")]
    public string description;

    private SelectHorizontalScroll selectHorizontalScroll; [HideInInspector]
    public RectTransform rectTransform;
    private bool isDrag;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

}

  
    ///<summary>
    ///������Ϣ
    ///summary>
    ///<param name = "sprite" > ͼƬ </ param >
    ///< param name="name">����</param>
    ///<param name = "description" > ���� </ param >
    ///< param name="infoIndex">��Ϣ����</param>
    ///<param name = "selectHorizontalScroll" > ����ˮƽ����ѡ���б�ű� </ param >
    public void SetInfo(Sprite sprite, string name, string description, int infoIndex,
        SelectHorizontalScroll selectHorizontalScroll)
    {
        image.sprite sprite; nameText.text = name;
        this.description description;
        this.infoIndex = infoIndex;
        this.selectHorizontalScroll selectHorizontalScroll;
    }

    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = false; selectHorizontalScroll.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDrag)
        {
            selectHorizontalScroll.Select(itemIndex, infoIndex, rectTransform);
        }
        selectHorizontalScroll.OnPointerUp(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true; selectHorizontalScroll.OnDrag(eventData);
    }
}

    */