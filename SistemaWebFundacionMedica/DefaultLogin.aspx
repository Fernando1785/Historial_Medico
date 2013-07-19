<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultLogin.aspx.cs" Inherits="SistemaWebFundacionMedica.DefaultLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
     
</head>
<body>
  <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
    <br />
    <br />
      
        <asp:Table ID="Table3" runat="server" Width="800" Height="74">
        <asp:TableRow >
        <asp:TableCell HorizontalAlign="Left">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo-oms.jpg" 
                    Height="74px" Width="160px" />    
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>  
        
        
     <asp:Panel ID="Panel3" runat="server" BorderColor="#929496" BorderStyle="Solid" BorderWidth="1px" Height="345px" Width="800px">
  
      <table width ="270" align="center"   >
       
       <tr align ="left" class ="tamano1">
           <td class ="C_CELESTE">
               <asp:Label ID="Label2" runat="server" Text="Inicio de Sesión"></asp:Label>
           </td>
       </tr>
       </table> 
   
       <asp:Panel ID="Panel1" runat="server" BorderColor="#929496" BorderWidth="1px" 
            Height="170
            px" HorizontalAlign="Center" Width="270px" BackColor="#E1E1E1">            
      
       <table width ="250" height="100" align="center"  >
        <tr align="left">
         <td width ="100">
           <asp:Label ID="Label6" runat="server" Text="Email:" CssClass="C_AZUL"></asp:Label>
         </td>
        <td>
           &nbsp;</td>
       </tr>
       <tr align ="center">
       <td colspan ="2">
           <asp:TextBox ID="TextEmail" runat="server" MaxLength="50" Width="220"></asp:TextBox>           
       </td>
       </tr>
       <tr align ="left">
       <td colspan ="2">
          <asp:Label ID="Label3" runat="server" Text="Contraseña:" CssClass="C_AZUL"></asp:Label> 
       </td>
       </tr>
       <tr>
       <td colspan ="2">
          <asp:TextBox ID="TextContrasena" runat="server" MaxLength="20" TextMode="Password" Width="220"></asp:TextBox>                            
       </td>
       </tr>
       <tr height ="10" align = "right"  class="tamano4">
        <td colspan ="2">
           <asp:LinkButton ID="LinkOlvido" runat="server" CssClass="C_CELESTE" 
                onclientclick="redirect()">¿Ha olvidado su constraseña?</asp:LinkButton> 
       </td>
       </tr>
       
       <tr height="15">
       <td align="center" class="C_ROJO"  colspan ="2" height="15">
       <asp:UpdatePanel ID="UpdatePanel1" runat ="server">
       <ContentTemplate>
                  <asp:Panel runat="server" Visible="False" ID="panelMensaje" Height="15px">
                 
                  <asp:Label ID="lblMensaje" runat="server" Text="Label" CssClass="tamano4"></asp:Label>
                       </asp:Panel>
       </ContentTemplate>
        </asp:UpdatePanel>
             
       </td>
       </tr>
       
       <tr align ="left">
       <td colspan ="2">
         <asp:Button ID="BtnIngresar" runat="server" Text="Inicio de Sesión" 
               BackColor="#0078AE" ForeColor="white" BorderStyle="NotSet" 
               onclick="BtnIngresar_Click" />  
       </td>
       </tr>
       
       </table>
       
         </asp:Panel>  
            
     <asp:Panel ID="Panel2" runat="server" BorderColor="#929496" BorderWidth="1px" 
            Height="55px" HorizontalAlign="Center" Width="270px">          
        <table height ="50">
        <tr >
        <td align ="left" class="tamano4">
        <asp:Label ID="Label4" runat="server" Text="¿No tiene una cuenta en la Fundacion Medica?"></asp:Label>  <br />      
             <asp:LinkButton ID="LinkNuevoUsuario" runat="server" CssClass="C_CELESTE">Registre</asp:LinkButton>  sus datos en una cuenta gratuita de la Fundacion Medica. 
        </td>
        </tr>

        </table>
        
        
        
    <%--    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center" Width="250px" 
            BorderColor="#002E56" BorderStyle="Solid" BorderWidth="0px" 
            CellPadding="0" CellSpacing="0" Height="40"> 
      <asp:TableRow Height="10">
              <asp:TableCell HorizontalAlign="Left" Height="10">
                 <h4> <asp:Label ID="Label4" runat="server" Text="¿No tiene una cuenta en EP PETROECUADOR?"></asp:Label>  <br />      
             <asp:LinkButton ID="LinkNuevoUsuario" runat="server" CssClass="C_CELESTE">Registre</asp:LinkButton> sus datos en una cuenta gratuita de EP Petroecuador. </h4> 
              </asp:TableCell>
      </asp:TableRow>
      
      </asp:Table> --%>
      </asp:Panel> 
      <br />
      <hr width="95%" color="#929496" />
                  <asp:Label ID="Label5" runat="server" 
                Text="Este sitio ha sido creado para el uso exclusivo de usuarios autorizados de la Fundacion Medica. 
                El uso de este sitio está sujeto a los Avisos Legales, las Condiciones de Uso y la Declaración de Privacidad publicados en el sitio. 
                El acceso no autorizado o el incumplimiento de estas condiciones puede dar lugar a la cancelación de su permiso para utilizar el sitio y/o a las acciones legales pertinentes." 
                CssClass="tamano4" ForeColor="#929496" Width="95%"></asp:Label>
      
      </asp:Panel> 
         
         <table width ="800" height ="20" >
        <tr>
        <td align ="left" class ="tamano1">
                    <asp:Label ID="Label1" runat="server" Text="S-MIGETHC" CssClass="C_CELESTE"></asp:Label>
        </td>
        </tr>
         </table>
         
            
      
    </div>
    </form>
</body>
</html>
