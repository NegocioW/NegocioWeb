<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="Negocio.Compras" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        function confirmar() {
            var seleccion = confirm("acepta el mensaje ?");

            if (seleccion)
                alert("se acepto el mensaje");
            else
                alert("NO se acepto el mensaje");

         
            return seleccion;
        }



</script>

<script>
    $(document).ready(function () {
        $("input[name=txtCantidad]").change(function () {
            alert($('input[name=txtCantidad]').val());
        });
      
    });
</script>
         
        <asp:Label ID="Label1" runat="server" Text="Proveedor"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtProveedor" runat="server" onKeyUp="this.value=this.value.toUpperCase()"></asp:TextBox >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BuscarP" runat="server" Text="Buscar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Producto"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_buscar" runat="server" Text="Buscar" />
        ,<asp:Button ID="btn_registarP" runat="server" Text="Registrar" Width="94px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="Cantidad"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCantidad" runat="server" style="margin-left: 25px" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="false"></asp:TextBox>
    </p>
        

    <center>

    <asp:GridView ID="dgCompra" runat="server" style="margin-left: 0px; margin-right: 0px" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="187px" Width="445px">
        <Columns>
            <asp:BoundField DataField="NombContacto" HeaderText="Proveedor" />
            <asp:BoundField DataField="Nombre_Prod" HeaderText="Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio_Compra" HeaderText="Precio Compra" />
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
        </center>
    <p>
        &nbsp;<p>
            <div align="center">
                <asp:TextBox ID="textbox1"  runat="server" ></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Total"></asp:Label>
         
        <asp:TextBox ID="txtTotal" runat="server" Height="22px"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                 <asp:DropDownList ID="ultimoid" runat="server" Height="18px" Width="161px">
                    </asp:DropDownList>
        <asp:Button ID="btn_comprar" runat="server" Text="Registrar Compra" OnClick="Button3_Click" OnClientClick="return confirm('yes ?');" />
                

                <br />
                </div>
        <center>
        </center>
            <style type="text/css">
    .CajaDialogo
    {
        background-color: white;
        padding: 0px;
        width: 600px;
        font-weight: bold;
        font-style: italic;
    }
    .CajaDialogo div
    {
        margin: 5px;
        text-align: center;
    }
                </style>
&nbsp;<asp:Panel ID="pnlSeleccionarDatos" runat="server" CssClass="CajaDialogo">
   
</asp:Panel>
    <cc1:ModalPopupExtender ID="mpeSeleccion" runat="server" 
    TargetControlID="btn_registarP"
    PopupControlID="pnlSeleccionarDatos" 
    DropShadow="False"
    BackgroundCssClass="FondoAplicacion" />
    &nbsp;</p>
    <p>
    </p>
      
&nbsp;<asp:Panel ID="Panel1" runat="server" CssClass="CajaDialogo">
    <div style="padding: 10px; background-color: #0033CC; color: #FFFFFF;" aria-checked="true">
        Consultar Producto</div>
    <div>
        <asp:GridView ID="dgProductos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="478px"  AutoGenerateColumns="False" OnSelectedIndexChanged="dgProductos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="Cod_Producto" HeaderText="Codigo Producto" SortExpression="Cod_Producto" />
                <asp:BoundField DataField="Nombre_Prod" HeaderText="Nombre Producto" SortExpression="Nombre_Prod" />
                <asp:BoundField DataField="Precio_Venta" HeaderText="Precio" SortExpression="Precio_Venta" />
                <asp:BoundField DataField="Precio_Compra" HeaderText="Precio Compra" />
                <asp:TemplateField HeaderText="Categoria">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Categoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                   
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    <asp:HiddenField ID="HiddenField1" runat="server" />
        
    </div>
    <div>
        <asp:Button ID="btnAceptarp" runat="server" Text="Cerrar" />
    </div>
</asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" 
    TargetControlID="btn_buscar"
    PopupControlID="Panel1" 
    DropShadow="False"
    BackgroundCssClass="FondoAplicacion" />
    &nbsp;</p>
    <p>
    <p>


&nbsp;<asp:Panel ID="Panel2" runat="server" CssClass="CajaDialogo">
    <div style="padding: 10px; background-color: #0033CC; color: #FFFFFF;">
        Consultar Proveedores</div>
    <div>
         <asp:GridView ID="dgProvedores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="dgProvedores_SelectedIndexChanged"> 
            <Columns>
            <asp:BoundField DataField="Cod_Proveedor" HeaderText="Codigo Proveedor" />
            <asp:BoundField DataField="Nit_Cedula" HeaderText="Nit Cedula" />
            <asp:BoundField DataField="Nombre_RazonSocial" HeaderText="Razon Social" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="NombContacto" HeaderText="Nombre Contacto" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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
    <asp:HiddenField ID="HiddenField2" runat="server" />
    </div>
    <div>
        <asp:Button ID="btnAceptarPr" runat="server" Text="Cerrar" />
    </div>
</asp:Panel>
    <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" 
    TargetControlID="BuscarP"
    PopupControlID="Panel2" 
    DropShadow="True"
    BackgroundCssClass="FondoAplicacion" />
    &nbsp;</p>

    
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
       <button type="button" class="btn btn-primary" data-toggle="modal"  data-target="#exampleModal" data-whatever="@twbootstrap">+</button>
    </asp:Content>
