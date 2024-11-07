using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolChicken : MonoBehaviour
{
    public delegate void PatrolDoneDelegate();
    private PatrolDoneDelegate patrolDoneCallback = null;
    public PatrolDoneDelegate PatrolDoneCallback { 
        set { patrolDoneCallback = value;  }
    }

    private bool isMoving = false; 
    private float waitTime = 1f;

    private void Start()
    {
        
    }

    // Destination/Source
    public void PatrolStart(Vector3 _dest)
    {
        StartCoroutine(PatrolCoroutine(_dest));
    }

    private IEnumerator PatrolCoroutine(Vector3 _dest) {
        Vector3 startPos = transform.position;
        Vector3 endPos = _dest;
        endPos.y = transform.position.y;
        float t = 0f;

        isMoving = true;

        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return new WaitForSeconds(waitTime);
        patrolDoneCallback?.Invoke();
    }

    public Vector3 GetPosition() {
        return transform.position;
    }
}
