<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Web.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
<div class="container">
    <h1 class="panel-heading">JOGADORES DE FUTEBOL</h1>
      <div >Cadastro</div>
 
    <asp:Label ID="Label4" runat="server" Text="Nome"></asp:Label>
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br /><br />

 <asp:Label ID="Label5" runat="server" Text="Camisa"></asp:Label>
<asp:TextBox ID="txtNumeroCamisa" runat="server"></asp:TextBox><br /><br />

    <asp:Label ID="Label1" runat="server" Text="Posição"></asp:Label>
    <asp:DropDownList ID="ddlPosicao" runat="server"></asp:DropDownList><br /><br />
       
    <asp:Label ID="Label2" runat="server" Text="Seleção"></asp:Label>
    <asp:DropDownList ID="ddlSelecao" runat="server"></asp:DropDownList><br /><br />
    
    <asp:Label ID="Label3" runat="server" Text="Jogador"></asp:Label>
    <asp:FileUpload ID="fupJogador" runat="server" /><br /><br />

    <asp:Button ID="btnSalvarJogador" runat="server" Text="Salvar" OnClick="btnSalvarJogador_Click" />

    <asp:DataList ID="dataListJogadores" RepeatColumns="4" runat="server">
    
        <ItemTemplate>

             <asp:Image ID="imgJogador" Height="400px" Width="300px"
               ImageUrl='<%#String.Format("ExibeImagem.ashx?IdJogador={0}", Eval("IdJogador")) %>' runat="server" />

          <br />
             <asp:Label ID="lblNome" runat="server" Text='<%#String.Format("Nome <br>{0}</br>", Eval("DsNome")) %>'></asp:Label>
          <br />

             <asp:Label ID="lblCamisa" runat="server" Text='<%#Eval("NrCamisa") %>'></asp:Label>


        </ItemTemplate>
    </asp:DataList>

    <asp:Button CssClass="btn-primary" ID="btnFiltarSelecao" runat="server" Text="Pesquisar Selecão" OnClick="btnFiltarSelecao_Click" /><br />
        <asp:Button ID="btnFiltrarPosicao" runat="server" Text="Pesquisar Posição" OnClick="btnFiltrarPosicao_Click" />
</div>
</asp:Content>


