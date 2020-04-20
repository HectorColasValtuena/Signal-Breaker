//Object representing the value of a single wave.
//Contains a value representing its intensity and a sign representing its polarity.
[System.Serializable]
public class WaveValue
{
	public int value;
	public int sign;

	public WaveValue (int __value, int __sign)
	{
		value = __value;
		sign = __sign;
	}

	//return this wave represented as a single signed integer
	public int GetIntegerValue () {
		return value * ((sign >= 0) ? 1 : -1);
	}
}