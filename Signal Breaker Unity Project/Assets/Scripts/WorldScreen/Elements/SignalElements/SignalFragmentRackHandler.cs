using SignalHierarchy;
using UnityEngine;

namespace WorldScreen
{
	public class SignalFragmentRackHandler : MonoBehaviour
	{
		public uint fragmentMaxLength = 6;//!!!!!!!!!!!!!!!
		public GameObject waveElementPrefab = null;

		private ISignalContainer content = null;

		public void SetParametersAndRedraw (ISignalContainer newContent)
		{
			content = newContent;
			Redraw();
		}

		public void Redraw ()
		{
			if (waveElementPrefab == null) { Debug.LogError("SignalFragmentRackHandler.Redraw(): NULL waveElementPrefab"); return; }
			if (content == null) { Debug.LogError("SignalFragmentRackHandler.Redraw(): NULL content"); return; }

			content.AutoRebaseOffsets();
			ClearContents();

			ISignalHandler signalHandler = content as ISignalHandler;
			for (int i = 0; i < fragmentMaxLength; i++)
			{
				if (signalHandler.HasValuesAt(i, loopLength: fragmentMaxLength))
				{
					AdjustSizeToElementCount(i+1);
					RectTransform newElementTransform = Instantiate(waveElementPrefab, transform).transform as RectTransform;

					newElementTransform.position = new Vector3(GetElementWidth(i), 0, 0);
					//newElementTransform.rect.
				}
			}
		}

		private void ClearContents ()
		{
			foreach (Transform child in transform)
			{
				Destroy (child);
			}
		}

		private void AdjustSizeToElementCount (int elementCount)
		{
			float targetWidth = GetElementWidth() * elementCount;
			RectTransform rectTransform = (transform as RectTransform);
			rectTransform.rect.Set(rectTransform.rect.x, rectTransform.rect.y, targetWidth, (waveElementPrefab.transform as RectTransform).rect.height);
			//rectTransform.rect = new Rect (rectTransform.rect.x, rectTransform.rect.y, targetWidth, rectTransform.rect.height);
		}

		//return the width for X wave elements. One if omitted
		private float GetElementWidth (int count = 1)
		{
			return (waveElementPrefab.transform as RectTransform).rect.width * count;
		}
	}
}