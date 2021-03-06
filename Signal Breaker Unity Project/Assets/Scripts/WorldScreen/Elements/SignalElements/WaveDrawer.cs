﻿
using SignalHierarchy;
using UnityEngine;

namespace WorldScreen
{
	public class WaveDrawer : MonoBehaviour
	{
		private float baseZ = -1.0f;
		private int pointDensity = 42;
		//private ISignalValue wave;
		private float length;
		private float intensity;

		public LineRenderer lineRenderer;

		//Configura la onda e inicia un re-dibujado
		//targetWave es el objeto que contendrá el valor que queremos dibujar
		//si length > 0, la onda medirá length de punta a punta. Si omitido o < 0, cogerá length de la anchura del contenedor
		//si se provee material, ajustaremos el material usado por el LineRenderer
		public void SetParametersAndRedraw (ISignalValue targetWave, float targetLength = -1.0f, Material material = null)
		{
			if (targetWave == null) { Debug.LogWarning("no ISignalValue element provided to render @WaveDrawer.RedrawLine();"); return; }
			SetParametersAndRedraw(targetWave.Value, targetLength, material);
			//wave = targetWave;
			
		}

		public void SetParametersAndRedraw (int waveValue, float targetLength = -1.0f, Material material = null)
		{
			intensity = waveValue;
			length = (targetLength > 0.0f) ? targetLength : GetLengthFromContainer();
			if (material != null) { lineRenderer.material = material; }

			RedrawLine();

		}


		//Este método actualiza el lineRenderer según las propiedades del objeto
		public void RedrawLine ()
		{
			//lista de puntos que vamos a inyectar al lineRenderer
			Vector3[] pointList = new Vector3[pointDensity + 2];

			//iterar sobre la lista de puntos rellenandola
			for (int i = 0; i <= (pointDensity+1); i++)
			{
				//creamos un nuevo vector3 y lo introducimos en la posición correcta de la lista
				//Vector3 (x, y, z)
				//X será la longitud
				//Y será el seno de la intensidad
				float horzPos = (Mathf.PI/(pointDensity+1)) * i;

				pointList[i] = new Vector3(
					(((Mathf.Cos(horzPos) - 1) * -1)/2) * length,	//X  //Cambiamos el coseno de un rango (-1, 1) a un rango (0, 1)
					 Mathf.Sin(horzPos) * intensity,				//Y
					 baseZ											//Z
				);
			}

			lineRenderer.positionCount = pointDensity + 2;
			lineRenderer.SetPositions(pointList);
		}

		private float GetLengthFromContainer () {
			//Debug.Log((transform as RectTransform).rect.width);
			return (lineRenderer.transform as RectTransform).rect.width;
		}
	}
}