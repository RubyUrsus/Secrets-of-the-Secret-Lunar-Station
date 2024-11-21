using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class AutoDestroyParticle : MonoBehaviour
    {
        private void Start()
        {
            var ps = GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(gameObject, ps.main.duration + ps.main.startLifetime.constant);
            }
        }
    }

