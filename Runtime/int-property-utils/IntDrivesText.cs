using BeatThat.Properties;

namespace BeatThat
{
	/// <summary>
	/// Use an int to drive a text value (e.g. a counter)
	/// </summary>
	public class IntDrivesText : DisplaysInt, IDrive<HasText>
	{
		public bool ClearDriven ()
		{
			m_driven = null; return true;
		}

		public HasText m_driven;
		public string m_format = "";

		public HasText driven { get { return m_driven?? (m_driven = GetComponent<HasText>()); } }

		public object GetDrivenObject() { return this.driven; }

		public override void UpdateDisplay ()
		{
			var str = string.IsNullOrEmpty(m_format)? this.value.ToString(): this.value.ToString(m_format);
			this.driven.value = str;
		}

	}
}

