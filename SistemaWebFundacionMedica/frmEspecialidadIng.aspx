<%@ Page Language="C#" MasterPageFile="~/frmMenuPrincipal.Master" AutoEventWireup="true" CodeBehind="frmEspecialidadIng.aspx.cs" Inherits="SistemaWebFundacionMedica.frmEspecialidadIng" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  <div align="center"> 
        <table>
        <tr>
        <td>
           
             <table>
        <tr>
        <td>
             <asp:GridView ID="GridView1" runat="server" style="margin-top: 0px"
                AutoGenerateColumns="False"  datakeynames="ID_ESPECIALIDAD"  
                onselectedindexchanged="GridView1_SelectedIndexChanged"
                onrowcommand="GridView1_RowCommand" 
                onrowdatabound="GridView1_RowDataBound" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Image"
                        SelectImageUrl="~/iconos/PNGs/trash_16.png"/>
                   <asp:BoundField DataField="ID_ESPECIALIDAD" HeaderText="ID" Visible="false" />
                   <asp:BoundField DataField="NOMBRE_ESPECIALIDAD" HeaderText="Nombre" />
                </Columns>
             </asp:GridView>
            
        </td>
        </tr>
        </table>
        
     <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
        <table border="1" id="tblDatos" visible="false" runat="server">
        
        <tr>
     
         <td>
                   
            <asp:Label ID="lblNombreEspe" runat="server" Text="Ingrese Nombre Especialidad"></asp:Label>
         </td>
         
         <td>
            <asp:TextBox ID="txtEspe" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiere" runat="server" 
                ControlToValidate="txtEspe" ErrorMessage="Ingrese el Nombre"></asp:RequiredFieldValidator>
          </td>
          
        </tr>
        </table>
        
        <table border="1">
        <tr>
        <td>
        
        <center>
       <table id="tblErrorm" runat="server" visible="false">
       <tr>
       <td>
           <asp:Label ID="lblErrorm" runat="server" Text="Label"></asp:Label>
       </td>
       </tr>
       </table>
       </center>
        
        
       <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" onclick="btnNuevo_Click" /> 
         <asp:Button ID="btnModificar" runat="server"
                Text="Modificar" onclick="btnModificar_Click" />
      <asp:Button ID="btnIngreso" runat="server" onclick="btnIngreso_Click" 
                Text="Guardar" />     
      
        <asp:Button ID="btnEliminar" runat="server"
                Text="Eliminar" onclick="btnEliminar_Click" />
        </td>
        </tr>
        </table>       
                
        

        
        </td>
        </tr>
        </table>
        
     
                
             </div>   
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
