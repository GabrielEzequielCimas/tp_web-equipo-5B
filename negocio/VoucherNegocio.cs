using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using dominio;

namespace negocio
{

    public class VoucherNegocio
    {
        public bool BuscarVoucher(string codigo)
        {
            try
            {
                ConexionDB datos = new ConexionDB();
                datos.setearConsulta("select case when @codigoVoucher in (select CodigoVoucher from Vouchers) then 1 else 0 end as flag_codigo");
                datos.setearParametro("codigoVoucher", codigo);
                datos.ejecutarLectura();
                datos.Lector.Read();
                int flagCodigo = (int)datos.Lector["flag_codigo"];
                if (flagCodigo == 1)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Vouchers> Listar()
        {
            List<Vouchers> lista = new List<Vouchers>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("select CodigoVoucher, IdCliente, FechaCanje, IdArticulo from vouchers ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Vouchers aux = new Vouchers();
                    aux.codigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.idCliente = datos.Lector["IdCliente"] != DBNull.Value ? (int?)datos.Lector["IdCliente"] : null;
                    aux.FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)datos.Lector["FechaCanje"] : null;
                    aux.idArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? (int?)datos.Lector["IdArticulo"] : null;
                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
