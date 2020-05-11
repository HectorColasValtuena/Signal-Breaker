public static class SignalHelper
{
	//removes offset from original position and calculates loop overflow (if loopLength >0)
	public static int AbsoluteToRelativePosition (int position, int offset = 0, uint loopLength = 0)
	{
		position -= offset;

		if (loopLength == 0)
		{
			return position;
		}

		//if a loopLength is provided calculate overflow
		int loopedPosition = position % (int)loopLength;
		//ensure loop-relative position is in the positive range
		if (loopedPosition < 0) { loopedPosition += (int)loopLength; }

		return loopedPosition;

		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[TO-DO] [TEST-ME]
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	}
}
