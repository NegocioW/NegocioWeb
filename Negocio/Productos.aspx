<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Negocio.Productos" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



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
    <script  type="text/javascript">
        function valor() {
            <%--var ddl = document.getElementById("<%=cmbcategoria.ClientID%>");
            var SelVal = ddl.options[ddl.selectedIndex].index;--%>
            var ciudad = document.getElementById('<%= cmbcategoria.ClientID %>').options[document.getElementById('<%= cmbcategoria.ClientID %>').selectedIndex].text;
            var vsede = ciudad.split('x');
            var valors = vsede[1];
        }
    </script>

    <nav>
        <ul id="menu">
            <li><a runat="server" href="Busqueda.aspx">Admin Producto</a></li>
        </ul>
    </nav>
    <center>
                <table style="width: 38% ; text-align:center;">
                    <tr>
                        <td>
    <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
                        </td>
                        <td>
    <asp:TextBox ID="codigo"  runat="server" Height="16px" Width="105px"  ></asp:TextBox>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator" runat="server"
            ControlToValidate="codigo"
            ErrorMessage="Ingrese código"
            Display="Static"
            ForeColor="red"
            align="right"
            Width="100%">
        </asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        </td>
                        <td class="auto-style1">
    <asp:TextBox ID="nombre"  runat="server" Height="16px" Width="105px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
    <asp:Label ID="Label3" runat="server" Text="Precio Venta"></asp:Label>
                        </td>
                        <td>

    <asp:TextBox ID="precio"  runat ="server" Height="16px" TextMode="Number" Width="105px"></asp:TextBox>
    
                        </td>
                    </tr>
                    <tr>
                        <td>

    <asp:Label ID="Label4" runat="server" Text="Precio Compra"></asp:Label>
                        </td>
                        <td>

    <asp:TextBox ID="txtprecioC"  runat ="server" Height="16px" TextMode="Number" Width="105px"></asp:TextBox>
    
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
    <asp:Label ID="Label9" runat="server" Text="Categoria"></asp:Label>
                        </td>
                        <td class="auto-style2">

    <asp:DropDownList ID="cmbcategoria"  runat="server" Height="16px" Width="105px" onchange="valor()">
    </asp:DropDownList>
           
    
                        </td>
                    </tr>
                </table>
                    </center>
    <br />
    <center>
    <asp:Button ID="btn_guardarp" runat="server" Text="Guardar"  OnClick="btn_guardarp_Click"/>
      </center>
    <br />

</asp:Content>


<%--<asp:Content ID="Content4" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript">
      
    function ClientOnChange() {
        if (typeof (Page_Validators) == "undefined")
            return;
        document.all["lblOutput"].innerText = Page_IsValid ? "Page is Valid!" : "Some of the required fields are empty";
    }
    </script>
</asp:Content>
--%>




