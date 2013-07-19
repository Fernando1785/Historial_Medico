<%@ Page Title="" Language="C#" MasterPageFile="~/frmMenuPrincipal.Master" AutoEventWireup="true" CodeBehind="frmMedico.aspx.cs" Inherits="SistemaWebFundacionMedica.frmMedico" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    var txtFechaM = '<%=txtFechaMedico.ClientID%>';
    var txtEdadM = '<%=txtEdadm.ClientID%>';
    var txtCedulam = '<%=txtCedulam.ClientID%>';
</script>
 <ajaxToolkit:ToolkitScriptManager runat="Server" 
 EnablePartialRendering="true" ID="ToolkitScriptManager1" />
  
    <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
      
 <%--<div align="center">   --%>
          <center>
      <%--tabla general--%>
    <table>
    <tr>
    <td>
 <%--seccion para busqueda quiero ponerle a la drecha ri--%>
        
        <div class="derecha"> 
          <asp:Button ID="btnActivaBusquedadm" runat="server" Text="Busqueda" 
              CausesValidation="False" onclick="btnActivaBusquedadm_Click"  CssClass="btn"/>    
      <asp:Button ID="btnLimpiaBusquedam" runat="server" Text="Limpiar Busqueda"  
                CausesValidation="False" onclick="btnLimpiaBusquedam_Click" CssClass="btn"/>
     
     <table border="1" id="tblBusquedam" runat="server" visible="false">
      <tr>
      <td>
           <asp:Label ID="Label14" runat="server" Text="Busqueda por Cedula"></asp:Label>
      </td>
      <td>
           <asp:TextBox ID="txtBusquedaCedulam" runat="server"></asp:TextBox>
      </td>
      <td>
      <asp:Button ID="btnBuscaCedulam" runat="server" Text="Ir" 
              onclick="btnBuscaCedulam_Click" />
      </td>
      </tr>
      <tr>
      <td>
           <asp:Label ID="Label15" runat="server" Text="Busqueda por Apellido"></asp:Label>
      </td>
      <td>
           <asp:TextBox ID="txtBusquedaApellidom" runat="server"></asp:TextBox>
      </td>
      <td>
      <asp:Button ID="btnBuscaApellidom" runat="server" Text="Ir" 
              onclick="btnBuscaApellidom_Click" />
      </td>
      </tr>
      </table>
      </div>
         
         
      
       
       
     
       <%--tabla para la grilla con crtl+k+c se comenta--%>
    <table>
    <tr>
    <td>
        <asp:GridView ID="gridMedico" runat="server"
                AutoGenerateColumns="False"  datakeynames="ID_MEDICO,ID_ESPECIALIDAD,ID_SEXO"  
                onselectedindexchanged="gridMedico_SelectedIndexChanged"
                onrowcommand="gridMedico_RowCommand" 
                onrowdatabound="gridMedico_RowDataBound" AllowPaging="True" 
                onpageindexchanging="gridMedico_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Image"
                        SelectImageUrl="../iconos/bmp/16x16/Yes.bmp"/>
                   <asp:BoundField DataField="ID_MEDICO" HeaderText="ID" Visible="false" />
                   <asp:BoundField DataField="ID_ESPECIALIDAD" HeaderText="idespe" Visible="false" />
                   <asp:BoundField DataField="NOMBRE_ESPECIALIDAD" HeaderText="Especialidad" />
                   <asp:BoundField DataField="CEDULA_MEDICO" HeaderText="Cedula" />
                   <asp:BoundField DataField="NOMBRE_MEDICO" HeaderText="Nombre" />
                   <asp:BoundField DataField="APELLIDO_MEDICO" HeaderText="Apellido" />
                   <asp:BoundField DataField="FECHA_NACIMIENTO_MEDICO" HeaderText="FechaNacimiento" />
                   <asp:BoundField DataField="EDAD_MEDICO" HeaderText="Edad" />
                   <asp:BoundField DataField="nombre_sexo" HeaderText="Sexo" />
                   <asp:BoundField DataField="ID_SEXO" HeaderText="Sexo" Visible="false"/>
                   <asp:BoundField DataField="DIRECCION_MEDICO" HeaderText="Dirección" />
                   <asp:BoundField DataField="TELEFONO_MEDICO" HeaderText="Teléfono" />
                   <asp:BoundField DataField="CELULAR_MEDICO" HeaderText="Celular" />
                </Columns>
        </asp:GridView>
    </td>
    </tr>
    </table>
    
    <%--tabla para las cajas de texto--%>
    <table border="1" id="tblDatos" visible="false" runat="server">
    <tr visible ="false">
    <td><asp:Label ID="Label1" runat="server" Text="Medico"></asp:Label></td>
    <td><asp:TextBox ID="txtmedicom" runat="server"></asp:TextBox></td>
  
    </tr>
    <tr>
    <td style="height: 28px">
        <asp:Label ID="Label2" runat="server" Text="Especialidad"></asp:Label></td>
    <td align="left">
         &nbsp; &nbsp;<asp:DropDownList ID="cbxespecialidadm" runat="server">
        </asp:DropDownList>
     
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="*Seleccione especialidad" ControlToValidate="cbxespecialidadm"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Cedula"></asp:Label></td>
    <td>
          <asp:TextBox ID="txtCedulam" runat="server" MaxLength="10" Onchange="validar_dato();"></asp:TextBox>
                <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txtCedulam"
           FilterType="Numbers" />    
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="*Ingrese Cedula" ControlToValidate="txtCedulam"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNombrem" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender
                        ID="FilteredTextBoxExtender2"
                        runat="server" 
                        TargetControlID="txtNombrem"
                        FilterType="LowercaseLetters" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="*Ingrese Nombre" ControlToValidate="txtNombrem"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Apellido"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtApellidom" runat="server"></asp:TextBox>
          <ajaxToolkit:FilteredTextBoxExtender
                        ID="FilteredTextBoxExtender3"
                        runat="server" 
                        TargetControlID="txtApellidom"
                        FilterType="LowercaseLetters" />   
     </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="*Ingrese Apellido" ControlToValidate="txtApellidom"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Fecha Nacimiento"></asp:Label></td>
    <td>
         <asp:TextBox ID="txtFechaMedico" runat="server" Width="120" ReadOnly="true"> </asp:TextBox>
          <asp:ImageButton runat="Server" ID="ImageFecha" ImageUrl="../images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" /><br />
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFechaMedico" 
            PopupButtonID="ImageFecha" OnClientHidden ="calculaEdad" Animated="true" 
            Format="dd/MM/yyyy"/>
        <%-- <asp:ImageButton runat="Server" ID="Image1" ImageUrl="../images/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />     --%>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
            ErrorMessage="Seleccione Fecha" ControlToValidate="txtFechaMedico"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Edad"></asp:Label></td>
    <td align="left">
         &nbsp; &nbsp;<asp:TextBox ID="txtEdadm" runat="server" MaxLength="2" Width="50" ReadOnly="true"></asp:TextBox></td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="*Seleccione Edad" ControlToValidate="txtedadm"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label8" runat="server" Text="Sexo"></asp:Label></td>
    <td align="left">
         &nbsp; &nbsp;<asp:DropDownList ID="cbxSexom" runat="server">
        </asp:DropDownList>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ErrorMessage="*Seleccione el sexo" ControlToValidate="cbxSexom"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label9" runat="server" Text="Direccion"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtDireccionm" runat="server" MaxLength="100"></asp:TextBox></td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ErrorMessage="Ingrese la direccion" ControlToValidate="txtdireccionm"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label10" runat="server" Text="Telefono"></asp:Label></td>
    <td>
       
        <asp:TextBox ID="txtTelefonom" runat="server" MaxLength="10" ></asp:TextBox>
              <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender4"
           runat="server"
           TargetControlID="txtTelefonom"
           FilterType="Numbers" /> 
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
            ErrorMessage="Ingrese telefono" ControlToValidate="txttelefonom"></asp:RequiredFieldValidator></td>     
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label11" runat="server" Text="Celular"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtCelularm" runat="server" MaxLength="10"></asp:TextBox>
          <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender5"
           runat="server"
           TargetControlID="txtCelularm"
           FilterType="Numbers" /> 
        </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
            ErrorMessage="Ingrese Cedula" ControlToValidate="txtcelularm"></asp:RequiredFieldValidator></td>
    </tr>
    </table>
    
     <center>
       <table id="tblErrorm" runat="server" visible="false">
       <tr>
       <td>
           <asp:Label ID="lblErrorm" runat="server" Text="Label"></asp:Label>
       </td>
       </tr>
       </table>
       </center>
       
    
    
    <%--tabla para botones--%>
     <br /><br />
     
    <table>
    <tr>
       <td>
         <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" onclick="btnNuevo_Click" CssClass="boton"/>
       </td>
        <td>
         <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                onclick="btnModificar_Click" style="height: 26px" CssClass="boton"/>
           <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonEliminar" runat="server" 
                        TargetControlID="btnModificar"
                        OnClientCancel="cancelClick"
                        DisplayModalPopupID="ModalPopupExtenderModifica" />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderModifica" runat="server" 
                                 TargetControlID="btnModificar" PopupControlID="PanelModifica" OkControlID="btnOkM" 
                                 CancelControlID="btnCanM" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="PanelModifica" runat="server" style="display:none; width:250px; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;">
                          Confirma que desea Modificar el Registro?
                        <br />
                        <div style="text-align:center;">
                            <asp:Button ID="btnOkM" runat="server" Text="OK" />
                            <asp:Button ID="btnCanM" runat="server" Text="Cancel" />
                        </div>
                    </asp:Panel>
             
                    
       </td>
        <td>
          <asp:Button ID="btnGuardar" runat="server" Text="Guardar" onclick="btnGuardar_Click" CssClass="boton"/>
       </td>
        <td>
         <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" onclick="btnEliminar_Click" CssClass="boton"/><br />
             <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="btnEliminar"
                        OnClientCancel="cancelClick"
                        DisplayModalPopupID="ModalPopupExtender1" />
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                 TargetControlID="btnEliminar" PopupControlID="PNL" 
                                 OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
                    <asp:Panel ID="PNL" runat="server" style="display:none; width:250px; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;">
                        Confirma que desea Eliminar el Registro?
                        <br />
                        <div style="text-align:center;">
                            <asp:Button ID="ButtonOk" runat="server" Text="OK" />
                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                        </div>
                    </asp:Panel>   
                
             </td>
       </tr>
    </table>
    
        </td>
        </tr>
    </table>
 <%--</div>--%>
    </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
