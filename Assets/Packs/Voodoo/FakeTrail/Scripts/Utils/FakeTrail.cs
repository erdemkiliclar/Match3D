using UnityEngine;

namespace Voodoo.Visual
{
	[RequireComponent(typeof(LineRenderer))]
	public class FakeTrail : MonoBehaviour
	{
		public enum LocalDirections
		{
			XAxis,
			YAxis,
			ZAxis
		}

		// Number of points in the trail
		public int m_TrailResolution;

		// How far the points 'lag' behind each other in terms of position
		public float m_LagTime;

		// Movement direction
		public LocalDirections m_LocalDirectionToUse;

		// This would be the distance between the individual points of the line renderer
		public float m_Offset;

		private Vector3[] m_LineSegmentPositions;
		private Vector3[] m_LineSegmentVelocities;

		// Cache
		private Transform m_Transform;
		private LineRenderer m_LineRenderer;

		private Vector3 GetDirection()
		{
			switch (m_LocalDirectionToUse)
			{
				case LocalDirections.XAxis:
					return transform.right;
				case LocalDirections.YAxis:
					return transform.up;
				case LocalDirections.ZAxis:
					return transform.forward;
			}

			Debug.LogError("The variable 'localDirectionToUse' on the 'ManualTrail' script, located on object " + name + ", was somehow invalid. Please investigate!");
			return Vector3.zero;
		}

		private void Reset()
		{
			m_TrailResolution = 10;
			m_LagTime = 0.05f;
			m_LocalDirectionToUse = LocalDirections.XAxis;
			m_Offset = 0.3f;
		}

		private void Init()
		{
			// Init cache
			m_Transform = transform;
			m_LineRenderer = GetComponent<LineRenderer>();
			m_LineRenderer.positionCount = m_TrailResolution;

			m_LineSegmentPositions = new Vector3[m_TrailResolution];
			m_LineSegmentVelocities = new Vector3[m_TrailResolution];
		}

		// Use this for initialization
		private void Start()
		{
			Init();

			Vector3 facingDirection = GetDirection();

			// Initialize our positions
			for (int i = 0; i < m_LineSegmentPositions.Length; i++)
			{
				m_LineSegmentPositions[i] = Vector3.zero;
				m_LineSegmentVelocities[i] = Vector3.zero;

				if (i == 0)
				{
					// Set the first position to be at the base of the transform
					m_LineSegmentPositions[i] = m_Transform.position;
				}
				else
				{
					// All subsequent positions would be an offset of the original position.
					m_LineSegmentPositions[i] = m_Transform.position + (facingDirection * (m_Offset * i));
				}
			}
		}

		// Update is called once per frame
		private void LateUpdate()
		{
			Vector3 facingDirection = GetDirection();

			for (int i = 0; i < m_LineSegmentPositions.Length; i++)
			{
				if (i == 0)
				{
					// We always want the first position to be exactly at the original position
					m_LineSegmentPositions[i] = transform.position;
				}
				else
				{
					// All others will follow the original with the offset that you set up
					m_LineSegmentPositions[i] = Vector3.SmoothDamp(m_LineSegmentPositions[i], m_LineSegmentPositions[i - 1] + (facingDirection * m_Offset), ref m_LineSegmentVelocities[i], m_LagTime);
				}

				// Once we're done calculating where our position should be, set the line segment to be in its proper place
				m_LineRenderer.SetPosition(i, m_LineSegmentPositions[i]);
			}
		}
	}
}