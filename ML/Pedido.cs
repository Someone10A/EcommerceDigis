﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Estatus Estatus { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total {  get; set; }
        public List<object> Pedidos { get; set; }
        public List<object> DetallesPedidos { get; set; }
        public byte[] Imagen { get; set; }
    }
}
