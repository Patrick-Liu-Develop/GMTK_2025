using UnityEngine;

namespace GMTK_2025.UI
{
    public class CardLayout : MonoBehaviour
    {
        private RectTransform panelRectTransform;
        private float panelHeight;

        private void Awake()
        {
            panelRectTransform = GetComponent<RectTransform>();
            UpdateLayout();
        }

        [ContextMenu("Update Layout")]
        public void UpdateLayout()
        {
            if (panelRectTransform == null)
            {
                panelRectTransform = GetComponent<RectTransform>();
            }

            panelHeight = panelRectTransform.rect.height;
            
            int childCount = transform.childCount;
            RectTransform[] children = new RectTransform[childCount];
        
            for (int i = 0; i < childCount; i++)
            {
                children[i] = transform.GetChild(i) as RectTransform;
                
                children[i].sizeDelta = new Vector2(panelHeight, panelHeight);
                
                children[i].anchorMin = new Vector2(1, 0.5f);
                children[i].anchorMax = new Vector2(1, 0.5f);
                children[i].pivot = new Vector2(1, 0.5f);
            }
            
            float currentX = 0f;
            for (int i = 0; i < childCount; i++)
            {
                children[i].anchoredPosition = new Vector2(currentX, 0);
                currentX -= panelHeight;
            }
        }
        
        private void OnTransformChildrenChanged()
        {
            UpdateLayout();
        }
    }
}