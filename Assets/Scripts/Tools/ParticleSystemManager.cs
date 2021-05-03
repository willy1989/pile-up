using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField] ParticleSystem[] stackParticleSystem;

    public void playStackParticleEffect(GameObject go, int level)
    {
        ParticleSystem particleSystem;

        if (level <= 2)
        {
            particleSystem = stackParticleSystem[0];
        }

        else if (level <= 4)
        {
            particleSystem = stackParticleSystem[1];
        }

        else
        {
            particleSystem = stackParticleSystem[2];
        }

        particleSystem.transform.position = go.transform.position - new Vector3(0f, go.transform.localScale.y / 2, 0f);

        particleSystem.transform.localScale = go.transform.localScale;

        particleSystem.Play();
    }

}
