using UnityEngine;

namespace Possibilities
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerStats PlayerStats;

        [SerializeField]
        private Canvas _canvas;
        private bool _showCanvas;

        private void Start()
        {
            PlayerStats = GetComponent<PlayerStats>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("tab"))
            {
                if (_canvas)
                {
                    _showCanvas = !_showCanvas;
                    _canvas.gameObject.SetActive(_showCanvas);
                }
            }
        }
    }
}
