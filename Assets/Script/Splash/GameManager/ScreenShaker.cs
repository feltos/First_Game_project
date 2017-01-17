using UnityEngine;
using System.Collections;





    public class ScreenShaker : MonoBehaviour
    {
        public float time = -1.0f;
        private float amplitude = 0.7f;
        private float decreaseFactor = 1.0f;
        private float freq = 7.0f;
        private float ttl = 2.5f;
        private bool verticalShake = true;
        private bool death = false;
        private int tension = 0;
		public Vector3 deltaPos;
        private Vector2 direction = Vector2.zero;
        // Use this for initialization
        void Start()
        {
			
			deltaPos = Vector3.zero;
        }

        
        void FixedUpdate()
        {
            if (!(time < 0.0f))
            {
				
				time += Time.deltaTime;
                if (death)
                {
                    decreaseFactor = (time / ttl - 1) * (time / ttl - 1);
                    if (verticalShake)
                    {
						deltaPos = new Vector3(0, amplitude * Mathf.Sin(2 * Mathf.PI * freq * time) * decreaseFactor, 0);
                    }
                    else
                    {
						deltaPos = new Vector3(amplitude * Mathf.Sin(2 * Mathf.PI * freq * time) * decreaseFactor, 0, 0);
                    }
                    if (time > ttl)
                    {
                        time = -1.0f;
                        death = false;
                    }
                }
                else if (tension>=2)
                {
                    decreaseFactor = (time / ttl) * (time / ttl);
                    if(decreaseFactor > 1.0f)
                    {
                        decreaseFactor = 1.0f;
                    }
					deltaPos = new Vector3(amplitude * Mathf.Sin(2 * Mathf.PI * freq * time) * decreaseFactor, 0, 0);
                    tension = 0;
                }
                else if(direction != Vector2.zero)
                {
                    decreaseFactor = (time / ttl - 1) * (time / ttl - 1);
                    
                        
                    deltaPos = new Vector3(amplitude * Mathf.Sin(2 * Mathf.PI * freq * time) * decreaseFactor*direction.x, amplitude * Mathf.Sin(2 * Mathf.PI * freq * time) * direction.x*decreaseFactor, 0);
                    
                    if (time > ttl)
                    {
                        time = -1.0f;
                        death = false;
                        direction = Vector2.zero;
                    }
                }
                else
                {
                    time = -1.0f;
                    direction = Vector2.zero;
                }

            }
            else
            {
				deltaPos = Vector3.zero;
                tension = 0;
                death = false;
                direction = Vector2.zero;
            }

            transform.position = deltaPos - new Vector3(0,0,10);
        }
        public void initShake(bool verticalShake = true)
        {
            time = 0.0f;
            this.verticalShake = verticalShake;
            decreaseFactor = 1.0f;
            death = true;
        }
        public void tensionShake(bool tension)
        {
            this.tension++;
            if(time < 0.0f)
                time = 0.0f;
        }
        public void shakeDirection(Vector2 direction)
        {
            time = 0.0f;
            this.direction = direction;
            decreaseFactor = 1.0f;
            death = false;
        }
    }
