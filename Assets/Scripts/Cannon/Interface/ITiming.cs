
public interface ITiming
{

	bool IsActive();

	void SetNewIntervalMs(double newInterval_ms);

	void SetActive(bool state);
}
