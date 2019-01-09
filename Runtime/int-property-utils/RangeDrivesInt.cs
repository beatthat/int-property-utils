using BeatThat.Properties;
using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Transition an a start to end value (e.g. a counter incrementing to a target)
	/// </summary>
	public class RangeDrivesInt : DisplaysFloat, IDrive<HasInt>
	{
		[SerializeField]private HasInt m_driven;

		[SerializeField]private int m_from;
		[SerializeField]private int m_to;

		[SerializeField]private bool m_useFromProp;
		[SerializeField]private HasInt m_fromProp;

		[SerializeField]private bool m_useToProp;
		[SerializeField]private HasInt m_toProp;

		public bool ClearDriven ()
		{
			m_driven = null; return true;
		}

		public int from 
		{ 
			get { return m_useFromProp && m_fromProp != null? m_fromProp.value: m_from; } 
			set { if(m_useFromProp && m_fromProp != null) { m_fromProp.value = value; } else { m_from = value; } } 
		}

		public int to 
		{
			get { return m_useToProp && m_toProp != null? m_toProp.value: m_to; } 
			set { if(m_useToProp && m_toProp != null) { m_toProp.value = value; } else { m_to = value; } }
		}

		public HasInt driven { get { return m_driven?? (m_driven = GetComponent<HasInt>()); } }

		public object GetDrivenObject() { return this.driven; }

		override public void UpdateDisplay()
		{
			this.driven.value = Mathf.RoundToInt(Mathf.Lerp(this.from, this.to, this.value));
		}
	}
}

