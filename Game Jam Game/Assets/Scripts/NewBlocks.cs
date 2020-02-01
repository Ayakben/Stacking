using UnityEngine;

public class NewBlocks : MonoBehaviour
{
    public static GameObject gameobject;
    BoxCollider2D boxCollider2D = gameobject.GetComponent<BoxCollider2D>();
    private static bool canClick;
    public bool partOfGame;
    public float mark = 4f;
    Rigidbody2D rigidbody2D = new Rigidbody2D();
    Vector2 startPosition = new Vector2();
    public float y;
    void Start()
    {
        rigidbody2D.GetComponent<Rigidbody2D>();
        canClick = true;
        partOfGame = false;
        startPosition = rigidbody2D.position;
        rigidbody2D.gravityScale = 0;
        boxCollider2D.isTrigger = true;
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
                    boxCollider2D.isTrigger = false;
                    rigidbody2D.gravityScale = 1;
                    partOfGame = true;
                    canClick = false;
                }
                //there to setup putting the block back if the user releases the block under the mark
                else
                {
                    rigidbody2D.MovePosition(startPosition);
                }
            }
        }
    }
    public static bool getClick()
    {
        return canClick;
    }
    public static void setClick(bool setter)
    {
        canClick = setter;
    }
}
