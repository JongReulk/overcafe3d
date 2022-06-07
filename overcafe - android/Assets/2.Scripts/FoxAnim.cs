using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnim : MonoBehaviour
{
    Animator _animator;
    

    
    private int randomInt;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(GameManager.instance.isPaused)
        {
            return;
        }
        randomInt = Random.Range(0, 3);

        
        if (randomInt == 0 )
        {
            _animator.SetTrigger("IsYes");
            
        }

        if (randomInt == 1)
        {

            _animator.SetTrigger("IsNo");

        }

        if (randomInt == 2)
        {

            _animator.SetTrigger("IsBreak");
        }

        
        
    }
    
}
