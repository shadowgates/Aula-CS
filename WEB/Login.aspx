<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="content-wrapper">
        <div class="title">
            <h1>Entrar</h1>
        </div>
        <div class="container-col">
            <!-- FORMULÁRIO -->
            <div class="col-2 box-border">
                <br />
                <br />
                <asp:Label ID="MsgErro" runat="server"></asp:Label>
                <br />
                <br />
                Nome<br />
                <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
                <br />
                <br />
                Senha<br />
                <asp:TextBox ID="Senha" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Entrar" OnClick="Entrar_Click" runat="server" Text="Entrar" />
                <br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>

