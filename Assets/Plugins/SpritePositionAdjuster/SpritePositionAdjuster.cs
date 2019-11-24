using UnityEngine;

namespace KiliWare
{
    public class SpritePositionAdjuster : MonoBehaviour
    {
        private Vector2 startPos;
        private Vector2 startLocalScale;
        [SerializeField] private float originalHeight;

        void Start()
        {
            startLocalScale = transform.localScale;
            startPos = transform.position - Camera.main.transform.position;

            #if UNITY_EDITOR
                Debug.Log("Current screen height is: " + Screen.height + ". If you want to preserve current scale and position of this sprites, set originalHeight property " + Screen.height + " and restart the scene to check whether it works correctly.");
            #endif
            adjustSpriteSize();
        }

        private void adjustSpriteSize()
        {
            float ajustedHeight = originalHeight / Screen.height;

            transform.localScale = new Vector2(startLocalScale.x, startLocalScale.y) * ajustedHeight;

            Vector2 adjustedPosition = startPos * ajustedHeight;
            adjustedPosition.y += Camera.main.transform.position.y;
            transform.position = adjustedPosition;
        }
    }
}

