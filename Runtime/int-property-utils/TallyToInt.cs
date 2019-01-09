using BeatThat.Properties;
using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Transition an a start to end value (e.g. a counter incrementing to a target)
	/// </summary>
	public class TallyToInt : DisplaysFloat, IDrive<HasInt>
	{
		public HasInt m_driven;
		public int m_from;
		public int m_to;

		public bool ClearDriven ()
		{
			m_driven = null; return true;
		}

		public int from { get { return m_from; } set { m_from = value; } }
		public int to { get { return m_to; } set { m_to = value; } }

		public HasInt driven { get { return m_driven?? (m_driven = GetComponent<HasInt>()); } }

		public object GetDrivenObject() { return this.driven; }

		override public void UpdateDisplay()
		{
			this.driven.value = Mathf.RoundToInt(Mathf.Lerp(this.from, this.to, this.value));
		}
	}
}

