using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public class Comissao
    {
        #region Propriedades

        //
        private int idEmpregado;

        public int IDEmpregado
        {
            get { return idEmpregado; }
            set { idEmpregado = value; }
        }

        //
        private EnumComissao idMensagem;

        public EnumComissao IDMensagem
        {
            get { return idMensagem; }
            set { idMensagem = value; }
        }

        //
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        //
        private DateTime dataRegisto;
        public DateTime DataRegisto
        {
            get { return dataRegisto; }
            set { dataRegisto = value; }
        }

        #endregion


        #region Funções

        public void Novo()
        {
            DateTime data = DateTime.Today;

            this.idEmpregado = 0;
            this.idMensagem = 0;
            this.valor = 0;
            this.dataRegisto = new DateTime(data.Year, 1, 1);
        }


        public bool Gravar(out string erro)
        {
            erro = string.Empty;

            bool ok = CamadaDados.Comissao.Gravar(this.IDEmpregado, (byte)this.IDMensagem, this.Valor, out erro);

            return ok;
        }

        #endregion
    }
}
