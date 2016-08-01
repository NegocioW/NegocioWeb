<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Negocio.Categorias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 179px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

  
    <center>
     <table style="width: 35%;">
         <tr>
             <td>&nbsp;</td>
             <td>
  
     <asp:Label ID="Label5" runat="server" Text="Codigo Categoria"></asp:Label>
 
             </td>
             <td class="auto-style1">
 
    <asp:TextBox ID="txtcodigo_cat" runat="server"></asp:TextBox>
   
             </td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>
   
    <asp:Label ID="Label6" runat="server" Text="Descripcion"></asp:Label>

             </td>
             <td class="auto-style1">

    <asp:TextBox ID="txtNombreCat" runat="server"></asp:TextBox>
                 <asp:Button ID="BTNBUSCAR" Text="BuscarP"  runat="server" OnClick="BTNBUSCAR_Click"/>
             </td>
         </tr>
     </table>
    </center>
    <br />
    <table class="OptionsTable BottomMargin" style="float: left;">
        <tr>
            <td>
               
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
               
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
               
            </td>
            <td>
         
            </td>
        </tr>
        <tr>
            <td>
        
            </td>
            <td>

            </td>
        </tr>
    </table>

    <b class="Clear"></b>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_inventarioConnectionString %>" SelectCommand="SELECT [Cod_Categoria], [Descripcion_Categ] FROM [tb_Categorias]"></asp:SqlDataSource>

        <asp:GridView ID="dgCategorias" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="74px" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="631px" OnRowEditing="dgCategorias_RowEditing" style="margin-left: 0px" OnRowCancelingEdit="dgCategorias_RowCancelingEdit" OnRowUpdating="dgCategorias_RowUpdating" AutoGenerateColumns="false">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Var_CodiCat" HeaderText="cODIGO"/>
            <asp:BoundField DataField="Var_NombreCat" HeaderText="Nombre"/>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
            <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    <center>
    <asp:Button ID="btn_guardarc" runat="server" OnClick="btn_guardarc_Click" Text="Guardar" />
       
        <asp:Button ID="btn_modificarc" runat="server" OnClick="btn_modificarc_Click" Text="Modificar" />
   </center>
    </asp:Content>
