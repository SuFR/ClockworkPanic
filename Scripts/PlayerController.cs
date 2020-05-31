using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	[SerializeField] float speed = 10.0F;
	[SerializeField] bool isAlive = true;
	[SerializeField] float rotateSpeed = 10f;
	[SerializeField] float winTimer = 100f;
	[SerializeField] Text timeText;
	[SerializeField] GameObject winScreen;
	[SerializeField] GameObject gameOverScreen;
	private bool hasWon = false;
	private bool hasLost = false;
	private Health health;
	private TimeManager time;

	void Start()
	{
		health = GetComponent<Health>();
		time = GetComponent<TimeManager>();
	
	}

	void Update()
	{
		
		isAlive = health.IsAlive();
		if (isAlive)
		{
			winTimer -= Time.deltaTime;
			if(winTimer > 0)
			{
				timeText.text = "Time Left: " + winTimer.ToString("F2");
			}else
			{
				timeText.text = "Time Left: 00.00 You Survived! Hit Space Bar to move onto the next level";
			}
			
			if (winTimer < 0)
			{
				//Debug.Log("You Won!");
				
				WinScreen();
			}
		}
		if (!isAlive)
		{
			//Debug.Log(isAlive + "You Died!");
			GameOverScreen();
		}
		
		PlayerInput();
		FollowMouse();
		
	}
	private void GameOverScreen()
	{
		hasLost = true;
		gameOverScreen.SetActive(true);
		Time.timeScale = 0f;



	}

	private void WinScreen()
	{
		hasWon = true;
		winScreen.SetActive(true);
		Time.timeScale = 0f;

	}
	private void FollowMouse()
	{
		// Generate a plane that intersects the transform's position with an upwards normal.
		Plane playerPlane = new Plane(Vector3.up, transform.position);

		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Determine the point where the cursor ray intersects the plane.
		// This will be the point that the object must look towards to be looking at the mouse.
		// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
		//   then find the point along that ray that meets that distance.  This will be the point
		//   to look at.
		float hitdist = 0.0f;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast(ray, out hitdist))
		{
			// Get the point along the ray that hits the calculated distance.
			Vector3 targetPoint = ray.GetPoint(hitdist);

			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.unscaledDeltaTime);
		}
	}

	private void PlayerInput()
	{
		if (!hasWon && !hasLost)
		{
			if (Input.GetKey(KeyCode.W))
			{

				transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime);

			}
			if (Input.GetKey(KeyCode.S))
			{

				transform.Translate(Vector3.forward * speed * Time.unscaledDeltaTime * -1);
			}
			if (Input.GetKey(KeyCode.Space))
			{
				time.SlowTime();
			}
		}
		if (hasWon && !hasLost)
		{
			Debug.Log(SceneManager.sceneCountInBuildSettings);
			
			int y = SceneManager.GetActiveScene().buildIndex + 1;
			Debug.Log(y);
			if (Input.GetKeyDown(KeyCode.Space))
			{

				
				if (SceneManager.sceneCountInBuildSettings > y)
				{
					SceneManager.LoadScene(sceneBuildIndex: y);
					Time.timeScale = 1f;
				}else
				{
					SceneManager.LoadScene(sceneBuildIndex: 0);
				}
				
			}
		}
		if (hasLost && !hasWon)
		{

			SceneManager.LoadScene(sceneBuildIndex: SceneManager.sceneCountInBuildSettings - 1);

		}
		
		
	}

	
}