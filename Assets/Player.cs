using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
        public Route currentRoute;

        private int routePosition;

        public int steps;

        private bool isMoving;


        void Update()
        {
                if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
                {
                        steps = Random.Range(1, 7);     
                        Debug.Log($"Dice Rolled" + steps);
                        
                }
        }

        IEnumerator Move()
        {
                if (isMoving)
                {
                        yield break;
                }
                isMoving = true;
                while (0<steps)
                {
                        Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
                        while (MoveToNextNode(nextPos))
                        {
                                yield return null;
                        }

                        yield return new WaitForSeconds(0.1f);
                        steps--;
                        routePosition++;
                }

                isMoving = false;
        }

        bool MoveToNextNode(Vector3 goal)
        {
                return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
        }
}


