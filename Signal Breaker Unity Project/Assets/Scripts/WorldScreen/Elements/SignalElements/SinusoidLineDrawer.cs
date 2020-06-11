using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidLineDrawer : MonoBehaviour
{
	public float intensity;
	public float length;
	private int pointDensity = 42;

	public LineRenderer lineRenderer;

	//Este método actualiza el lineRenderer según las propiedades del objeto
	public void UpdateLine ()
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
				(((Mathf.Cos(horzPos) - 1) * -1)/2) * length, //Cambiamos el coseno de un rango (-1, 1) a un rango (0, 1)
				 Mathf.Sin(horzPos) * intensity,
				 0
			);
		}

		lineRenderer.positionCount = pointDensity + 2;
		lineRenderer.SetPositions(pointList);
	}

	public void Start ()
	{
		UpdateLine();
	}
}
