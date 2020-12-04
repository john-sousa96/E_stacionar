﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstacionamento
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso não haja usuario logado, ocultará botões da navbar
                template mPage = (template)Page.Master;
                mPage.FindControl("botao_painel").Visible = false;
                mPage.FindControl("menu_usuario").Visible = false;
            }
            else
            {
                // caso um usuario esteja logado, oculta o botão login da navbar
                template mPage = (template)Page.Master;
                mPage.FindControl("botao_login").Visible = false;

                // preenche o nome do usuario logado no dropdown
                Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                menu_nome_logado.Text = Session["user_nome"].ToString();
            }
        }
    }
}