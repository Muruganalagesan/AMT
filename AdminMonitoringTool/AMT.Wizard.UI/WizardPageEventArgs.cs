using System.ComponentModel;

namespace AMT.Wizard.UI
{
	public class WizardPageEventArgs : CancelEventArgs
	{
	   public string NewPage { get; set; }
	}

	public delegate void WizardPageEventHandler(object sender, WizardPageEventArgs e);
}
