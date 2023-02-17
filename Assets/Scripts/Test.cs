using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    public Transform _transform;
    private bool ready = true;
    private int rotX = 90;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            StartCoroutine(SetRotation(rotX));
            Increment();
        }
        print(_transform.eulerAngles + " |||| " + _transform.localEulerAngles);
        
    }
    private IEnumerator SetRotation(int number)
    {
        ready = false;
        print("start wait");
        yield return new WaitForSeconds(5);
        print("end wait");
        _transform.eulerAngles = new Vector3(number, 0, 0);
        ready = true;

    }
    private void Increment()
    {
        if (rotX == -90)
        {
            rotX = 90;
        }
        else
        {
            rotX-= 10;
        }
    }
}
