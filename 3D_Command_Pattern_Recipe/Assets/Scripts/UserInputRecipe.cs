using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputRecipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                /*
                if (hitInfo.collider.tag == "forwardbutton")
                {
                	Debug.Log("Forward button pressed.");
                    //execute 
                    ICommand click = new RecipeCommand();
                    click.Execute();
                    RecipeManager.Instance.AddCommand(click);
                }
                else if (hitInfo.collider.tag == "backwardbutton")
                {
                	Debug.Log("Undo button pressed.");
                	// undo
                	ICommand click = new RecipeCommand();
                    click.Undo();
                    RecipeManager.Instance.AddCommand(click);
                }
                */
            }
        }
    }
}
