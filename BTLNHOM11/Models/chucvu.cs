using System.ComponentModel.DataAnnotations;

namespace BTLNHOM11.Models;
public class chucvu
{
    [Key]
    [Display(Name = "ID chức vụ")]
    public string idcv{get;set;}

     [Display(Name = "Tên công việc")]
    public string tencv{get;set;}

    [Display(Name = "Mô tả công việc")]
    
    public string motacv{get;set;}
}