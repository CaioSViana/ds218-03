<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tabela.aspx.cs" Inherits="Web.Tabela" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Label ID="Label1" runat="server" Text="Data da Partida"></asp:Label>
    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
    <br />
    <br />
    Fase
    <asp:DropDownList ID="ddlFase" runat="server"></asp:DropDownList>
    <br />
    <br />
    Estádio
    <asp:DropDownList ID="ddlEstadio" runat="server"></asp:DropDownList>
    <br />
    <br />

    Seleção 1
    <asp:DropDownList ID="ddlSelecaoOrdem1" runat="server"></asp:DropDownList>
    <asp:TextBox ID="txtPlacarSelecao1" BackColor="Green" runat="server" Width="20px"></asp:TextBox>
    <asp:TextBox ID="txtPlacarSelecao1Prorrogacao" runat="server" Width="20px"></asp:TextBox>
    <asp:TextBox ID="txtPlacarSelecao1Penaltis" runat="server" Width="20px"></asp:TextBox>

    <br />

    X
    
    <br />

    Seleção 2
    <asp:DropDownList ID="ddlSelecaoOrdem2" runat="server"></asp:DropDownList>
    <asp:TextBox ID="txtPlacarSelecao2" BackColor="Green" runat="server" Width="20px"></asp:TextBox>
    <asp:TextBox ID="txtPlacarSelecao2Prorrogacao" runat="server" Width="20px"></asp:TextBox>
    <asp:TextBox ID="txtPlacarSelecao2Penaltis" runat="server" Width="20px"></asp:TextBox>
    <br />
    <br />

    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    <br />
    <br />

    <asp:GridView ID="gvPartidas" AutoGenerateColumns="False" DataKeyNames="ID_PARTIDA, ID_SELECAO_1, ID_SELECAO_2" runat="server">
 
        <Columns>
            <asp:BoundField HeaderText="Data" DataField="DT_PARTIDA" />
            <asp:BoundField HeaderText="Fase" DataField="DS_FASE" />
            <asp:BoundField HeaderText="Placar" DataField="DS_PLACAR" />
            <asp:BoundField HeaderText="Estádio" DataField="DS_ESTADIO" />
                        
            <asp:TemplateField>
                <ItemTemplate>
                    <input type="button"  class ="btn-primary center-block" id="btnQuestionarExclusao" value="Excluir"/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
