using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceTrigger : MonoBehaviour
{
    private bool flag = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Enter " + collision.ToString());

        //if (string.Equals(collision.tag, "Player"))
       // {
            
       // }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Stay 1");
        //if (string.Equals(collision.tag, "Player"))
        //{
            
        //    if (flag == false)
        //    {
        //        //Debug.Log("Stay 1");
        //        flag = true;
        //        StartCoroutine(ExampleCoroutine(collision, collision.gameObject));
        //    }   else
        //    {
        //       // Debug.Log("Stay");
        //    }
        
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Exit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter2D with " + collision.gameObject.name);
        
       // gameObject.GetComponent<CraterCreator>().OnCollision(collision, collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        //Debug.Log("OnCollisionEnter2D stay " + collision.gameObject.name);
        if (string.Equals(collider.tag, "Player"))
        {

            if (flag == false)
            {
                //Debug.Log("Stay 1");
                flag = true;
                StartCoroutine(ExampleCoroutine(collider, collision.gameObject));
            }
            else
            {
                // Debug.Log("Stay");
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        //transform.parent.gameObject.GetComponent<CraterCreator>().OnCollision(collision);
    }

    IEnumerator ExampleCoroutine(Collider2D collision, GameObject impacter)
    {
        //Print the time of when the function is first called.
       // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        gameObject.GetComponent<EnemyController>().OnCollisionWithPlayer(collision, collision.gameObject);
        yield return new WaitForSeconds(1);
        flag = false;

        //After we have waited 5 seconds print the time again.
       // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
