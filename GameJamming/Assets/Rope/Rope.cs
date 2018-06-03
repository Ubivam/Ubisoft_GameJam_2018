using UnityEngine;

public class Rope : MonoBehaviour {

	public Rigidbody2D hook;

	public GameObject linkPrefab;

	public Weight weigth;

    [SerializeField]
    private GameObject second;

    [SerializeField]
    private GameObject third;

    public int links = 7;

	void Start () {
		GenerateRope();
	}

	void GenerateRope ()
	{
		Rigidbody2D previousRB = hook;
		for (int i = 0; i < links; i++)
		{
            GameObject link = Instantiate(linkPrefab, transform); ;
          /* if (i == 0)
            {
                link = Instantiate(second, transform);
            }
            else
            {
                link = Instantiate(third, transform);
            }
            */
			HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
			joint.connectedBody = previousRB;

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody2D>();
			} else
			{
				weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
			}

			
		}
	}

}
