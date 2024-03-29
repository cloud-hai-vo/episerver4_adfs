<%@ Page language="c#" Codebehind="Search.aspx.cs" AutoEventWireup="false" Inherits="development.Templates.SearchPage" %>
<%@ Register TagPrefix="EPiServer" Namespace="EPiServer.WebControls" Assembly="EPiServer" %>
<%@ Register TagPrefix="development" TagName="DefaultFramework"	Src="~/templates/Frameworks/DefaultFramework.ascx"%>
<%@ Register TagPrefix="development" TagName="Search"	Src="~/templates/Units/Search.ascx"%>
<development:DefaultFramework ID="defaultframework" runat="server">
	<EPiServer:Content Region="addRegion" runat="server">
		<development:Search runat="server" />
	</EPiServer:Content>
</development:DefaultFramework>