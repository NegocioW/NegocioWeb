<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaProveedor.aspx.cs" Inherits="Negocio.ConsultaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #Select1 {
            width: 127px;
        }
        #categoria {
            width: 154px;
        }
        #cmb_categoria {
            width: 125px;
        }
        #cmbcategoria {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>    <table style="width: 35%;">
        <tr>
            <td>
    <asp:Label ID="Label6" runat="server" Text="Codigo Proveedor"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="codigo"  runat="server" Height="16px" Width="105px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label1" runat="server" Text="Nit Cedula"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="nit"  runat="server" Height="16px" Width="105px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label2" runat="server" Text="Razon Social"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="nombre"  runat="server" Height="16px" Width="105px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label>
            </td>
            <td>

    <asp:TextBox ID="txtTelefono"  runat ="server" Height="16px" TextMode="Number" Width="105px"></asp:TextBox>
    
            </td>
        </tr>
        <tr>
            <td>

    <asp:Label ID="Label4" runat="server" Text="Nombre Contacto"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtContacto" runat="server" Width="105px" Height="19px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="txtDireccion" runat="server" Width="105px" Height="16px"></asp:TextBox>
            </td>
        </tr>
    </table>
  
    <br />
    <asp:Button ID="btn_modificarp" runat="server" OnClick="btn_modificarp_Click" Text="Modificar" />
    <br />
    
    <asp:GridView ID="dgProvedores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCancelingEdit="dgProvedores_RowCancelingEdit" OnRowEditing="dgProvedores_RowEditing" OnRowUpdating="dgProvedores_RowUpdating" OnSelectedIndexChanged="dgProvedores_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Cod_Proveedor" HeaderText="Codigo Proveedor" />
            <asp:BoundField DataField="Nit_Cedula" HeaderText="Nit Cedula" />
            <asp:BoundField DataField="Nombre_RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="NombContacto" HeaderText="Nombre Contacto" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
     </center>

    <br />
</asp:Content>