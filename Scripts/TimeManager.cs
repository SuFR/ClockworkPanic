using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2.0f;
    


    public void SlowTime()
    {
        
        // 1 divided by slowdownFactor 0.05 == 20 20 times slower than normal
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        
    }
    void Update()
    {
        
        Time.timeScale += (1f / slowdownLength) * Time.deltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        
    }
    public float GetSpeedOffset()
    {
        return 1 / slowdownFactor;
    }
   
}
