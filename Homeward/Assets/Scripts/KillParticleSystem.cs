using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParticleSystem : MonoBehaviour {

    // Use this for initialization
    private IEnumerator Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(ps.main.duration-0.1f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
