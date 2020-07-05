using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notebook.Models
{
  //Определяем контекст данных
  public class NotebookDbContext: DbContext
  {
    public DbSet<Note> Notes { get; set; }
  }
}
