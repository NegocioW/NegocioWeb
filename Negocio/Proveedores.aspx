<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="Negocio.Proveedores" %>
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
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
                <nav>
                    <ul id="menu">
                        <li><a  runat="server" href="ConsultaProveedor.aspx">Admin Proveedor</a></li>
                    </ul>
                </nav>
                <br />

                <center>
                <table style="width: 38% ; text-align:center;">
                    <tr>
                        <td>
    <asp:Label ID="Label1" runat="server" Text="Nit Cedula"></asp:Label>
                        </td>
                        <td>
    <asp:TextBox ID="nit"  runat="server" Height="18px" Width="105px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
    <asp:Label ID="Label2" runat="server" Text="Razon Social"></asp:Label>
                        </td>
                        <td class="auto-style1">
    <asp:TextBox ID="nombre"  runat="server" Height="16px" Width="108px"></asp:TextBox>
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

    <asp:TextBox ID="txtContacto" runat="server" Width="105px" Height="16px"></asp:TextBox>
    
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
    <asp:Label ID="Label5" runat="server" Text="Direccion"></asp:Label>
                        </td>
                        <td class="auto-style2">

    <asp:TextBox ID="txtDireccion" runat="server" Width="105px" Height="18px"></asp:TextBox>
    
                        </td>
                    </tr>
                </table>
                    </center>

    <br />
    <center>
    <asp:Button ID="btn_guardarp" runat="server" Text="Guardar"  OnClick="btn_guardarp_Click" style="position: relative" />
    </center>
    <br />
  
</asp:Content>