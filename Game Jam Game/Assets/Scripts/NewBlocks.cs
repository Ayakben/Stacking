using UnityEngine;

public class NewBlocks : MonoBehaviour
{
    private bool partOfGame;
    public float mark = 2.5f;
    Rigidbody2D rigidbody2D;
    Vector2 startPosition = new Vector2();
    public float y;
    //It also doesnt play nice when i try to decalre this in the start (DONT TOUCH YET!!!)
    Vector3 scaleBig = new Vector3(.2f, .2f, .2f);
    Vector3 scaleSmall = new Vector3(.1f, .1f, .1f);
    PolygonCollider2D polyCollider2D;
    void Start()
    {
        this.transform.localScale = scaleSmall;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        polyCollider2D = GetComponent<PolygonCollider2D>();
        polyCollider2D.isTrigger = true;
        partOfGame = false;
        this.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y - 2.5f, -.5f);
        startPosition = this.transform.position;

        //this.transform.SetAsFirstSibling();


    }

    // Update is called once per frame
    void Update()
    {
        if (!Score.instance.loss && !Score.instance.victory)
        {
            mark = Score.instance.score + 2.5f;
            if (startPosition.y != Camera.main.transform.position.y - 2.5f) startPosition = new Vector2(startPosition.x, Camera.main.transform.position.y - 2.5f);
            y = rigidbody2D.position.y;
            if (this.transform.position.y != startPosition.y && !partOfGame && rigidbody2D.freezeRotation != true)
            {
                this.transform.rotation = Quaternion.identity;
                rigidbody2D.MovePosition(startPosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (!partOfGame)
                {
                    if (rigidbody2D.position.y > mark)
                    {
                        polyCollider2D.isTrigger = false;
                        rigidbody2D.gravityScale = 1;
                        rigidbody2D.constraints = RigidbodyConstraints2D.None;
                        partOfGame = true;
                        rigidbody2D.gameObject.tag = "Set";
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
            if (partOfGame)
            {
                this.transform.localScale = scaleBig;
            }
        }
    }

}                  
