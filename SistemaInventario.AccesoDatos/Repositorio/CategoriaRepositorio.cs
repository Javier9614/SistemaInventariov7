using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using SistemaInventarioV7.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var categoriaDB =_db.Categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if (categoriaDB != null)
            {
                categoriaDB.Nombre= categoria.Nombre;
                categoriaDB.Descripcion = categoria.Descripcion;
                categoriaDB.Estado = categoria.Estado;
                _db.SaveChanges();

            }
        }
    }
}
