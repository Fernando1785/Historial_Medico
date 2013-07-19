<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="SistemaWebFundacionMedica.frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Fundacion Medica - Login</title>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<div class="main">
    	<div class="header"></div>
        <form id="Form1" method="post" runat="server">
        <input type="hidden" id="pendientes" runat="server" value="0" />    	
        <table width="900" border="0" cellspacing="0" cellpadding="0" style="margin-top:-20px;">

          <tr>
            <td width="100" valign="top"><img src="images/h1_registro.gif" alt="DashBoard de Atenci&oacute;n-Trabajo" /></td>
            <td width="800" valign="top">
           	  <h2>Registro Usuarios</h2>
           	  <br /><br /><br /><br /><br /><br /><br />
                <table class="verde" width="310" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td class="verde_1">Usuario:</td>
                    <td class="verde_2" align="right"><asp:TextBox id="user" runat="server" Width="250"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td class="verde_1" >Contraseña:</td>
                    <td class="verde_2" align="right"><asp:TextBox id="pass" runat="server" Width="250" TextMode="Password"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td colspan="2"></td>
                  </tr>
                  <tr align="center">
                    <td class="verde_2"  colspan="2"><asp:Button CssClass="boton"  id="BtnLog" runat="server" Text="Entrar"></asp:Button></td>
                  </tr>
                  <tr align="center">
                    <td class="verde_2"  colspan="2"><asp:Label id="AccesText" runat="server">Ingresese sus credenciales</asp:Label></td>
                  </tr>
                </table>                    
            </td>
          </tr>
        </table>
        </form>
    </div>
</body>
</html>
