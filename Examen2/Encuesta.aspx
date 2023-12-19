<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3_LuisMontoya.encuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">   
        <h1>Encuesta</h1>
</div>
<div class="container text-center">



</div>
<div class="container text-center">
        Nombre: <asp:TextBox ID="tnombre" class="form-control" runat="server"></asp:TextBox>
        Edad: <asp:TextBox ID="tedad" class="form-control" runat="server"></asp:TextBox>
        CorreoElectronico: <asp:TextBox ID="tcorreo" class="form-control" runat="server"></asp:TextBox>
        <div class="mb-3">
        <label for="exampleInputPassword1" class="form-label">ID Usuario</label>
        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>
        </div>
</div>

<div class="container text-center">
<br />
<asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="ButtonAgregarE_Click" />


</div>
</asp:Content>