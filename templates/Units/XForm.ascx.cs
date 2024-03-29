/*
Copyright � 1997-2004 ElektroPost Stockholm AB. All Rights Reserved.

This code may only be used according to the EPiServer License Agreement.
The use of this code outside the EPiServer environment, in whole or in
parts, is forbidded without prior written permission from ElektroPost
Stockholm AB.

EPiServer is a registered trademark of ElektroPost Stockholm AB. For
more information see http://www.episerver.com/license or request a
copy of the EPiServer License Agreement by sending an email to info@ep.se
*/
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.Util;
using EPiServer.XForms;
using EPiServer.XForms.WebControls;
using EPiServer.WebControls;
using XForm = EPiServer.XForms.XForm;


namespace development.Templates.Units
{
	/// <summary>
	///	Summary description for Form.
	/// </summary>
	public abstract class XForm : UserControlBase
	{
		protected Panel				StatisticsPanel, FormPanel;
		protected Literal			NumberOfVotes,PostedMessage;
		protected LinkButton		Switch;
		protected Property			XFormProperty;
		protected XFormStatistics	Statistics;
		protected XFormControl	FormControl;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			Switch.Visible = EnableStatistics;
		}

		protected void SwitchView(object sender, System.EventArgs e)
		{
			if (StatisticsPanel.Visible)
			{
				StatisticsPanel.Visible = false;
				Switch.Text = Translate("/templates/form/showstat");
			}
			else
			{
				Statistics.DataBind();
				NumberOfVotes.Text = String.Format(
					Translate( "/templates/form/numberofvotes" ), 
					Statistics.NumberOfVotes );

				StatisticsPanel.Visible = true;
				Switch.Text = Translate( "/templates/form/showform" );
			}
			FormPanel.Visible = !StatisticsPanel.Visible;
		}

		private void Page_PreRender(object sender, System.EventArgs e)
		{
			PropertyXForm form = XFormProperty.InnerProperty as PropertyXForm;

			if (form == null)
				return;

			if(form.IsPosted)
			{
				PostedMessage.Visible	= true;
				PostedMessage.Text = Translate("/templates/form/postedmessage");

				if(EnableStatistics)
					SwitchView(null, null);
			}
			else
			{
				PostedMessage.Visible = false;
			}
		}

		protected bool EnableStatistics
		{
			get
			{
				return CurrentPage["EnableStatistics"] == null 
					? false 
					: (bool)CurrentPage["EnableStatistics"];
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
		}
		#endregion
	}
}
