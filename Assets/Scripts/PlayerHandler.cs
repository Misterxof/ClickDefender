using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Possibilities
{
    public class PlayerHandler : MonoBehaviour
    {
        public PlayerStats PlayerStats;

        [SerializeField]
        private Canvas _Canvas;
        private bool showCanvas;

        private void Start()
        {
            PlayerStats = GetComponent<PlayerStats>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("tab"))
            {
                if (_Canvas)
                {
                    showCanvas = !showCanvas;
                    _Canvas.gameObject.SetActive(showCanvas);
                }
            }
        }
    }
}
