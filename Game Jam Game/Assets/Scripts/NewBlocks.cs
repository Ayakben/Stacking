using UnityEngine;

public class NewBlocks : MonoBehaviour
{
    PolygonCollider2D polyCollider2D;
    private bool partOfGame;
    public float mark; //Mark needs to be moved up proportional to score 
    Rigidbody2D rigidbody2D;
    Vector2 startPosition = new Vector2();
    public float y;
    //It also doesnt play nice when i try to decalre this in the start (DONT TOUCH YET!!!)
    Vector3 scaleBig = new Vector3(.2f, .2f, .2f);
    Vector3 scaleSmall = new Vector3(.1f, .1f, .1f);
    void Start()
    {
        this.transform.localScale = scaleSmall;
        mark = 2.5f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        polyCollider2D = GetComponent<PolygonCollider2D>();
        partOfGame = false;
        startPosition = this.transform.position;
        rigidbody2D.gravityScale = 0;
        polyCollider2D.isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {
        y = rigidbody2D.position.y;
        if (Input.GetMouseButtonUp(0))
        {
            if (!partOfGame)
            {
                if (rigidbody2D.position.y > mark)
                {
                    polyCollider2D.isTrigger = false;
                    rigidbody2D.gravityScale = 1;
                    partOfGame = true;
                    //after it's dropped, create an object to fill this block's empty slot
                    Generation.instance.CreateObject(startPosition);
                }
                //there to setup putting the block back if the user releases the block under the mark
                else
                {
                    rigidbody2D.MovePosition(startPosition);
                }
            }
        }
        //Scales the object based on if it is above the line or not (I know it can be neater and prob put in the above loop but its 3 am, it works, and dont question my methods i got other shit to fix)
        if (rigidbody2D.position.y > mark && !partOfGame)
        {
            this.transform.localScale = scaleBig;
        }
        else 
        {
            this.transform.localScale = scaleSmall;
        }
        if(partOfGame)
        {
            this.transform.localScale = scaleBig;
        }
    }
}
                  
