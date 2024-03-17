using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //keep track of enemy movement speed, speed given in unity.
    public float moveSpeed;

    //the Path class is the array holding our path positions.
    private Path _thePath;
    //keep track of the current point this enemy is on.
    private int _currentPoint;
    private bool _reachedEnd;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle _theCastle;
    
    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, we will instantly assign _thePath to the object that has the Path script
        _thePath = FindObjectOfType<Path>();

        //sets _theCastle to the game object "Castle".
        _theCastle = FindAnyObjectByType<Castle>();

        //sets our attack counter to timeBetweenAttacks so we can start counting down.
        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_reachedEnd) 
        {
            //makes our enemy look where he is going.
            transform.LookAt(_thePath.points[_currentPoint]);
            //transform.position is the position x, y, z locations.  
            //Vector3 is something that has an x, y, z value.
            //MoveTowards function within Vector3 that we can use to move our object. it needs a current location, target location, and speed.
            //Time.deltaTime is a way to make the speed the same for every computer whether they are running on 60fps or 100fps.
            transform.position = Vector3.MoveTowards(transform.position, _thePath.points[_currentPoint].position, moveSpeed * Time.deltaTime);

            //check the distance between 2 points and see if it is less than .01f
            if (Vector3.Distance(transform.position, _thePath.points[_currentPoint].position) < .01f)
            {
                //if the distance to the first point is < .01f, we go to the next point.
                _currentPoint += 1;
                //if _curretPoint reaches our final point, stop moving.
                if (_currentPoint >= _thePath.points.Length)
                {
                    _reachedEnd = true;
                }
            }
        }
        else
        {
            //makes our attack counter count down
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                //if attackCounter reaches 0, we reset the counter and set it equal to timeBetweenAttacks
                attackCounter = timeBetweenAttacks;

                //once the attackCounter reaches 0, enemy attacks the castle and deals damage equal to the enemies damagePerAttack.
                _theCastle.TakeDamage(damagePerAttack);
            }
        }
    }
}
