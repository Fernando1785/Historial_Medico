<%@ Page Language="C#" MasterPageFile="~/frmMenuPrincipal.Master" AutoEventWireup="true" CodeBehind="frmPaciente.aspx.cs" Inherits="SistemaWebFundacionMedica.frmPaciente" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
       <%--tabla general--%>
       <table>
       <tr>
       <td>
       
       <%--seccion para busqueda quiero ponerle a la drecha ri--%>
        
        
        <table>
       <tr align="right">
       <td align="right">
        <asp:Button ID="btnActivaBusquedad" runat="server" Text="Busqueda" 
               onclick="btnActivaBusquedad_Click" CausesValidation="False"/>
       </td>
       <%--siempre que copies un boton debes borrar el metodo que tenga el onclick
       para que se cree el nuevo cuadno das doble click el causesValidation es para que
       puedas dar click en el boton sin que se ejecuten los validates de las cajas de texto
       mira lo que pasa si le pongo true--%>
        <td align="right">
        <asp:Button ID="btnLimpiaBusqueda" runat="server" Text="Limpiar Busqueda"  
                CausesValidation="False" onclick="btnLimpiaBusqueda_Click"/>
       </td>
       </tr>
       </table>
         
         <table border="1" id="tblBusqueda" runat="server" visible="false">
       <tr>
       <td>
           <asp:Label ID="Label10" runat="server" Text="Busqueda por Cedula"></asp:Label>
       </td>
       <td>
           <asp:TextBox ID="txtBusquedaCedula" runat="server"></asp:TextBox>
       </td>
       <td>
       <asp:Button ID="btnBuscaCedula" runat="server" Text="Ir" 
               onclick="btnBuscaCedula_Click"/>
       </td>
       </tr>
        <tr>
       <td>
           <asp:Label ID="Label11" runat="server" Text="Busqueda por Apellido"></asp:Label>
       </td>
       <td>
           <asp:TextBox ID="txtBusquedaApellido" runat="server"></asp:TextBox>
       </td>
        <td>
       <asp:Button ID="btnBuscaApellido" runat="server" Text="Ir" 
                onclick="btnBuscaApellido_Click"/>
       </td>
       </tr>
       </table>
       
       
       
       <%--tabla para la grilla con crtl+k+c se comenta--%>
       <table>
       <tr>
       <td>
            <asp:GridView ID="gridPaciente" runat="server"
                AutoGenerateColumns="False"  datakeynames="ID_PACIENTE,ID_SEXO"  
                onselectedindexchanged="gridPaciente_SelectedIndexChanged"
                onrowcommand="gridPaciente_RowCommand" 
                onrowdatabound="gridPaciente_RowDataBound" AllowPaging="True" 
                onpageindexchanging="gridPaciente_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Image"
                        SelectImageUrl="~/iconos/PNGs/trash_16.png"/>
                   <asp:BoundField DataField="ID_PACIENTE" HeaderText="ID" Visible="false" />
                  <asp:BoundField DataField="CEDULA_PACIENTE" HeaderText="Cedula" />
                   <asp:BoundField DataField="NOMBRE_PACIENTE" HeaderText="Nombre" />
                   <asp:BoundField DataField="APELLIDO_PACIENTE" HeaderText="Apellido" />
                   <asp:BoundField DataField="FECHA_NACIMIENTO_PACIENTE" HeaderText="FechaNacimiento" />
                   <asp:BoundField DataField="EDAD_PACIENTE" HeaderText="Edad" />
                   <asp:BoundField DataField="nombre_sexo" HeaderText="Sexo" />
                   <asp:BoundField DataField="ID_SEXO" HeaderText="Sexo" Visible="false"/>
                   <asp:BoundField DataField="DIRECCION_PACIENTE" HeaderText="Dirección" />
                   <asp:BoundField DataField="TELEFONO_PACIENTE" HeaderText="Teléfono" />
                   <asp:BoundField DataField="CELULAR_PACIENTE" HeaderText="Celular" />
                </Columns>
           </asp:GridView>
       </td>
       </tr>
       </table>
       
       
       <%--tabla para las cajas de texto--%>
       <table border="1" id="tblDatos" runat="server" visible="false">
       <%--para ocultar el id no sdeibe verse--%>
       <tr visible="false">
       <td><asp:Label ID="Label20" runat="server" Text="Paciente"></asp:Label></td>
       <td><asp:TextBox ID="txtpaciente" runat="server"></asp:TextBox></td>
       </tr>
     
       <tr>
       <td><asp:Label ID="Label1" runat="server" Text="Cedula"></asp:Label></td>
       <td><asp:TextBox ID="txtCedulap" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
           ErrorMessage="Ingrese Cedula" ControlToValidate="txtCedulap"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
          <tr>
       <td><asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label></td>
       <td><asp:TextBox ID="txtNombrep" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
           ErrorMessage="Ingrese Nombre" ControlToValidate="txtNombrep"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
          <tr>
       <td><asp:Label ID="Label3" runat="server" Text="Apellido"></asp:Label></td>
       <td><asp:TextBox ID="txtApellidop" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
           ErrorMessage="Ingresse Apellido" ControlToValidate="txtApellidop"></asp:RequiredFieldValidator>
       </td>
       </tr>
       <tr>
        <td>
        
            <asp:Label ID="Label9" runat="server" Text="Fecha Nacimiento"></asp:Label></td>
        <td> 
            <asp:TextBox ID="txtFechaPaciente" runat="server"></asp:TextBox>   
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="txtFechaPaciente" ErrorMessage="Debe Seleccionar Fecha"></asp:RequiredFieldValidator>
        </td>
        
      </tr>
    
          <tr>
       <td><asp:Label ID="Label4" runat="server" Text="Edad"></asp:Label></td>
       <td><asp:TextBox ID="txtEdadp" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="*Seleccione Edad" ControlToValidate="txtedadp"></asp:RequiredFieldValidator>
       </td>
       </tr>
           
          <tr>
       <td><asp:Label ID="Label5" runat="server" Text="Sexo"></asp:Label></td>
       <td>
       <asp:DropDownList ID="cbxSexop" runat="server">
           </asp:DropDownList>
       </td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
           ErrorMessage="Seleccione Sexo" ControlToValidate="cbxSexop"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
       
          <tr>
       <td><asp:Label ID="Label6" runat="server" Text="Direccion"></asp:Label></td>
       <td><asp:TextBox ID="txtDireccionp" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
           ErrorMessage="Ingrese Direccion" ControlToValidate="txtDireccionp"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
            <tr>
       <td><asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label></td>
       <td><asp:TextBox ID="txtTelefonop" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
           ErrorMessage="Ingrese telefono" ControlToValidate="txtTelefonop"></asp:RequiredFieldValidator>
       </td>
       </tr>
       
           <tr>
       <td><asp:Label ID="Label7" runat="server" Text="Celular"></asp:Label></td>
       <td><asp:TextBox ID="txtCelularp" runat="server"></asp:TextBox></td>
       <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
           ErrorMessage="Ingrese Celular" ControlToValidate="txtCelularp"></asp:RequiredFieldValidator>
       </td>
       </tr>
       </table>
       
       <center>
       <table id="tblError" runat="server" visible="false">
       <tr>
       <td>
           <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
       </td>
       </tr>
       </table>
       </center>
       
       
       <%--tabla para los botones--%>
         <table>
       <tr>
       <td>
         <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" onclick="btnNuevo_Click" />
       </td>
        <td>
         <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                onclick="btnModificar_Click" />
       </td>
        <td>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
           onclick="btnGuardar_Click"/>
       </td>
        <td>
         <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                onclick="btnEliminar_Click" />
       </td>
       
       </tr>
       </table>
       
       
       
       </td>
       </tr>
       </table>
       
       
       
             
        
          
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
