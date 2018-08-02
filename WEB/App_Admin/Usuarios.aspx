<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="App_Adm_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:HiddenField ID="UsuarioId" runat="server" />

    <div class="content-wrapper">
        <div class="title">
            <h1>Usuarios</h1>
            <h3>Cadastro de usuários do sistema</h3>
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
                Email<br />
                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                <br />
                <br />
                Senha<br />
                <asp:TextBox ID="Senha" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Salvar" OnClick="Salvar_Click" runat="server" Text="Salvar" />
                <asp:Button ID="Excluir" OnClick="Excluir_Click" runat="server" Enabled="false" Text="Excluir" />
                <br />
                <br />
            </div>
            <!-- GRID -->
            <div class="col-2">
                <asp:GridView ID="Usuarios" CellPadding="8" HeaderStyle-BackColor="#dfdfdf" Font-Size="12px" Width="100%" AutoGenerateColumns="true"  AutoGenerateSelectButton="true" OnSelectedIndexChanged="Usuarios_SelectedIndexChanged"  runat="server"></asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

