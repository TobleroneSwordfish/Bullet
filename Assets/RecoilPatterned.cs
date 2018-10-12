using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilPatterned : FireEffect
{
    private class Cycle
    {
        private int max, current = 0;
        public Cycle(int i)
        {
            max = i;
        }
        public int Next()
        {
            if (current <= max)
            {
                return current++;
            }
            else
            {
                return 0;
            }
        }
    }
    public float[,] pattern = { { 0, 20 }, { 15, 10 }, { 0, 23 }, {-30, 14 } };
    public float resetTime = .25f;
    private float currentTime = 0;
    private int position = 0;
    private Cycle cycle;
    private bool fired = false;

    private void Start()
    {
        cycle = new Cycle(pattern.Length - 1);
    }

    public override void OnFire(Projectile p)
    {
        Quaternion origin = p.transform.rotation;
        Vector2 recoil = new Vector2(pattern[cycle.Next(), 0], pattern[cycle.Next(), 1]);
        Recoil(recoil, p.launcher.gameObject);
        StartCoroutine(Reset(p.launcher.gameObject, origin));
        base.OnFire(p);
    }
    private void Recoil(Vector2 direction, GameObject recoilee)
    {
        recoilee.transform.Rotate(recoilee.transform.right, direction.y);
        recoilee.transform.Rotate(recoilee.transform.up, direction.x);
    }

    IEnumerator Reset(GameObject obj, Quaternion origin)
    {
        Quaternion rotation = obj.transform.rotation;
        while (true)
        {
            obj.transform.rotation = Quaternion.Lerp(rotation, origin, Time.deltaTime);
            if (obj.transform.rotation == origin)
            {
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
