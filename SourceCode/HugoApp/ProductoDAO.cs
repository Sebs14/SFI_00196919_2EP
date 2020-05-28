using System;
using System.Collections.Generic;
using System.Data;

namespace HugoApp
{
    public class ProductoDAO
    {
        public static List<Products> getLista()
        {
            string sql = "select * from PRODUCT";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Products> lista = new List<Products>();
            foreach (DataRow fila in dt.Rows)
            {
                Products u = new Products();
                u.idproduct = fila[0].ToString();
                u.idbusiness = fila[1].ToString();
                u.name = fila[2].ToString();
                
                lista.Add(u);
            }
            return lista;    
        }


    }
}