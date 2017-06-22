using System;
using System.ComponentModel;

namespace AMT.Wizard.UI
{
	[DefaultEvent("SetActive")]
	public partial class WizardPage : System.Windows.Forms.UserControl
	{

        public Boolean ValidateResult { get; set; }
	    protected WizardPage()
		{
			InitializeComponent();
		}

	    [Category("Appearance")]
	    public string Caption { get; set; }

	    protected WizardSheet GetWizard()
		{
			WizardSheet wizard = (WizardSheet)ParentForm;
			return wizard;
		}

		protected void SetWizardButtons(WizardButtons buttons)
		{
			GetWizard().SetWizardButtons(buttons);
		}

		protected void EnableCancelButton(bool enableCancelButton)
		{
			GetWizard().EnableCancelButton(enableCancelButton);
		}

		protected void PressButton(WizardButtons buttons)
		{
			GetWizard().PressButton(buttons);
		}

		[Category("Wizard")]
		public event CancelEventHandler SetActive;
        public delegate Boolean Validation();

       [Category("Wizard")]
        public event Validation ValidatePageAction;

		public virtual void OnSetActive(CancelEventArgs e)
		{
            Focus();

			if (SetActive != null)
				SetActive(this, e);
		}

        public virtual Boolean  ValidatePage()
        {
            Boolean result = false;

            if (ValidatePageAction != null)
            {
                result = ValidatePageAction();
            }
            else
                result = true;

            return result;

        }


		[Category("Wizard")]
		public event WizardPageEventHandler WizardNext;

		public virtual void OnWizardNext(WizardPageEventArgs e)
		{
			if (WizardNext != null)
				WizardNext(this, e);
		}

		[Category("Wizard")]
		public event WizardPageEventHandler WizardBack;

		public virtual void OnWizardBack(WizardPageEventArgs e)
		{
			if (WizardBack != null)
				WizardBack(this, e);
		}

		[Category("Wizard")]
		public event CancelEventHandler WizardFinish;

		public virtual void OnWizardFinish(CancelEventArgs e)
		{
			if (WizardFinish != null)
				WizardFinish(this, e);
		}

		[Category("Wizard")]
		public event CancelEventHandler QueryCancel;

		public virtual void OnQueryCancel(CancelEventArgs e)
		{
			if (QueryCancel != null)
				QueryCancel(this, e);
		}
	}
}
