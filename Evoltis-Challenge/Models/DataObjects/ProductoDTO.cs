﻿namespace Evoltis_Challenge.Models.DataObjects
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public float Precio { get; set; }
    }
}
