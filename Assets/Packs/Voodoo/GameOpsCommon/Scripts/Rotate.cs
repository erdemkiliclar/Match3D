using UnityEngine;

namespace Voodoo.Visual
{
	public class Rotate : MonoBehaviour
	{
		public float speed;
		public Vector3 eulerAngles;

		void Update()
		{
			transform.Rotate(eulerAngles * speed * Time.deltaTime);
		}
	}
}