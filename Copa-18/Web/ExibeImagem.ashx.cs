using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{    
    public class ExibeImagem : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //Recuperando  a Id do registro 
            Int32 Id = Int32.Parse(context.Request["IdJogador"].ToString());
            //Recupero com o Id a classe que contem o campo Imagem (Array de Bytes)
                      
            //Carregando o objeto pelo ID via banco.
            Jogador j = new JogadorBLL().FindaById(Id);
            

            if (!string.IsNullOrEmpty(j.DsCaminhoImagemJogador))
            {
                //Passando o tipo da imagem para o ContentType
                context.Response.ContentType = j.DsTipoImagem;

                //Passando a imagem no formato array para fazer a conversão
                context.Response.OutputStream.Write(j.DsImagemJogador, 0, j.DsImagemJogador.Length);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}