using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reclamacao.Models
{
    public class ReclamacaoContext : DbContext
    {

        public ReclamacaoContext() : base("DefaultConnection") {

        }

        public DbSet<Models.Usuario> Usuarios { get; set; }
        public object TaxPaers { get; internal set; }

      
    }
}