using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singleton class: GameManager

	public static GameManager Instance;
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	#endregion

	Camera cam;
	public int Score;
	public GameObject Cannon;
	public GameObject[] Levels;
	public GameObject[] NumberPrefabs;
	public Trajectory trajectory;
	public GameObject BallPrefab;
	public Vector3 offset;
	public int BallRight = 5;
	public int TotalBallRight = 5;
	public GameObject GameWonCanvas;
	
	[SerializeField] float pushForce = 4f;
	private bool isDragging = false;

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

	//---------------------------------------
	void Start()
	{
		//ball = FindObjectOfType<BallController>();
		cam = Camera.main;
		//DesactivateRb();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isDragging = true;
			OnDragStart();
		}
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			OnDragEnd();
		}
		if (isDragging)
		{
			OnDrag();
		}
		if (Input.GetMouseButtonDown(0))
		if(BallRight > 0)
		{
			spawnBall();
			BallRight--;
		}
 
	}

	//-Drag--------------------------------------
	void OnDragStart()
	{
		//DesactivateRb();
		//startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		startPoint = new Vector2(0.178f, 4.131f);
		trajectory.Show();
	}

	void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		direction = (endPoint - startPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine(startPoint, endPoint);
		trajectory.UpdateDots(Cannon.transform.position, force);
	}
	
	void OnDragEnd()
	{
		//push the ball
		//ActivateRb();
		

		//Push(force);

		trajectory.Hide();
	}

	void spawnBall()
    {
		//GameObject newBall = Instantiate(BallPrefab); 
		Vector2 spawnPosition = new Vector2(0.12f, 3.995f);
		GameObject a = Instantiate(BallPrefab, spawnPosition, Quaternion.identity);
		a.GetComponent<Rigidbody2D>().velocity = force;
	}
	
	public void spawnAndDestroyNumbers(int index, Vector2 spawnposition)
	{

		GameObject Number = Instantiate(NumberPrefabs[index], spawnposition, Quaternion.identity);
		Destroy(Number, 0.5f);
	}

	void DestroyLeftBalls()
    {
		GameObject[] leftBalls = GameObject.FindGameObjectsWithTag("Ball");
		for(int i = 0; i < leftBalls.Length; i++)
        {
			Destroy(leftBalls[i]);
        }
    }

	public void GiveScore(int score)
    {
		Score += score;
		setLevels();
    }

	public void setLevels()
    {
        if (LevelTasks.Instance.IsLevel1TasksCompleted())
        {
			
			FindObjectOfType<AudioController>().Play("PapaFiesta");
			DestroyLeftBalls();
			Levels[0].SetActive(false);
			Score = 0; // ResetScore
			LevelTasks.Instance.CarrotCounter = 0;
			BallRight = 10;
			Levels[1].SetActive(true);
			//LevelTasks.Instance.ResetTasks();// TasksCompleted = false
			LevelTasks.Instance.IsLevel1TasksCompleted();

		}
		if (LevelTasks.Instance.IsLevel2TasksCompleted())
		{

			FindObjectOfType<AudioController>().Play("PapaFiesta");
			DestroyLeftBalls();
			Levels[1].SetActive(false);
			Score = 0; // ResetScore
			LevelTasks.Instance.CarrotCounter = 0;
			BallRight = 10;
			Levels[2].SetActive(true);
			LevelTasks.Instance.DroppedFruit = 0;
			//LevelTasks.Instance.ResetTasks(); // TasksCompleted = false
		}
		if (LevelTasks.Instance.IsLevel3TasksCompleted())
		{

			FindObjectOfType<AudioController>().Play("PapaFiesta");
			DestroyLeftBalls();
			Levels[2].SetActive(false);
			GameWonCanvas.SetActive(true);
			Score = 0; // ResetScore
			//LevelTasks.Instance.CarrotCounter = 0;
			//LevelTasks.Instance.DroppedFruit = 0;
			//LevelTasks.Instance.ResetTasks(); // TasksCompleted = false
		}
	}
	
}