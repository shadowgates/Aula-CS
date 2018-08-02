<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FaleConosco.aspx.cs" Inherits="FaleConosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <div class="title">
            <h1>Contato</h1>
            <h3>Envie suas duvidas, sugestões ou críticas.</h3>
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
                Mensagem<br />
                <asp:TextBox ID="Mensagem" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Enviar" />
                <br />
                <br />
            </div>
            <!-- MAPA DE LOCALIZAÇÃO -->
            <div class="col-2">
                <iframe src="https://www.google.com/maps/embed?pb" width="100%" height="100%" frameborder="0" style="border: 0" allowfullscreen></iframe>
            </div>
        </div>

    </div>

</asp:Content>

