using UnityEngine;

namespace KiliWare
{
    public class SpritePositionAdjuster : MonoBehaviour
    {
        protected Vector2 startPos;
        protected Vector2 startLocalScale;
        [SerializeField] protected float originalHeight;
        [SerializeField] protected bool keepsPositionUpdated = false;
        protected int beforeScreenWidth;
        protected int beforeScreenHeight;

        void Awake()
        {
            startLocalScale = transform.localScale;
            startPos = transform.position - Camera.main.transform.position;

            #if UNITY_EDITOR
                Debug.Log("Current screen height is: " + Screen.height + ". If you want to preserve current scale and position of this sprites, set originalHeight property " + Screen.height + " and restart the scene to check whether it works correctly.");
            #endif

            beforeScreenWidth = Screen.width;
            beforeScreenHeight = Screen.height;

            adjustSpritePosition();
        }
        
        protected void adjustSpritePosition()
        {
            float ajustedHeight = originalHeight / Screen.height;

            transform.localScale = new Vector2(startLocalScale.x, startLocalScale.y) * ajustedHeight;

            Vector2 adjustedPosition = startPos * ajustedHeight;
            adjustedPosition.y += Camera.main.transform.position.y;
            transform.position = adjustedPosition;
        }

        // When you checkes "keepsPositionUpdated",
        // the sprite position's change follows the change of window size. 
        protected void Update()
        {
            if (keepsPositionUpdated && isScreenSizeChanged())
            {
                adjustSpritePosition();
                beforeScreenWidth = Screen.width;
                beforeScreenHeight = Screen.height;
            }
        }

        protected bool isScreenSizeChanged()
        {
            return beforeScreenHeight != Screen.height || beforeScreenWidth != Screen.width;
        }
    }
}

