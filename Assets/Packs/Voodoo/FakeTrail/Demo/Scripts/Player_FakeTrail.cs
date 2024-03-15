using UnityEngine;

namespace Voodoo.Visual
{
	public class Player_FakeTrail : MonoBehaviour
	{
		public bool m_XOrY;

		private Vector3 m_BasePos;

		void Awake()
		{
			m_BasePos = transform.position;
		}

		void Update()
		{
			float percent = (Mathf.Sin(Time.time) + 1.0f) * 0.5f;

			Vector3 startVector = m_BasePos + (m_XOrY ? Vector3.right : Vector3.up);
			Vector3 endVector = m_BasePos + (m_XOrY ? Vector3.left : Vector3.down);

			transform.position = Vector3.Lerp(startVector, endVector, percent);
		}
	}
}
