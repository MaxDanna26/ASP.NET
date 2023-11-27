<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Piloto._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <main>
                <h1>Juego de Ahorcado</h1>
                <asp:Label ID="lblPalabra" runat="server" Text=""></asp:Label>
                <br />

                <asp:TextBox ID="txtLetra" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnIntentar" runat="server" Text="Intentar" OnClick="btnIntentar_Click"/>
                <asp:Image ID="Image1" runat="server" ImageUrl="/IMG/1.png"/>
                <br />
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblLetrasWrong" runat="server" Text=""></asp:Label>
            </main>

</asp:Content>
