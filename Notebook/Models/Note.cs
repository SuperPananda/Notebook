using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notebook.Models
{
  //Определяем модель Записи
  public class Note
  {
    [Key]
    //ID звписи
    public int Id { get; set; }
    //Имя
    public string FirstName { get; set; }
    //Фамилия
    public string LastName { get; set; }
    //Телефон
    public double Phone { get; set; }
    //Почта
    public string Email { get; set; }
  }
}
